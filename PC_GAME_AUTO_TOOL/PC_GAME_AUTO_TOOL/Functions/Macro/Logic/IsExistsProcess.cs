using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Logic
{
    public class IsExistsProcess : InterFace.Logic
    {
        // プロセス名
        private string processName;
        // プロセスの配列
        private Process[] processes;

        /**
         * IsExistsProcessクラスのコンストラクタ
         * 引数には、プロセス名を指定します。
         * 引数の数が不正な場合は、ArgumentExceptionをスローします。
         */
        public IsExistsProcess(params string[] args)
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
            if (processName.Contains(Path.DirectorySeparatorChar))
            {
                processName = Path.GetFileName(processName);
            }

            // プロセス名に拡張子が含まれている場合は、拡張子を削除する
            if (processName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
            {
                processName = processName.Substring(0, processName.Length - 4);
            }

            this.processName = processName;
        }

        /**
         * プロセスが存在するかどうかを返す
         */
        public bool execute()
        {
            // プロセスの配列を取得する
            processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }
    }
}
