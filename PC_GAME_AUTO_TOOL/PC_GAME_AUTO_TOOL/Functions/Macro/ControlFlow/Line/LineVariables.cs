using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.Line
{
    /**
     * 1行分のデータを取得して、変数を作成するクラス
     */
    public class LineVariables
    {
        // 数値型の変数リスト　(変数名, 値)のキーバリューセット
        Dictionary<string, int> numericVariableDictionary;
        // 文字列型の変数リスト　(変数名, 値)のキーバリューセット
        Dictionary<string, string> stringVariableDictionary;

        // コンストラクタ
        public LineVariables(LineStract lineStract, int lineNum)
        {
            // 数値型の変数と文字列型の変数を初期化する
            this.numericVariableDictionary = new Dictionary<string, int>();
            this.stringVariableDictionary = new Dictionary<string, string>();

            // int宣言の場合
            if ("int".Equals(lineStract.getMainStr()))
            {
                // 変数の名称を取得する
                string variableName = lineStract.getArgs()[2];
                // 変数の初期値を格納する変数
                int defaultNum = 0;


                // 引数の数を取得する
                int argCnt = lineStract.getArgs().Length;

                // 引数の数が1,3以外の場合、例外をスローする(string a もしくは string a = 5 の形式であればOK)
                if (argCnt != 1 && argCnt != 3)
                {
                    throw new ArgumentException("int型変数の宣言に誤りがあります。");
                }


                // 引数の数が3の場合
                if (argCnt == 3)
                {
                    // 2つめの引数が"="以外の場合、エラー
                    if (lineStract.getArgs()[1] != "=")
                    {
                        throw new ArgumentException("int型変数の宣言に誤りがあります。");
                    }

                    // 3つめの引数が数値でない場合、エラー
                    if (!int.TryParse(lineStract.getArgs()[2], out defaultNum))
                    {
                        throw new ArgumentException("int型変数の宣言に誤りがあります。");
                    }
                }


                // int型変数を宣言する
                this.numericVariableDictionary.Add(variableName, defaultNum);
                return;
            }

            // string宣言の場合
            if ("string".Equals(lineStract.getMainStr()))
            {
                // 変数の名称を取得する
                string variableName = lineStract.getArgs()[2];
                // 変数の初期値を格納する変数
                string defaultStr = String.Empty;

                // 引数の数を取得する
                int argCnt = lineStract.getArgs().Length;

                // 引数の数が1,3以外の場合、例外をスローする(string b もしくは string b = "abc" の形式であればOK)
                if (argCnt != 1 && argCnt != 3)
                {
                    throw new ArgumentException("string型変数の宣言に誤りがあります。");
                }

                // 引数の数が3の場合
                if (argCnt == 3)
                {
                    // 2つめの引数が"="以外の場合、エラー
                    if (lineStract.getArgs()[1] != "=")
                    {
                        throw new ArgumentException("string型変数の宣言に誤りがあります。");
                    }

                    // 3つめの引数を変数の初期値として取得する
                    defaultStr = lineStract.getArgs()[2];
                }

                // string型変数を宣言する
                this.stringVariableDictionary.Add(variableName, defaultStr);
                return;
            }

            // loopの場合(loop回数を変数名として持つ)
            if ("loop".Equals(lineStract.getMainStr()))
            {
                // 変数の名称を取得する
                string variableName = "loopCnt_" + lineNum.ToString();
                // 変数の初期値を格納する変数
                int defaultNum = 0;

                // 引数の数を取得する
                int argCnt = lineStract.getArgs().Length;

                // 引数の数が1以外である場合、例外をスローする(loop 5 のような形式であればOK)
                if (argCnt != 1)
                {
                    throw new ArgumentException("loopの回数の指定に誤りがあります。");
                }

                // 引数が数値でない場合、例外をスローする
                if (int.TryParse(lineStract.getArgs()[0], out defaultNum))
                {
                    throw new ArgumentException("loopの回数の指定に誤りがあります。");
                }

                // int型変数を宣言する
                this.numericVariableDictionary.Add(variableName, defaultNum);
                return;
            }
        }
    }
}
