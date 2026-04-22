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

namespace PC_GAME_AUTO_TOOL.Functions.Macro
{
    public static class ReadLine
    {
        /**
         * 引数の文字列が制御構文であるかコマンドであるかを判定する関数
         * 制御構文であれば0、コマンドであれば1、どちらでもなければ-1を返す
         */
        public static int? checkLineType(String line)
        {
            // 引数無しの場合はnullを返す
            if (String.IsNullOrEmpty(line))
            {
                return -1;
            }

            // スペースとタブしかない場合、nullを返す
            if ("".Equals(line.Trim()))
            {
                return -1;
            }

            // 引数をtrimしてスペースで分割する
            String[] args = parseLine(line);

            // 制御構文であるかどうかを確認する
            if (Enum.TryParse(args[0], true, out ControlFlowEnum.CFEnum _))
            {
                return 0;
            }

            // コマンドであるかどうかを確認する
            if (Enum.TryParse(args[0], true, out CommandEnum.CommandTypeEnum _))
            {
                return 1;
            }

            return -1;
        }

        /**
         * 引数の文字列がコマンドであると仮定して、対応するコマンドクラスのインスタンスを生成して返す関数
         * コマンドでない場合は例外をスローする
         */
        public static MacroCommandInterface parseCommand(String line)
        {
            String[] args = parseLine(line);

            // コマンドでない場合は例外をスローする
            if (!Enum.TryParse(args[0], true, out CommandEnum.CommandTypeEnum _))
            {
                throw new ArgumentException("エラー: コマンドではありません。");
            }

            // コマンドの種類を取得する
            CommandEnum.CommandTypeEnum commandType = Enum.Parse<CommandEnum.CommandTypeEnum>(args[0], true);

            // コマンドの引数を取得する
            String[] commandArgs = args.Skip(1).ToArray();
            // コマンドの種類に応じて、対応するコマンドクラスのインスタンスを生成して返す
            switch (commandType)
            {
                case CommandEnum.CommandTypeEnum.CopyDirectory:
                    return new CopyDirectory(commandArgs);
                case CommandEnum.CommandTypeEnum.CopyFile:
                    return new CopyFile(commandArgs);
                case CommandEnum.CommandTypeEnum.PressKey:
                    return new PressKey(commandArgs);
                case CommandEnum.CommandTypeEnum.Start:
                    return new Start(commandArgs);
                case CommandEnum.CommandTypeEnum.Wait:
                    return new Wait(commandArgs);
                default:
                    throw new ArgumentException("エラー: 不正なコマンドです。");
            }
        }

        /**
         * 引数の文字列が制御構文であると仮定して、対応する制御構文クラスのインスタンスを生成して返す関数
         * 制御構文でない場合は例外をスローする
         */
        public static CommandBlock parseControlFlow(String line)
        {
            String[] args = parseLine(line);
            // 制御構文でない場合は例外をスローする
            if (!Enum.TryParse(args[0], true, out ControlFlowEnum.CFEnum _))
            {
                throw new ArgumentException("エラー: 制御構文ではありません。");
            }
            // 制御構文の種類を取得する
            ControlFlowEnum.CFEnum controlFlowType = Enum.Parse<ControlFlowEnum.CFEnum>(args[0], true);
            // 制御構文の引数を取得する
            String[] controlFlowArgs = args.Skip(1).ToArray();
            // 制御構文の種類に応じて、対応する制御構文クラスのインスタンスを生成して返す
            switch (controlFlowType)
            {
                case ControlFlowEnum.CFEnum.If:
                    return null;
                case ControlFlowEnum.CFEnum.Loop:
                    return null;
                default:
                    throw new ArgumentException("エラー: 不正な制御構文です。");
            }
        }

        /**
         * 引数の文字列をスペースで分割して返す関数
         */
        private static String[] parseLine(String line)
        {
            // 引数をtrimしてスペースで分割する
            String[] args = line.Trim().Split(' ');
            return args;
        }
    }
}

