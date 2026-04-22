using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Command.Enums
{
    public static class CommandEnum
    {
        // コマンドの一覧のenum
        public enum CommandTypeEnum
        {
            CopyDirectory,
            CopyFile,
            PressKey,
            Start,
            Wait
        }
    }
}
