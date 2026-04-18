using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command;

namespace Test.Functions.Macro.Command
{
    [TestClass]
    public class WaitTest
    {
        /**
         * 2000ミリ秒待機するテスト
         */
        [TestMethod]
        public void TestWait2000()
        {
            // 待機時間を指定する
            int waitTime = 2000;
            // 待機コマンドを実行する
            MacroCommandInterface command = new Wait(waitTime.ToString());
            DateTime startTime = DateTime.Now;
            command.Execute();
            DateTime endTime = DateTime.Now;
            // 実際の待機時間が指定した待機時間に近いことを確認する
            TimeSpan actualWaitTime = endTime - startTime;
            Assert.IsTrue(Math.Abs((actualWaitTime.TotalMilliseconds - waitTime)) < 100, $"エラー: 待機時間が指定した値から大きく乖離しています。 実際の待機時間: {actualWaitTime.TotalMilliseconds} ms");
        }

        /**
         * 1ミリ秒待機するテスト
         */
        [TestMethod]
        public void TestWait1()
        {
            // 待機時間を指定する
            int waitTime = 2000;
            // 待機コマンドを実行する
            MacroCommandInterface command = new Wait(waitTime.ToString());
            DateTime startTime = DateTime.Now;
            command.Execute();
            DateTime endTime = DateTime.Now;
            // 実際の待機時間が指定した待機時間に近いことを確認する
            TimeSpan actualWaitTime = endTime - startTime;
            Assert.IsTrue(Math.Abs((actualWaitTime.TotalMilliseconds - waitTime)) < 100, $"エラー: 待機時間が指定した値から大きく乖離しています。 実際の待機時間: {actualWaitTime.TotalMilliseconds} ms");
        }

        /**
         * 異常系：0ミリ秒待機
         */
        [TestMethod]
        public void ErrTestWait0()
        {
            // 待機時間を指定する
            const string waitTime = "0";
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new Wait(waitTime);
            });
        }

        /**
         * 異常系：-1ミリ秒待機
         */
        [TestMethod]
        public void ErrTestWaitMinus1()
        {
            // 待機時間を指定する
            const string waitTime = "-1";
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new Wait(waitTime);
            });
        }

        /**
         * 異常系：引数を文字にする
         */
        [TestMethod]
        public void ErrTestWaitStr()
        {
            // 待機時間を指定する
            const string waitTime = "12c4";
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new Wait(waitTime);
            });
        }

        /**
         * 異常系：コンストラクタの引数が空
         */
        [TestMethod]
        public void ErrTestWaitNoArg()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new Wait();
            });
        }

        /**
         * 異常系：コンストラクタの引数が2つ以上
         */
        [TestMethod]
        public void ErrTestWait2Args()
        {
            // コンストラクタで例外がスローされることを確認する
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MacroCommandInterface command = new Wait("1", "2");
            });
        }
    }
}
