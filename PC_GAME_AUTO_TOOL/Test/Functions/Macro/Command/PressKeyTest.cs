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
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.Enums;

namespace Test.Functions.Macro.Command
{
    /**
     * キー操作を行うコマンドのテストクラス
     */
    [TestClass]
    public class PressKeyTest
    {
        [TestMethod]
        public void TestPressKey()
        {
            // テスト用に操作するテキストファイルを指定する
            String filePath = TestResourcePaths.FilePath("PressKeyTest.txt");
            // ゴールデンマスターのテキストファイルを指定する
            String goldenMasterFilePath = TestResourcePaths.FilePath("PressKeyTestGoldenMaster.txt");

            // Notepadを起動する
            System.Diagnostics.Process process = System.Diagnostics.Process.Start("Notepad.exe", filePath);
            // Notepadが起動するまで少し待つ
            System.Threading.Thread.Sleep(2000);

            // 起動したファイルのプロセスが存在するか確認する
            Process[] processes = Process.GetProcessesByName("Notepad");
            if (processes.Length == 0)
            {
                Assert.Fail($"エラー: 指定されたファイルが起動していません。 Path: {filePath}");
            }

            // 入力するコマンドを指定する
            List<KeyBordEnum.KeyEnum[]> commandList = new List<KeyBordEnum.KeyEnum[]>();
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.C });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.C });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.C });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.Control, KeyBordEnum.KeyEnum.A });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.A });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.B });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.C });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.D });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.E });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.F });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.G });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.H });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.I });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.J });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.K });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.L });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.M });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.N });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.O });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.P });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.Q });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.R });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.S });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.T });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.U });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.V });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.W });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.X });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.Y });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.Z });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.Shift, KeyBordEnum.KeyEnum.Z });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.Enter });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.D0 });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.D1 });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.D2 });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.D3 });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.D4 });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.D5 });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.D6 });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.D7 });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.D8 });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.D9 });
            //commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.Enter });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.Control, KeyBordEnum.KeyEnum.S });
            commandList.Add(new KeyBordEnum.KeyEnum[] { KeyBordEnum.KeyEnum.Alt, KeyBordEnum.KeyEnum.F4 });

            // コマンド実行
            foreach (KeyBordEnum.KeyEnum[] commandKeys in commandList)
            {
                String[] commandKeyNames = commandKeys.Select(key => key.ToString()).ToArray();
                MacroCommandInterface command = new PressKey(commandKeyNames);
                command.Execute();
                // コマンドを実行後、少し待つ(連続でコマンド実行するのはやめておく)
                System.Threading.Thread.Sleep(50);
            }

            // Notepadを閉じる
            process.CloseMainWindow();
            process.Close();

            // テストで作成したファイルの存在チェック
            Assert.IsTrue(File.Exists(filePath), $"エラー: テストで作成したファイルが存在しません。 Path: {filePath}");

            // ゴールデンマスターのファイルの存在チェック
            Assert.IsTrue(File.Exists(goldenMasterFilePath), $"エラー: ゴールデンマスターのファイルが存在しません。 Path: {goldenMasterFilePath}");

            // ゴールデンマスターのファイルとテストで作成したファイルの内容を比較する
            string expected = File.ReadAllText(goldenMasterFilePath);
            string actual = File.ReadAllText(filePath);
            Assert.AreEqual(expected, actual, "エラー: ゴールデンマスターのファイルとテストで作成したファイルの内容が一致しません。");
        }

        /**
         * 異常系：引数なし
         */
        [TestMethod]
        public void ErrTestPressKeyNoArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new PressKey();
                command.Execute();
            });
        }

        /**
         * 異常系：引数が3つ
         */
        [TestMethod]
        public void ErrTestPressKey3Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new PressKey(KeyBordEnum.KeyEnum.Control.ToString(), KeyBordEnum.KeyEnum.C.ToString(), KeyBordEnum.KeyEnum.D.ToString());
            });
        }

        /**
         * 異常系：引数が無効な文字列
         */
        [TestMethod]
        public void ErrTestPressKeyWrongKey()
        {
            // 比較用：正しい引数でコンストラクタを呼び出す（ここでエラーがでなければよい）
            {
                MacroCommandInterface command = new PressKey("Control");
            }

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new PressKey("Control2");
            });
        }

        /**
         * 異常系：引数が2つの場合、一つ目のキーがShift、Control、Alt以外ならばエラーとなる
         */
        [TestMethod]
        public void ErrTestPressKeyFirstKeyIsWrong()
        {
            // 比較用：一つ目のキーがShift(ここでエラーが出なければよい)
            {
                MacroCommandInterface command = new PressKey(KeyBordEnum.KeyEnum.Shift.ToString(), KeyBordEnum.KeyEnum.B.ToString());
            }

            // 比較用：一つ目のキーがControl(ここでエラーが出なければよい)
            {
                MacroCommandInterface command = new PressKey(KeyBordEnum.KeyEnum.Control.ToString(), KeyBordEnum.KeyEnum.B.ToString());
            }

            // 比較用：一つ目のキーがAlt(ここでエラーが出なければよい)
            {
                MacroCommandInterface command = new PressKey(KeyBordEnum.KeyEnum.Alt.ToString(), KeyBordEnum.KeyEnum.B.ToString());
            }

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new PressKey(KeyBordEnum.KeyEnum.A.ToString(), KeyBordEnum.KeyEnum.B.ToString());
            });
        }

        /**
         * 異常系：引数が2つの場合、二つ目のキーがShift、Control、Altならばエラーとなる
         */
        [TestMethod]
        public void ErrTestPressKeySecondKeyIsWrong()
        {
            // 比較用：二つ目のキーがShift、Control、Alt以外(ここでエラーが出なければよい)
            {
                MacroCommandInterface command = new PressKey(KeyBordEnum.KeyEnum.Shift.ToString(), KeyBordEnum.KeyEnum.B.ToString());
            }

            // コンストラクタで例外がスローされることを確認する(二つ目のキーがShift)
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new PressKey(KeyBordEnum.KeyEnum.Shift.ToString(), KeyBordEnum.KeyEnum.Shift.ToString());
            });

            // コンストラクタで例外がスローされることを確認する(二つ目のキーがControl)
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new PressKey(KeyBordEnum.KeyEnum.Shift.ToString(), KeyBordEnum.KeyEnum.Control.ToString());
            });

            // コンストラクタで例外がスローされることを確認する(二つ目のキーがAlt)
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new PressKey(KeyBordEnum.KeyEnum.Shift.ToString(), KeyBordEnum.KeyEnum.Alt.ToString());
            });
        }
    }
}
