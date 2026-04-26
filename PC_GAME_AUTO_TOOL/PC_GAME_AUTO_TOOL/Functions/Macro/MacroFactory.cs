using PC_GAME_AUTO_TOOL.Functions.Macro.Command;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.Enums;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.Enums;
using PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro
{
    /**
     * マクロのコマンドや制御フローコマンド等のインスタンスを生成するためのクラス
     */
    public static class MacroFactory
    {
        /**
         * 通常のコマンドのラインのインスタンスを作成するメソッド
         */
        public static LineInterFace createCommandLine(CommandEnum.CommandTypeEnum commandType, String[] args, int lineNo)
        {
            MacroCommandInterface command;
            switch (commandType)
            {
                case CommandEnum.CommandTypeEnum.CopyDirectory:
                    command = new CopyDirectory(args);
                    break;
                case CommandEnum.CommandTypeEnum.CopyFile:
                    command = new CopyFile(args);
                    break;
                case CommandEnum.CommandTypeEnum.PressKey:
                    command = new PressKey(args);
                    break;
                case CommandEnum.CommandTypeEnum.Start:
                    command = new Start(args);
                    break;
                case CommandEnum.CommandTypeEnum.Terminate:
                    command = new Terminate(args);
                    break;
                case CommandEnum.CommandTypeEnum.Wait:
                    command = new Wait(args);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new CommandLine(command, lineNo);
        }

        /**
         * 制御フローコマンドのラインのインスタンスを作成するメソッド
         */
        public static LineInterFace createControlFlowCommandLine(ControlFlowEnum.CFEnum controlFlowType, String[] args, int lineNo)
        {
            switch (controlFlowType)
            {
                case ControlFlowEnum.CFEnum.If:
                    return null;
                case ControlFlowEnum.CFEnum.EndIf:
                    return null;
                case ControlFlowEnum.CFEnum.Loop:
                    return null;
                case ControlFlowEnum.CFEnum.EndLoop:
                    return null;
            }
            //return new CommandLine(controlFlowCommand, lineNo);
            return null;
        }
    }
}
