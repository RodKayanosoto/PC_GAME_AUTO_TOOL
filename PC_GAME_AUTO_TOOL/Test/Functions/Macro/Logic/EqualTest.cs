using PC_GAME_AUTO_TOOL.Functions.Macro.Command;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.Logic;
using PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Functions.Macro.Logic
{
    /**
     * 比較演算子のテストコード
     */
    [TestClass]
    public class EqualTest
    {
        [TestMethod]
        public void testEqual()
        {
            // 値が一致する場合はtrueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal(1, "-1", "-1");
                Assert.IsTrue(command.execute());
            }

            // 値が一致する場合はtrueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal(1, "0", "0");
                Assert.IsTrue(command.execute());
            }

            // 値が一致する場合はtrueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal(1, "1", "1");
                Assert.IsTrue(command.execute());
            }

            // 値が一致しない場合はfalseとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal(1, "1", "0");
                Assert.IsFalse(command.execute());
            }

            // 値が一致しない場合はfalseとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal(1, "0", "1");
                Assert.IsFalse(command.execute());
            }
        }

        /**
         * 引数を変更した場合、正しく動作することを確認する
         */
        [TestMethod]
        public void testLogicArgumentChange()
        {
            // 値が一致する場合はtrueとなることを確認する
            PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal(1, "1", "1");
            Assert.IsTrue(command.execute());

            // 引数を丸ごと変更する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.Struct.ArgMents argMents = new PC_GAME_AUTO_TOOL.Functions.Macro.Logic.Struct.ArgMents();
                argMents.addArg(new KeyValuePair<string, int>("2_arg1", 3));
                argMents.addArg(new KeyValuePair<string, int>("2_arg2", 4));
                command.setArgs(argMents);
                Assert.IsFalse(command.execute());
            }

            // 引数の一部を変更する(setArgs)
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.Struct.ArgMents argMents = command.getArgs();
                argMents.numericVariableList[0] = new KeyValuePair<string, int>("2_arg1", 4);
                // ※実はこのsetArgsを呼び出さなくても、argMentsの内容が変更されているため、正しく動作する
                //command.setArgs(argMents);
                Assert.IsTrue(command.execute());
            }
        }

        /**
         * 引数が存在しない場合、エラーとなる
         */
        [TestMethod]
        public void testEqualNoArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal(1);
            });
        }

        /**
         * 引数が1つの場合、エラーとなる
         */
        [TestMethod]
        public void testEqual1Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal(1, "1");
            });
        }

        /**
         * 引数が3つの場合、エラーとなる
         */
        [TestMethod]
        public void testEqual3Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal(1, "1", "2", "3");
            });
        }

        /**
         * 引数が数値でない場合、エラーとなる
         */
        [TestMethod]
        public void testEqualWrongArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal(1, "a", "2");
            });

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal(1, "1", "b");
            });
        }
    }
}
