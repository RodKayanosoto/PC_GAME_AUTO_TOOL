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
    public interface LineInterFace
    {
        /**
         * 通常の場合の次の行番号を登録するSetterメソッド
         */
        public void setNextLineNumber(int nextLineNumber);

        /**
         * 特殊な場合の次の行番号を登録するSetterメソッド
         */
        public void setAnotherNextLineNumber(int anotherNextLineNumber);

        /**
         * 次の行番号を取得するためのメソッド
         */
        public int getNextLineNumber(bool isTrue);
    }
}
