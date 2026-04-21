using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Command
{
    /**
     * 指定された時間だけ待機するコマンド
     */
    public class Wait : MacroCommandInterface
    {
        // 待機する時間（ミリ秒）
        private int waitTime;

        public Wait(params String[] args)
        {
            int waitTime;

            // 引数チェック
            if (args.Length != 1)
            {
                throw new ArgumentException("エラー: 待機時間は1つの引数で指定してください。");
            }
            if (!int.TryParse(args[0], out waitTime))
            {
                throw new ArgumentException("エラー: 待機時間は整数で指定してください。");
            }
            if (waitTime <= 0)
            {
                throw new ArgumentException("エラー: 待機時間は正の数で指定してください。");
            }

            this.waitTime = waitTime;
        }

        /**
         * 指定されたファイルを起動する
         */
        public void Execute()
        {
            // 指定された時間だけ待機する
            System.Threading.Thread.Sleep(waitTime);
        }

        /**
         * このコマンドは実行結果が存在しないタイプのコマンドであるため、nullを返します。
         */
        public String? GetResult()
        {
            return null;
        }
    }
}
