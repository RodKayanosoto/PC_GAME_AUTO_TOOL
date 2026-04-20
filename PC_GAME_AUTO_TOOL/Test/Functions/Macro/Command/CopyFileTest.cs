using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Resources;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;

namespace Test.Functions.Macro.Command
{
    /**
     * CopyFileクラスのテストクラス
     */
    [TestClass]
    public class CopyFileTest
    {
        [TestMethod]
        public void TestCopyFile()
        {
            // コピー元のファイル
            string sourcePath = TestResourcePaths.FilePath("CopyFileTest.txt");
            // コピー先のファイル
            string destinationPath = TestResourcePaths.FilePath("CopyFileTest_Copy.txt");

            // コピー元のファイルが存在することを確認する
            Assert.IsTrue(System.IO.File.Exists(sourcePath), $"エラー: コピー元のファイル '{sourcePath}' が存在しません。");


            // ファイルのコピーをテストする(既存ファイルなし)
            {
                // コピー先のファイルが存在する場合は削除する
                if (System.IO.File.Exists(destinationPath))
                {
                    System.IO.File.Delete(destinationPath);
                }

                // ファイルのコピーコマンドを実行する
                MacroCommandInterface command = new CopyFile(sourcePath, destinationPath);
                command.Execute();

                // コピー先のファイルが存在することを確認する
                Assert.IsTrue(System.IO.File.Exists(destinationPath), $"エラー: コピー先のファイル '{destinationPath}' が存在しません。");

                // コピー先のファイルの内容がコピー元のファイルと同じであることを確認する
                byte[] sourceContent = System.IO.File.ReadAllBytes(sourcePath);
                byte[] destinationContent = System.IO.File.ReadAllBytes(destinationPath);
                Assert.IsTrue(sourceContent.SequenceEqual(destinationContent), "エラー: コピー先のファイルの内容がコピー元のファイルと異なります。");
            }

            // ファイルのコピーをテストする(既存ファイルあり・上書き)
            {
                // コピー先のファイルの内容を変更する
                System.IO.File.WriteAllText(destinationPath, "This is a modified file.");

                // コピー先のファイルの内容がコピー元のファイルと異なることを確認する
                {
                    byte[] sourceContent = System.IO.File.ReadAllBytes(sourcePath);
                    byte[] destinationContent = System.IO.File.ReadAllBytes(destinationPath);
                    Assert.IsFalse(sourceContent.SequenceEqual(destinationContent), "エラー: コピー先のファイルの内容がコピー元のファイルと一致しています。");
                }

                // ファイルのコピーコマンドを実行する
                MacroCommandInterface command = new CopyFile(sourcePath, destinationPath);
                command.Execute();

                // コピー先のファイルの内容がコピー元のファイルと同じであることを確認する
                {
                    byte[] sourceContent = System.IO.File.ReadAllBytes(sourcePath);
                    byte[] destinationContent = System.IO.File.ReadAllBytes(destinationPath);
                    Assert.IsTrue(sourceContent.SequenceEqual(destinationContent), "エラー: コピー先のファイルの内容がコピー元のファイルと異なります。");
                }
            }
        }

        /**
         * 異常系：引数が存在しない場合
         */
        [TestMethod]
        public void ErrTestCopyFileNoArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new CopyFile();
            });
        }

        /**
         * 異常系：引数が3つ存在する場合
         */
        [TestMethod]
        public void ErrTestCopyFile3Args()
        {
            // コピー元のファイル
            string sourcePath = TestResourcePaths.FilePath("CopyFileTest.txt");
            // コピー先のファイル
            string destinationPath = TestResourcePaths.FilePath("CopyFileTest_Copy.txt");
            // コピー先のファイル2
            string destinationPath2 = TestResourcePaths.FilePath("CopyFileTest_Copy2.txt");

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new CopyFile(sourcePath, destinationPath, destinationPath2);
            });
        }

        /**
         * 異常系：コピー元のファイルが存在しない場合
         */
        [TestMethod]
        public void ErrTestCopyFileResourceFileNotExists()
        {
            // コピー元のファイル
            string sourcePath = TestResourcePaths.FilePath("CopyFileTest2.txt");
            // コピー先のファイル
            string destinationPath = TestResourcePaths.FilePath("CopyFileTest_Copy.txt");

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<FileNotFoundException>(() =>
            {
                MacroCommandInterface command = new CopyFile(sourcePath, destinationPath);
            });
        }
    }
}
