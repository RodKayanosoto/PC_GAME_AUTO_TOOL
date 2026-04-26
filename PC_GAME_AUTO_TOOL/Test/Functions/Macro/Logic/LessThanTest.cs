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
    public class LessThanTest
    {
        [TestMethod]
        public void testLessThan()
        {
            // trueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThan("-2", "-1");
                Assert.IsTrue(command.execute());
            }

            // trueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThan("-1", "0");
                Assert.IsTrue(command.execute());
            }

            // trueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThan("0", "1");
                Assert.IsTrue(command.execute());
            }

            // falseとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThan("1", "1");
                Assert.IsFalse(command.execute());
            }

            // falseとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThan("2", "1");
                Assert.IsFalse(command.execute());
            }
        }

        /**
         * 引数が存在しない場合、エラーとなる
         */
        [TestMethod]
        public void testLessThanNoArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThan();
            });
        }

        /**
         * 引数が1つの場合、エラーとなる
         */
        [TestMethod]
        public void testLessThan1Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThan("1");
            });
        }

        /**
         * 引数が3つの場合、エラーとなる
         */
        [TestMethod]
        public void testLessThan3Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThan("1", "2", "3");
            });
        }

        /**
         * 引数が数値でない場合、エラーとなる
         */
        [TestMethod]
        public void testLessThanWrongArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThan("a", "2");
            });

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new LessThan("1", "b");
            });
        }
    }
}
