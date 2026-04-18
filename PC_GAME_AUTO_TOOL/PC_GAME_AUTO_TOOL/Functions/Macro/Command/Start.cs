using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Command
{
    /**
     * 指定されたexeなどのファイルを起動するコマンド
     */
    public class Start : MacroCommandInterface
    {
        // 起動するファイルのパス
        private String path;

        // コンストラクタ
        public Start(params string[] args)
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

            this.path = path;
        }

        /**
         * 指定されたファイルを起動する
         */
        public void Execute()
        {
            // ファイルを起動する
            System.Diagnostics.Process.Start(path);

            // 起動したファイルが正常に起動するまで少し待つ
            Thread.Sleep(2000);

            // 起動したファイルのプロセスが存在するか確認する
            string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(path);
            Process[] processes = Process.GetProcessesByName(fileNameWithoutExtension);
            if (processes.Length == 0)
            {
                throw new Exception($"エラー: 指定されたファイルが起動していません。 Path: {path}");
            }

            Process process = processes[0];
        }
    }
}
