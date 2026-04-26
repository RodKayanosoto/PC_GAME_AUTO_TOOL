using PC_GAME_AUTO_TOOL.Functions.Macro.Command;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.Enums;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.Enums;
using PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.Line;

namespace PC_GAME_AUTO_TOOL.Functions.Macro
{
    public static class ReadLine
    {
        /**
         * 引数の文字列が制御構文であるかコマンドであるかを判定する関数
         * 制御構文であれば0、コマンドであれば1、どちらでもなければ-1を返す
         */
        public static LineTypeEnum.LineType checkLineType(String command)
        {
            // 引数無しの場合は無効
            if (String.IsNullOrEmpty(command))
            {
                return LineTypeEnum.LineType.Invalid;
            }

            String commandBuf = command.Trim();

            // コマンドであるかどうかを確認する
            if (Enum.TryParse(commandBuf, true, out CommandEnum.CommandTypeEnum _))
            {
                return LineTypeEnum.LineType.Command;
            }

            // 制御構文であるかどうかを確認する
            if (Enum.TryParse(commandBuf, true, out ControlFlowEnum.CFEnum _))
            {
                return LineTypeEnum.LineType.ControlFlow;
            }


            // どちらでもない場合は無効
            return LineTypeEnum.LineType.Invalid;
        }

        /**
         * スクリプト1行分のLineInterFaceインスタンスを作成する関数
         * lineはスクリプトの1行分
         */
        private static LineInterFace? parseLine(LineStract lineStract, int lineNo)
        {
            // コマンドの文字列を取得する
            String commandBuf = lineStract.getMainStr();

            // コマンドの文字列を取得できない場合は無効な行とみなす
            if (String.IsNullOrEmpty(commandBuf))
            {
                return null;
            }

            // 引数を取得する
            String[] argsBuf = lineStract.getArgs();

            // コマンドのタイプを判定する
            LineTypeEnum.LineType lineType = checkLineType(commandBuf);

            // コマンドの種類ごとにインスタンスを作成する
            switch (lineType)
            {
                case LineTypeEnum.LineType.Command:
                    // 通常のコマンドの場合
                    // コマンドの種類を取得する
                    CommandEnum.CommandTypeEnum commandType = Enum.Parse<CommandEnum.CommandTypeEnum>(commandBuf, true);
                    // コマンドのインスタンスを作成する
                    return MacroFactory.createCommandLine(commandType, argsBuf, lineNo);
                case LineTypeEnum.LineType.ControlFlow:
                    // 制御フローの場合
                    // 制御フローの種類を取得する
                    ControlFlowEnum.CFEnum controlFlowType = Enum.Parse<ControlFlowEnum.CFEnum>(commandBuf, true);
                    // TODO:処理は未作成
                    return null;
                case LineTypeEnum.LineType.Invalid:
                    // 無効な行の場合
                    throw new ArgumentException($"エラー: {lineNo}行目は無効な行です。");
            }

            return null;
        }
    }
}

