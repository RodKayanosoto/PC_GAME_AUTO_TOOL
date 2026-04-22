using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow
{
    public class NormalCommandBlock : CommandBlock
    {
        // コマンドブロック内のコマンドのリスト
        private List<CommandBlock> commands;
        // コンストラクタ
        public NormalCommandBlock()
        {
            this.commands = new List<CommandBlock>();
        }
        // 新しいコマンドを追加するためのメソッド
        public void AddCommand(MacroCommandInterface command) { }
        // 次のコマンドを取得するためのメソッド
        public MacroCommandInterface GetNextCommand()
        {
            return null;
        }
        // 次のコマンドが存在するかどうかを確認するためのメソッド
        public bool HasNextCommand()
        {
            return false;
        }

    }

}
