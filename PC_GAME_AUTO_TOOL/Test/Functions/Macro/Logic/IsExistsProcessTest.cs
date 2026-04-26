using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Resources;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.Logic;

namespace Test.Functions.Macro.Logic
{
    /**
     * IsExistsProcessクラスのテストクラス
     */
    [TestClass]
    public class IsExistsProcessTest
    {
        [TestMethod]
        public void TestIsExistsProcess()
        {
            // 起動するファイルのパスを指定する
            string filePath = TestResourcePaths.ExePath("WinMergeU.exe");

            // ファイルが存在することを確認する
            Assert.IsTrue(File.Exists(filePath), $"エラー: テスト用のファイルが存在しません。 Path: {filePath}");
            // 既に同じプロセスが起動している場合は、すべてのWinMergeプロセスを終了する
            {
                Process[] existingProcesses = Process.GetProcessesByName("WinMergeU");
                foreach (Process process in existingProcesses)
                {
                    try
                    {
                        process.Kill();
                        process.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail($"エラー: 既存のWinMergeプロセスを終了できませんでした。 Process ID: {process.Id}, Error: {ex.Message}");
                    }
                }
            }

            // 存在しないプロセス名を指定して、IsExistsProcessを実行する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsExistsProcess(1, filePath);
                // コマンドを実行する
                Assert.IsFalse(command.execute());
            }

            // テスト用にWinMergeプロセスを起動する
            {
                // ファイルを起動する
                Process.Start(filePath);
            }

            // 存在するプロセス名を指定して、IsExistsProcessを実行する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsExistsProcess(1, filePath);
                // コマンドを実行する
                Assert.IsTrue(command.execute());
            }

            // テストに使用したプロセスを終了する
             {
                Process[] existingProcesses = Process.GetProcessesByName("WinMergeU");
                foreach (Process process in existingProcesses)
                {
                    try
                    {
                        process.Kill();
                        process.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail($"エラー: テスト用のWinMergeプロセスを終了できませんでした。 Process ID: {process.Id}, Error: {ex.Message}");
                    }
                }
            }

        }

        /**
         * 異常系：引数が存在しない場合
         */
        [TestMethod]
        public void ErrTestIsExistsProcessNoArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsExistsProcess(1);
            });

        }

        [TestMethod]
        /**
         * 異常系：引数が2つ存在する場合
         */
        public void ErrTestIsExistsProcess2Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsExistsProcess(1, "arg1", "arg2");
            });
        }
        [TestMethod]
        /**
         * 異常系：引数が空白の場合
         */
        public void ErrTestIsExistsProcessEmptyArg()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsExistsProcess(1, "   ");
            });
        }
    }
}
