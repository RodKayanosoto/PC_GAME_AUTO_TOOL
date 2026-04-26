using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.Logic.Struct;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Logic
{
    public class IsExistsProcess : InterFace.Logic
    {
        private ArgMents argMents;

        /**
         * IsExistsProcessクラスのコンストラクタ
         * 引数には、プロセス名を指定します。
         * 引数の数が不正な場合は、ArgumentExceptionをスローします。
         */
        public IsExistsProcess(int lineNum, params string[] args)
        {
            this.argMents = new ArgMents();
            // 引数の数をチェックする
            if (args.Length == 0)
            {
                throw new ArgumentException("引数が不足しています。プロセス名を指定してください。");
            }
            else if (args.Length > 1)
            {
                throw new ArgumentException("引数が多すぎます。プロセス名のみを指定してください。");
            }

            // プロセス名が空でないことを確認する
            if (string.IsNullOrWhiteSpace(args[0]))
            {
                throw new ArgumentException("プロセス名が空です。プロセス名を指定してください。");
            }

            // 暫定のプロセス名を取得する
            string processName = args[0];

            // プロセス名にパスが含まれている場合は、パスを削除する
            if (processName.Contains(Path.DirectorySeparatorChar))
            {
                processName = Path.GetFileName(processName);
            }

            // プロセス名に拡張子が含まれている場合は、拡張子を削除する
            if (processName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
            {
                processName = processName.Substring(0, processName.Length - 4);
            }

            this.argMents.addArg(new KeyValuePair<string, string>(lineNum.ToString() + "_processName", processName));
        }

        public IsExistsProcess(ArgMents arguments)
        {
            this.argMents = arguments;
        }

        /**
         * プロセスが存在するかどうかを返す
         */
        public bool execute()
        {
            // プロセスの配列を取得する
            string processName = this.argMents.stringVariableList[0].Value;
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }

        /**
         * 引数全体を再セットする処理
         */
        public void setArgs(ArgMents argMents) { this.argMents = argMents; }
        /**
         * 引数を取得する処理
         */
        public ArgMents getArgs() { return this.argMents; }
        /**
         * 引数を追加する処理(int型)
         */
        public void addArg(KeyValuePair<string, int> arg) { this.argMents.addArg(arg); }
        /**
         * 引数を追加する処理(string型)
         */
        public void addArg(KeyValuePair<string, string> arg) { this.argMents.addArg(arg); }
    }
}
