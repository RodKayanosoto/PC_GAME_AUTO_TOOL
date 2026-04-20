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
    [TestClass]
    public class CopyDirectoryTest
    {
        /**
         * CopyDirectoryクラスのテストメソッド
         * フォルダをコピーできることを確認するためのテストです。
         */
        [TestMethod]
        public void TestCopyDirectory()
        {
            // コピー元のディレクトリパス
            string sorceDirectoryPath = TestResourcePaths.FileDir();
            // コピー先のディレクトリ名
            string destinationDirectoryPath = Path.Combine(TestResourcePaths.ResourcesDir(), "TestCopyDir");

            // コピー元のディレクトリが存在することを確認する
            Assert.IsTrue(System.IO.Directory.Exists(sorceDirectoryPath), $"エラー: コピー元のディレクトリ '{sorceDirectoryPath}' が存在しません。");

            // コピー元のディレクトリ内のファイルが存在することを確認する
            {
                string[] sourceFiles = System.IO.Directory.GetFiles(sorceDirectoryPath);
                Assert.IsTrue(sourceFiles.Length > 0, $"エラー: コピー元のディレクトリ '{sorceDirectoryPath}' 内にファイルが存在しません。");
            }

            // コピー先のディレクトリが存在する場合は削除する
            if (System.IO.Directory.Exists(destinationDirectoryPath))
            {
                System.IO.Directory.Delete(destinationDirectoryPath, true);
            }

            // ディレクトリのコピーコマンドを実行する
            {
                MacroCommandInterface command = new CopyDirectory(sorceDirectoryPath, destinationDirectoryPath);
                command.Execute();
            }

            // コピー先のディレクトリが存在することを確認する
            Assert.IsTrue(System.IO.Directory.Exists(destinationDirectoryPath), $"エラー: コピー先のディレクトリ '{destinationDirectoryPath}' が存在しません。");

            // コピー先のディレクトリ内のファイルがコピー元のディレクトリ内のファイルと同じであることを確認する
            {
                string[] sourceFiles = System.IO.Directory.GetFiles(sorceDirectoryPath);
                string[] destinationFiles = System.IO.Directory.GetFiles(destinationDirectoryPath);
                // コピー先のディレクトリ内のファイル数がコピー元のディレクトリ内のファイル数と同じであることを確認する
                Assert.IsTrue(sourceFiles.Length == destinationFiles.Length, "エラー: コピー先のディレクトリ内のファイル数がコピー元のディレクトリ内のファイル数と異なります。");
                // コピー先のディレクトリ内のファイルの内容がコピー元のディレクトリ内のファイルの内容と同じであることを確認する
                for (int i = 0; i < sourceFiles.Length; i++)
                {
                    byte[] sourceContent = System.IO.File.ReadAllBytes(sourceFiles[i]);
                    byte[] destinationContent = System.IO.File.ReadAllBytes(destinationFiles[i]);
                    Assert.IsTrue(sourceContent.SequenceEqual(destinationContent), $"エラー: コピー先のファイル '{destinationFiles[i]}' の内容がコピー元のファイル '{sourceFiles[i]}' の内容と異なります。");
                }
            }

            // コピー先ディレクトリの中の全ファイルを削除する
            foreach (string filePath in System.IO.Directory.GetFiles(destinationDirectoryPath))
            {
                System.IO.File.Delete(filePath);
            }

            // コピー先ディレクトリに適当なファイルを作成する
            {
                string testFilePath = Path.Combine(destinationDirectoryPath, "TestFile.txt");
                System.IO.File.WriteAllText(testFilePath, "This is a test file.");
            }

            // コピー先のディレクトリにファイルが一つだけ存在することを確認する
            {
                string[] destinationFiles = System.IO.Directory.GetFiles(destinationDirectoryPath);
                Assert.IsTrue(destinationFiles.Length == 1, $"エラー: コピー先のディレクトリ '{destinationDirectoryPath}' 内にファイルが一つだけ存在しません。");
            }

            // 再度、ディレクトリのコピーコマンドを実行する(コピー先のディレクトリが存在する場合)
            {
                MacroCommandInterface command = new CopyDirectory(sorceDirectoryPath, destinationDirectoryPath);
                command.Execute();
            }

            // コピー先のディレクトリが存在することを確認する
            Assert.IsTrue(System.IO.Directory.Exists(destinationDirectoryPath), $"エラー: コピー先のディレクトリ '{destinationDirectoryPath}' が存在しません。");

            // コピー先のディレクトリ内のファイルがコピー元のディレクトリ内のファイルと同じであることを確認する
            {
                string[] sourceFiles = System.IO.Directory.GetFiles(sorceDirectoryPath);
                string[] destinationFiles = System.IO.Directory.GetFiles(destinationDirectoryPath);
                // コピー先のディレクトリ内のファイル数がコピー元のディレクトリ内のファイル数と同じであることを確認する
                Assert.IsTrue(sourceFiles.Length == destinationFiles.Length, "エラー: コピー先のディレクトリ内のファイル数がコピー元のディレクトリ内のファイル数と異なります。");
                // コピー先のディレクトリ内のファイルの内容がコピー元のディレクトリ内のファイルの内容と同じであることを確認する
                for (int i = 0; i < sourceFiles.Length; i++)
                {
                    byte[] sourceContent = System.IO.File.ReadAllBytes(sourceFiles[i]);
                    byte[] destinationContent = System.IO.File.ReadAllBytes(destinationFiles[i]);
                    Assert.IsTrue(sourceContent.SequenceEqual(destinationContent), $"エラー: コピー先のファイル '{destinationFiles[i]}' の内容がコピー元のファイル '{sourceFiles[i]}' の内容と異なります。");
                }
            }

            // コピー先のディレクトリを削除する
            System.IO.Directory.Delete(destinationDirectoryPath, true);
        }
        /**
         * 異常系：引数が存在しない場合にArgumentExceptionがスローされることを確認するためのテストです。
         */
        [TestMethod]
        public void errTestCopyDirectoryNoArgs()
        {
            // 引数が存在しない場合にArgumentExceptionがスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new CopyDirectory();
            });
        }

        /**
         * 異常系：引数が1つの場合にArgumentExceptionがスローされることを確認するためのテストです。
         */
        [TestMethod]
        public void errTestCopyDirectory1Args()
        {
            // コピー元のディレクトリパス
            string sorceDirectoryPath = TestResourcePaths.FileDir();

            // 引数が存在しない場合にArgumentExceptionがスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new CopyDirectory(sorceDirectoryPath);
            });
        }

        /**
         * 異常系：引数が3つの場合にArgumentExceptionがスローされることを確認するためのテストです。
         */
        [TestMethod]
        public void errTestCopyDirectory3Args()
        {
            // コピー元のディレクトリパス
            string sorceDirectoryPath = TestResourcePaths.FileDir();
            // コピー先のディレクトリ名
            string destinationDirectoryPath = Path.Combine(TestResourcePaths.ResourcesDir(), "TestCopyDir");
            // コピー先のディレクトリ名2
            string destinationDirectoryPath2 = Path.Combine(TestResourcePaths.ResourcesDir(), "TestCopyDir2");

            // 引数が存在しない場合にArgumentExceptionがスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new CopyDirectory(sorceDirectoryPath, destinationDirectoryPath, destinationDirectoryPath2);
            });
        }

        /**
         * 異常系：引数のコピー元ディレクトリとコピー先ディレクトリが同じである場合にArgumentExceptionがスローされることを確認するためのテストです。
         */
        [TestMethod]
        public void errTestCopyDirectorySameArgs()
        {
            // コピー元のディレクトリパス
            string sorceDirectoryPath = TestResourcePaths.FileDir();

            // 引数が存在しない場合にArgumentExceptionがスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new CopyDirectory(sorceDirectoryPath, sorceDirectoryPath);
            });
        }

        /**
         * 異常系：コピー元ディレクトリが存在しない場合にArgumentExceptionがスローされることを確認するためのテストです。
         */
        [TestMethod]
        public void errTestCopyDirectoryResourceDirNotExists()
        {
            // コピー元のディレクトリパス
            string sorceDirectoryPath = Path.Combine(TestResourcePaths.BaseDir(), "NotExistsDir"); ;
            // コピー先のディレクトリ名
            string destinationDirectoryPath = Path.Combine(TestResourcePaths.ResourcesDir(), "TestCopyDir");

            // 引数が存在しない場合にArgumentExceptionがスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new CopyDirectory(sorceDirectoryPath, sorceDirectoryPath);
            });
        }

        /**
         * 異常系：コピー先ディレクトリの親ディレクトリが存在しない場合にArgumentExceptionがスローされることを確認するためのテストです。
         */
        [TestMethod]
        public void errTestCopyDirectorydestinationDirectoryParentDirNotExists()
        {
            // コピー元のディレクトリパス
            string sorceDirectoryPath = TestResourcePaths.FileDir();
            // コピー先のディレクトリ名
            string destinationDirectoryPath = Path.Combine(TestResourcePaths.BaseDir(), "NotExistsParentDir", "NotExistsChildDir");

            // 引数が存在しない場合にArgumentExceptionがスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new CopyDirectory(sorceDirectoryPath, sorceDirectoryPath);
            });
        }
    }
}
