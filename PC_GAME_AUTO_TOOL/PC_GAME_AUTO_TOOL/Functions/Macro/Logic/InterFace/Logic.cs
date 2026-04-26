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
    }
}
