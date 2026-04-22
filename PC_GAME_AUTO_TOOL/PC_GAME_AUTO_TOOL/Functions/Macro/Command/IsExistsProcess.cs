using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Command
{
    public class IsExistsProcess : MacroCommandInterface
    {
        // プロセス名
        private string processName;
        // プロセスが存在するかどうかの結果
        private bool result;
        // プロセスの配列
        private Process[] processes;

        /**
         * IsExistsProcessクラスのコンストラクタ
         * 引数には、プロセス名を指定します。
         * 引数の数が不正な場合は、ArgumentExceptionをスローします。
         */
        public IsExistsProcess(params String[] args)
        {
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
            if (processName.Contains(System.IO.Path.DirectorySeparatorChar))
            {
                processName = System.IO.Path.GetFileName(processName);
            }

            // プロセス名に拡張子が含まれている場合は、拡張子を削除する
            if (processName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
            {
                processName = processName.Substring(0, processName.Length - 4);
            }

            // プロセス名を取得する
            this.processName = processName;
            // プロセスが存在するかどうかの結果を初期化する
            this.result = false;
            // プロセスの配列を初期化する
            processes = new Process[0];
        }

        /**
         * プロセスが存在するかどうかを返す
         */
        public void Execute()
        {
            // プロセスの配列を取得する
            this.processes = System.Diagnostics.Process.GetProcessesByName(this.processName);
            // プロセスが存在するかどうかを判定する
            this.result = this.processes.Length > 0;
        }

        /**
         * プロセスが存在するかどうかの結果を取得する
         * 1:存在する
         * 0:存在しない
         */
        public String? GetResult()
        {
            if (this.result)
            {
                return "1";
            }
            return "0";
        }

        /**
         * プロセスの配列を取得する
         */
        public Process[] GetProcesses()
        {
            return this.processes;
        }
    }
}
