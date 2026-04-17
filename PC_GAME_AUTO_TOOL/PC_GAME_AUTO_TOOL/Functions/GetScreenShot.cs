using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions
{
    /**
     * 画面キャプチャの取得を行うクラス
     */
    public static class GetScreenShot
    {
        /**
         * 画面キャプチャを取得し、保存するメソッド
         * @return 保存した画像のパス
         */
        public static String Capture()
        {
            // ファイルの保存先をこのexeのディレクトリのtempフォルダに指定する
            String baseDir = AppDomain.CurrentDomain.BaseDirectory;
            String tempDir = System.IO.Path.Combine(baseDir, "temp");
            String savePath = System.IO.Path.Combine(tempDir, "screenshot.png");

            // tempディレクトリが存在しない場合は作成
            Directory.CreateDirectory(tempDir);

            if (Screen.PrimaryScreen == null)
            {
                Console.WriteLine("Error: No primary screen detected.");
                return String.Empty;
            }

            // 画面キャプチャのサイズはプライマリスクリーンのサイズに合わせる
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

            // サイズを指定してBitmapオブジェクトを作成する
            using (Bitmap bitmap = new Bitmap(screenBounds.Width, screenBounds.Height))
            {
                // Graphicsオブジェクトを作成し、画面キャプチャをコピーする
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(
                        screenBounds.Left,
                        screenBounds.Top,
                        0,
                        0,
                        screenBounds.Size
                    );

                    bitmap.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
                }

            }
            // 保存した画像のパスを返す
            return savePath;
        }
    }
}
