using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PC_GAME_AUTO_TOOL.Functions;

namespace Test
{
    [TestClass]
    public sealed class GetScreenShotTest
    {
        /**
         * ゲーム画面のスクリーンショットを取得するテスト
         */
        [TestMethod]
        public void TestMethod1()
        {
            // PC_GAME_AUTO_TOOL.Functions.GetScreenShot.Capture()を実行する
            String result = PC_GAME_AUTO_TOOL.Functions.GetScreenShot.Capture();

            // 戻り値が存在することを確認する
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrWhiteSpace(result));

            // 戻り値のパスにファイルが存在することを確認する
            Assert.IsTrue(File.Exists(result));
        }
    }
}
