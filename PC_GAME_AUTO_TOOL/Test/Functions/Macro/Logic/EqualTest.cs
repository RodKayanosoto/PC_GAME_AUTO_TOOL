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
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal("-1", "-1");
                Assert.IsTrue(command.execute());
            }

            // 値が一致する場合はtrueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal("0", "0");
                Assert.IsTrue(command.execute());
            }

            // 値が一致する場合はtrueとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal("1", "1");
                Assert.IsTrue(command.execute());
            }

            // 値が一致しない場合はfalseとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal("1", "0");
                Assert.IsFalse(command.execute());
            }

            // 値が一致しない場合はfalseとなることを確認する
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal("0", "1");
                Assert.IsFalse(command.execute());
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
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal();
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
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal("1");
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
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal("1", "2", "3");
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
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal("a", "2");
            });

            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new Equal("1", "b");
            });
        }
    }
}
