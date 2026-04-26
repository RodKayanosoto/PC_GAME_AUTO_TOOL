using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Logic
{
    /**
     * 「==」「<」「>」等の比較演算を行うクラス
     */
    public class LessThanOrEqual : InterFace.Logic
    {
        private int arg1;
        private int arg2;

        public LessThanOrEqual(params String[] args)
        {
            // 引数が2つでない場合、例外をスローする
            if (args.Length != 2)
            {
                throw new ArgumentException("== 演算の引数は2つ必要です。");
            }

            string arg1 = args[0];
            string arg2 = args[1];

            // 引数が数値でない場合、例外をスローする
            if (!int.TryParse(arg1, out _) || !int.TryParse(arg2, out _))
            {
                throw new ArgumentException("== 演算の引数は数値である必要があります。");
            }

            // 引数を受け取る
            this.arg1 = int.Parse(arg1);
            this.arg2 = int.Parse(arg2);
        }

        /**
         * 処理を実行する
         */
        public bool execute()
        {
            return this.arg1 <= this.arg2;
        }
    }
}
