using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command;
using System.Diagnostics;
using Test.Resources;

namespace Test.Functions.Macro.Command
{
    /**
     * exe等のファイルを起動するコマンドのテスト
     */
    [TestClass]
    public class StartTest
    {
        /**
         * ファイルの実行テスト
         */
        [TestMethod]
        public void TestExe()
        {
            // 起動するファイルのパスを指定する
            string filePath = TestResourcePaths.ExePath("WinMergeU.exe");

            // ファイル起動コマンドを実行する
            MacroCommandInterface command = new Start(filePath);
            command.Execute();

            // 起動したファイルのプロセスが存在するか確認する
            Process[] processes = Process.GetProcessesByName("WinMergeU");
            Assert.IsTrue(processes.Length > 0, "エラー: 指定されたファイルが起動していません。");

            // 起動したexeを終了する
            foreach (Process process in processes)
            {
                process.Kill();
            }
        }


        /**
         * 異常系：存在しないファイルを指定する
         */
        [TestMethod]
        public void ErrTestExeNotExistsFile()
        {
            // 起動するファイルのパスを指定する
            String baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = TestResourcePaths.ExePath("WinMergeU2.exe");

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<FileNotFoundException>(() =>
            {
                MacroCommandInterface command = new Start(filePath);
            });
        }

        /**
         * 異常系：引数無し
         */
        [TestMethod]
        public void ErrTestExeNoArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new Start();
            });
        }

        /**
         * 異常系：引数が2つ
         */
        [TestMethod]
        public void ErrTestExe2Args()
        {
            // 起動するファイルのパスを指定する
            String baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = TestResourcePaths.ExePath("WinMergeU2.exe");

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new Start(filePath, filePath);
            });
        }
    }
}
