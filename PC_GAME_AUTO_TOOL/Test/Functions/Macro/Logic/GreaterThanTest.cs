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
    public class GreaterThanTest
    {
        [TestMethod]
        public void testGreaterThan()
        {
            // trueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new GreaterThan("-1", "-2");
                Assert.IsTrue(command.execute());
            }

            // trueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new GreaterThan("0", "-1");
                Assert.IsTrue(command.execute());
            }

            // trueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new GreaterThan("1", "0");
                Assert.IsTrue(command.execute());
            }

            // falseとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new GreaterThan("1", "1");
                Assert.IsFalse(command.execute());
            }

            // falseとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new GreaterThan("1", "2");
                Assert.IsFalse(command.execute());
            }
        }

        /**
         * 引数が存在しない場合、エラーとなる
         */
        [TestMethod]
        public void testGreaterThanNoArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new GreaterThan();
            });
        }

        /**
         * 引数が1つの場合、エラーとなる
         */
        [TestMethod]
        public void testGreaterThan1Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new GreaterThan("1");
            });
        }

        /**
         * 引数が3つの場合、エラーとなる
         */
        [TestMethod]
        public void testGreaterThan3Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new GreaterThan("1", "2", "3");
            });
        }

        /**
         * 引数が数値でない場合、エラーとなる
         */
        [TestMethod]
        public void testGreaterThanWrongArgs()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new GreaterThan("a", "2");
            });

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new GreaterThan("1", "b");
            });
        }
    }
}
