using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.Logic;
using PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace;

namespace Test.Functions.Macro.Logic
{
    /**
     * 比較演算子のテストコード
     */
    [TestClass]
    public class LessThanOrEqualTest
    {
        [TestMethod]
        public void testLessThanOrEqual()
        {
            // trueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThanOrEqual("-2", "-1");
                Assert.IsTrue(command.execute());
            }

            // trueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThanOrEqual("-1", "0");
                Assert.IsTrue(command.execute());
            }

            // trueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThanOrEqual("0", "1");
                Assert.IsTrue(command.execute());
            }

            // trueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThanOrEqual("1", "1");
                Assert.IsTrue(command.execute());
            }

            // falseとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThanOrEqual("2", "1");
                Assert.IsFalse(command.execute());
            }
        }

        /**
         * 引数が存在しない場合、エラーとなる
         */
        [TestMethod]
        public void testLessThanOrEqualNoArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThanOrEqual();
            });
        }

        /**
         * 引数が1つの場合、エラーとなる
         */
        [TestMethod]
        public void testLessThanOrEqual1Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThanOrEqual("1");
            });
        }

        /**
         * 引数が3つの場合、エラーとなる
         */
        [TestMethod]
        public void testLessThanOrEqual3Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThanOrEqual("1", "2", "3");
            });
        }

        /**
         * 引数が数値でない場合、エラーとなる
         */
        [TestMethod]
        public void testLessThanOrEqualWrongArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThanOrEqual("a", "2");
            });

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThanOrEqual("1", "b");
            });
        }
    }
}
