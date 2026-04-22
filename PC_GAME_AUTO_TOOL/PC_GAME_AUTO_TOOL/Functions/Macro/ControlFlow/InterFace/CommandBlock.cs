using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.InterFace
{
    /**
     * ループや条件分岐などの制御フローを実装するためのインターフェースです。
     * 以下の要素を実装します
     * ・次のコマンドを取得するメソッド
     * ・次のコマンドが存在するかどうかを確認するメソッド
     */
    public interface CommandBlock
    {
        // 新しいコマンドを追加するためのメソッド
        public void AddCommand(MacroCommandInterface command);
        // 次のコマンドを取得するためのメソッド
        public MacroCommandInterface GetNextCommand();
        // 次のコマンドが存在するかどうかを確認するためのメソッド
        public bool HasNextCommand();
    }
}
