using PC_GAME_AUTO_TOOL.Functions.Macro.Command.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.Line
{
    /**
     * 1行分のデータを取得するクラス
     */
    public class LineStract
    {
        /**
         * コマンドや制御分などメインの文字列
         */
        private String? mainStr;
        /**
         * 引数
         */
        private String[]? args;

        public String getMainStr()
        {
            if (String.IsNullOrWhiteSpace(mainStr))
            {
                return String.Empty;
            }
            return this.mainStr;
        }

        public String[] getArgs()
        {
            if (args == null)
            {
                return new String[0];
            }
            return this.args;
        }

        public LineStract(string line)
        {
            // 引数無しの場合は終了
            if (String.IsNullOrWhiteSpace(line))
            {
                return;
            }

            // 引数をtrimする
            string linebuf = line.Trim();


            // ";"以降はコメントとみなして削除する
            {
                int commentIndex = linebuf.IndexOf(';');
                if (commentIndex >= 0)
                {
                    linebuf = linebuf.Substring(0, commentIndex);
                }
            }

            // コメントしかなかった場合は終了
            if (String.IsNullOrWhiteSpace(linebuf))
            {
                return;
            }

            // 引数をスペースで分割した一番目をコマンド、として取得する
            this.mainStr = linebuf.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

            // 引数をスペースで分割した二番目以降を引数として取得する
            this.args = linebuf.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
        }
    }
}
