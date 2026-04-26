using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.Enums;

/**
 * コマンドの行を表す構造体
 * コマンドの行番号とコマンドの内容を保持する
 */
namespace PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.Line
{
    public class CommandLine : LineInterFace
    {
        // コマンドの内容 ※IFやLOOP等の制御フローコマンドの場合はnullとする
        private MacroCommandInterface command;
        // コマンドの行番号
        private int lineNumber;
        // 通常の場合の次の行番号(IF分の場合はtrueの分岐、LOOPの場合はループ続行の分岐)
        private int nextLineNumber;
        // 特殊な場合の次の行番号(IF分の場合はfalseの分岐、LOOPの場合はループ終了の分岐)
        private int anotherNextLineNumber;

        /**
         * コンストラクタ
         * @param command コマンドの内容
         * @param lineNumber コマンドの行番号
         */
        public CommandLine(MacroCommandInterface command, int lineNumber)
        {
            // コマンドの内容と行番号を初期化
            this.command = command;
            this.lineNumber = lineNumber;

            // 次の行番号を-1で初期化
            this.nextLineNumber = -1;
            this.anotherNextLineNumber = -1;
        }

        /**
         * 通常の場合の次の行番号を登録するSetterメソッド
         */
        public void setNextLineNumber(int nextLineNumber)
        {
            this.nextLineNumber = nextLineNumber;
        }

        /**
         * 特殊な場合の次の行番号を登録するSetterメソッド
         */
        public void setAnotherNextLineNumber(int anotherNextLineNumber)
        {
            this.anotherNextLineNumber = anotherNextLineNumber;
        }

        /**
         * 次の行番号を取得するためのメソッド
         */
        public int getNextLineNumber(bool isTrue) {
            // 通常の場合の行番号が設定されていない場合は例外をスロー
            if (this.nextLineNumber == -1)
            {
                throw new InvalidOperationException("次の行番号が設定されていません。");
            }

            // isTrueがfalseかつ特殊な場合の行番号が設定されていない場合は例外をスロー
            if (!isTrue && this.anotherNextLineNumber == -1)　{
                throw new InvalidOperationException("特殊な場合の次の行番号が設定されていません。");
            }

            // 次の行番号を返す
            if (isTrue)
            {
                // 通常の場合の行番号を返す
                return this.nextLineNumber;
            }
            else
            {
                // 特殊な場合の行番号を返す
                return this.anotherNextLineNumber;
            }
        }
    }
}
