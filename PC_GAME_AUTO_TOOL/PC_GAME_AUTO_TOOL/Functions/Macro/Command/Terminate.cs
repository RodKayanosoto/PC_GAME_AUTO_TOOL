using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Command
{

    /**
     * Terminateクラスは、プロセスを終了するコマンドを表すクラスです。
     */
    public class Terminate : MacroCommandInterface
    {
        // 終了するプロセスのプロセス名
        private String processName;

        /**
         * Terminateクラスのコンストラクタ
         * 引数には、終了するプロセスのファイルパスを指定します。
         * 引数の数が不正な場合は、ArgumentExceptionをスローします。
         */
        public Terminate(params string[] args)
        {
            // 引数の文字列が1つでない場合は例外をスローする
            if (args.Length != 1)
            {
                throw new ArgumentException("エラー: ファイルパスは1つの引数で指定してください。");
            }

            string path = args[0];

            // 引数のパスがnullまたは空白の場合は例外をスローする
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("エラー: ファイルパスが未入力です。", nameof(path));
            }
            // 引数のパスのファイルが存在しない場合は例外をスローする
            if (!System.IO.File.Exists(path))
            {
                throw new System.IO.FileNotFoundException($"エラー: ファイルが存在しません。 Path: {path}");
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
        }

        /**
         * 指定されたプロセスを終了する
         */
        public void Execute()
        {
            // 終了するプロセスのファイル名を取得する
            string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(processName);
            // 終了するプロセスを取得する
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(fileNameWithoutExtension);
            if (processes.Length == 0)
            {
                throw new Exception($"エラー: 指定されたプロセスが見つかりません。 Path: {processName}");
            }
            // 終了するプロセスをすべて終了する
            foreach (System.Diagnostics.Process process in processes)
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                }
                catch (Exception ex)
                {
                    throw new Exception($"エラー: プロセスを終了できませんでした。 Process ID: {process.Id}, Error: {ex.Message}");
                }
            }
        }

        /**
         * 結果を返す
         * Terminateコマンドは、プロセスを終了するだけで結果は特にないため、常に空文字列を返します。
         */
        public string GetResult()
        {
            return "";
        }

    }
}
