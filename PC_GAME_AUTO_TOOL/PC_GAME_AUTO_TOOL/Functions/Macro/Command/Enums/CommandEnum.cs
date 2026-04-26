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
            /**
             * フォルダをサブディレクトリごとコピーするコマンドを表す値
             */
            CopyDirectory,
            /**
             * ファイルをコピーするコマンドを表す値
             */
            CopyFile,
            /**
             * キーボードのキーを押すコマンドを表す値
             */
            PressKey,
            /**
             * EXEファイルを指定して起動するコマンドを表す値
             */
            Start,
            /**
             * EXEファイルを指定してプロセスを終了するコマンドを表す値
             */
            Terminate,
            /**
            * 一定時間処理を停止するコマンドを表す値(ミリ秒)
            */
            Wait
        }
    }
}
