using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace
{
    /**
     * マクロの1行分の命令コマンドのインターフェース
     */
    public interface MacroCommandInterface
    {
        /**
         * マクロの1行分の命令コマンドを実行するためのメソッド
         */
        public void Execute();
        /**
         * 命令コマンドの実行結果・返り値を取得するためのメソッド(実行結果が存在しないタイプのコマンドの場合はnullを返す)
         */
        public String? GetResult();
    }
}
