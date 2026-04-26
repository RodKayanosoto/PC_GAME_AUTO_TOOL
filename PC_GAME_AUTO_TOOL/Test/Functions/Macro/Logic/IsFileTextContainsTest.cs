using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Resources;
using PC_GAME_AUTO_TOOL.Functions.Macro.Logic;
using PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace;


namespace Test.Functions.Macro.Logic
{
    /**
     * IsFileTextContailsクラスのテストクラス
     */
    [TestClass]
    public class IsFileTextContainsTest
    {
        // テスト用のファイルのパスを指定する
        string filePathSjis = TestResourcePaths.FilePath("IsFileTextContainsTest_SJIS.txt");
        string filePathUtf8 = TestResourcePaths.FilePath("IsFileTextContainsTest_UTF8.txt");
        string filePathUtf8WithBom = TestResourcePaths.FilePath("IsFileTextContainsTest_UTF8WithBom.txt");

        [TestMethod]
        public void TestIsFileTextContains()
        {

            // ファイルが存在することを確認する
            Assert.IsTrue(File.Exists(filePathSjis), $"エラー: テスト用のファイルが存在しません。 Path: {filePathSjis}");
            Assert.IsTrue(File.Exists(filePathUtf8), $"エラー: テスト用のファイルが存在しません。 Path: {filePathUtf8}");
            Assert.IsTrue(File.Exists(filePathUtf8WithBom), $"エラー: テスト用のファイルが存在しません。 Path: {filePathUtf8WithBom}");

            // SJISファイルをテストする
            {
                string[] testStrings = new string[] {
                    "abc",
                    "BCD",
                    "うえお",
                    "234"
                };

                foreach (string testString in testStrings)
                {
                    PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("SJIS", filePathSjis, testString);
                    // 該当の文字列がファイルのテキストに含まれていることを確認する
                    Assert.IsTrue(command.execute());
                }

                {
                    PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("SJIS", filePathSjis, "ac");
                    // 該当の文字列がファイルのテキストに含まれていないことを確認する
                    Assert.IsFalse(command.execute());
                }
            }

            // UTF-8ファイルをテストする
            {
                string[] testStrings = new string[] {
                    "abc",
                    "BCD",
                    "うえお",
                    "234"
                };

                foreach (string testString in testStrings)
                {
                    PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("UTF-8", filePathUtf8, testString);
                    // 該当の文字列がファイルのテキストに含まれていることを確認する
                    Assert.IsTrue(command.execute());
                }

                {
                    PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("SJIS", filePathSjis, "ac");
                    // 該当の文字列がファイルのテキストに含まれていないことを確認する
                    Assert.IsFalse(command.execute());
                }
            }

            // UTF-8 with BOMファイルをテストする
            {
                string[] testStrings = new string[] {
                    "abc",
                    "BCD",
                    "うえお",
                    "234"
                };
                foreach (string testString in testStrings)
                {
                    PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("UTF-8", filePathUtf8WithBom, testString);
                    // 該当の文字列がファイルのテキストに含まれていることを確認する
                    Assert.IsTrue(command.execute());
                }

                {
                    PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("SJIS", filePathSjis, "ac");
                    // 該当の文字列がファイルのテキストに含まれていないことを確認する
                    Assert.IsFalse(command.execute());
                }
            }
        }

        /**
         * 異常系：引数が存在しない場合
         */
        [TestMethod]
        public void ErrTestIsFileTextContainsNoArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains();
            });

        }

        [TestMethod]
        /**
         * 異常系：引数が2つ存在する場合
         */
        public void ErrTestIsFileTextContains2Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("arg1", "arg2");
            });
        }

        /**
         * 異常系：引数が4つ存在する場合
         */
        public void ErrTestIsFileTextContains4Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("arg1", "arg2", "arg3", "arg4");
            });
        }

        /**
         * 異常系：存在しない文字コードを指定している場合
         */
        public void ErrTestIsFileTextContainsWrongCharCode()
        {
            // テスト用のファイルのパスを指定する
            string filePathUtf8 = TestResourcePaths.FilePath("IsFileTextContainsTest_UTF8.txt");

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("UTF-9", filePathUtf8, "123");
            });
        }

        /**
         * 異常系：存在しないファイルを指定している場合
         */
        public void ErrTestIsFileTextContainsFileNotExists()
        {
            // テスト用のファイルのパスを指定する
            string filePathUtf8 = TestResourcePaths.FilePath("IsFileTextContainsTest_UTF9.txt");

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("UTF-8", filePathUtf8, "123");
            });
        }

        /**
         * 異常系：検査対象の文字列が空の場合
         */
        public void ErrTestIsFileTextContainsNoTargetString()
        {
            // テスト用のファイルのパスを指定する
            string filePathUtf8 = TestResourcePaths.FilePath("IsFileTextContainsTest_UTF8.txt");

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("UTF-8", filePathUtf8, " ");
            });
        }

    }
}
