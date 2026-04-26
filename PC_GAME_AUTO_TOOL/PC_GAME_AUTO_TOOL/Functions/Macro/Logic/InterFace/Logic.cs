using PC_GAME_AUTO_TOOL.Functions.Macro.Logic.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace
{
    /**
     * 比較演算子などの、bool値を返す処理を行うインターフェース
     */
    public interface Logic
    {
        /**
         * 比較演算子などの処理を実行してbool値を返す処理
         */
        public bool execute();
        /**
         * 引数全体を再セットする処理
         */
        public void setArgs(ArgMents argMents);
        /**
         * 引数を取得する処理
         */
        public ArgMents getArgs();
        /**
         * 引数を追加する処理(int型)
         */
        public void addArg(KeyValuePair<string, int> arg);
        /**
         * 引数を追加する処理(string型)
         */
        public void addArg(KeyValuePair<string, string> arg);
    }
}
