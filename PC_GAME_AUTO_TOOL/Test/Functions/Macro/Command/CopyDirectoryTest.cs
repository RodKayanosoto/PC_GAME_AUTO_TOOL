using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Resources;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using System.IO;

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
            string sorceDirectoryPath = Path.Combine(TestResourcePaths.FileDir(), "CopyDirectoryTest");
            // コピー先のディレクトリ名
            string destinationDirectoryPath = Path.Combine(TestResourcePaths.FileDir(), "CopyDirectoryTest2");

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
            Assert.IsTrue(isSameDirectory(sorceDirectoryPath, destinationDirectoryPath), $"エラー: コピー先のディレクトリ '{destinationDirectoryPath}' がコピー元と一致しません。");

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
            Assert.IsTrue(isSameDirectory(sorceDirectoryPath, destinationDirectoryPath), $"エラー: コピー先のディレクトリ '{destinationDirectoryPath}' がコピー元と一致しません。");

            // コピー先のディレクトリを削除する
            System.IO.Directory.Delete(destinationDirectoryPath, true);
        }

        /**
         * コピー先のディレクトリ内がコピー元と完全一致していることを確認するためのヘルパーメソッドです。
         * 異なる場合は `false` を返す。すべて一致する場合にのみ `true` を返す。
         */
        private bool isSameDirectory(string dir1, string dir2)
        {
            // サブディレクトリを含めて全ファイル取得
            string[] sourceFiles = Directory.GetFiles(
                dir1,
                "*",
                SearchOption.AllDirectories);

            string[] destinationFiles = Directory.GetFiles(
                dir2,
                "*",
                SearchOption.AllDirectories);

            // 相対パスへ変換
            var sourceRelativeFiles = sourceFiles
                .Select(x => Path.GetRelativePath(dir1, x))
                .OrderBy(x => x)
                .ToArray();

            var destinationRelativeFiles = destinationFiles
                .Select(x => Path.GetRelativePath(dir2, x))
                .OrderBy(x => x)
                .ToArray();

            // ファイル数確認
            if (sourceRelativeFiles.Length != destinationRelativeFiles.Length)
            {
                return false;
            }

            // ファイル構成確認（順序は既にソート済み）
            for (int i = 0; i < sourceRelativeFiles.Length; i++)
            {
                if (!string.Equals(sourceRelativeFiles[i], destinationRelativeFiles[i], StringComparison.Ordinal))
                {
                    return false;
                }
            }

            // 内容確認
            foreach (var relativePath in sourceRelativeFiles)
            {
                string sourceFile = Path.Combine(dir1, relativePath);
                string destinationFile = Path.Combine(dir2, relativePath);

                // ファイルが存在しない場合は不一致
                if (!File.Exists(sourceFile) || !File.Exists(destinationFile))
                {
                    return false;
                }

                byte[] sourceContent = File.ReadAllBytes(sourceFile);
                byte[] destinationContent = File.ReadAllBytes(destinationFile);

                if (!sourceContent.SequenceEqual(destinationContent))
                {
                    return false;
                }
            }

            return true;
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
            string sorceDirectoryPath = Path.Combine(TestResourcePaths.FileDir(), "CopyDirectoryTest");

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
            string sorceDirectoryPath = Path.Combine(TestResourcePaths.FileDir(), "CopyDirectoryTest");
            // コピー先のディレクトリ名
            string destinationDirectoryPath = Path.Combine(TestResourcePaths.FileDir(), "CopyDirectoryTest2");
            // コピー先のディレクトリ名2
            string destinationDirectoryPath2 = Path.Combine(TestResourcePaths.FileDir(), "CopyDirectoryTest3");

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
            string sorceDirectoryPath = Path.Combine(TestResourcePaths.FileDir(), "CopyDirectoryTest");

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
            string sorceDirectoryPath = Path.Combine(TestResourcePaths.FileDir(), "NotExistsDir"); ;
            // コピー先のディレクトリ名
            string destinationDirectoryPath = Path.Combine(TestResourcePaths.ResourcesDir(), "CopyDirectoryTest2");

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
            string sorceDirectoryPath = Path.Combine(TestResourcePaths.FileDir(), "CopyDirectoryTest");
            // コピー先のディレクトリ名
            string destinationDirectoryPath = Path.Combine(TestResourcePaths.FileDir(), "NotExistsParentDir", "NotExistsChildDir");

            // 引数が存在しない場合にArgumentExceptionがスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new CopyDirectory(sorceDirectoryPath, sorceDirectoryPath);
            });
        }
    }
}
