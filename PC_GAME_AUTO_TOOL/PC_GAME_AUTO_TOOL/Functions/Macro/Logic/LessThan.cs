using PC_GAME_AUTO_TOOL.Functions.Macro.Logic.Struct;
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
    public class LessThan : InterFace.Logic
    {
        private ArgMents argMents;

        public LessThan(int lineNum, params String[] args)
        {
            this.argMents = new ArgMents();
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
            this.argMents.addArg(new KeyValuePair<string, int>(lineNum.ToString() + "_arg1", int.Parse(arg1)));
            this.argMents.addArg(new KeyValuePair<string, int>(lineNum.ToString() + "_arg2", int.Parse(arg2)));
        }

        public LessThan(ArgMents arguments)
        {
            this.argMents = arguments;
        }

        /**
         * 処理を実行する
         */
        public bool execute()
        {
            return this.argMents.numericVariableList[0].Value < this.argMents.numericVariableList[1].Value;
        }

        /**
         * 引数全体を再セットする処理
         */
        public void setArgs(ArgMents argMents) { this.argMents = argMents; }
        /**
         * 引数を取得する処理
         */
        public ArgMents getArgs() { return this.argMents; }
        /**
         * 引数を追加する処理(int型)
         */
        public void addArg(KeyValuePair<string, int> arg) { this.argMents.addArg(arg); }
        /**
         * 引数を追加する処理(string型)
         */
        public void addArg(KeyValuePair<string, string> arg) { this.argMents.addArg(arg); }
    }
}
