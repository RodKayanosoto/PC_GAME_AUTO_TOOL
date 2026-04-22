using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command;
using System.Diagnostics;
using Test.Resources;

namespace Test.Functions.Macro.Command
{
    /**
     * Terminateクラスのテストクラス
     */
    [TestClass]
    public class TerminateTest
    {
        [TestMethod]
        public void TestTerminate()
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


            // テスト用にWinMergeプロセスを起動する
            {
                // ファイルを起動する
                System.Diagnostics.Process.Start(filePath);
                // 起動したファイルが正常に起動するまで少し待つ
                Thread.Sleep(2000);
            }

            // プロセス名を指定して、Terminateを実行する
            {
                MacroCommandInterface command = new Terminate(filePath);
                // コマンドを実行する
                command.Execute();
                // プロセスが終了したことを確認する
                Process[] existingProcesses = Process.GetProcessesByName("WinMergeU");
                Assert.AreEqual(0, existingProcesses.Length, "エラー: テスト用のWinMergeプロセスが終了していません。");
            }

            // テスト用に起動したWinMergeプロセスを終了する
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

            // テスト用に起動したWinMergeプロセスが終了していることを確認する
            {
                Process[] existingProcesses = Process.GetProcessesByName("WinMergeU");
                Assert.AreEqual(0, existingProcesses.Length, "エラー: テスト用のWinMergeプロセスが終了していません。");
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
                MacroCommandInterface command = new Terminate();
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
                MacroCommandInterface command = new Terminate("arg1", "arg2");
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
                MacroCommandInterface command = new Terminate("   ");
            });
        }

    }
}

