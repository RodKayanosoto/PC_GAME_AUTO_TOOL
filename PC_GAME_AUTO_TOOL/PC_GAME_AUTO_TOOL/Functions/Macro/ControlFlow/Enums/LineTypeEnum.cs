using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.Enums
{
    public static class LineTypeEnum
    {
        // スクリプトの行の大分類(通常コマンド、制御フローなど)を表す列挙型
        public enum LineType
        {

            /**
             * コマンドの行であることを表す値
             */
            Command,
            /**
             * 制御構文の行であることを表す値
             */
            ControlFlow,
            /**
             * どちらでもないことを表す値
             */
            Invalid
        }
    }
}
