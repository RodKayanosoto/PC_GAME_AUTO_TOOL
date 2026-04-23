using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Command
{
    /**
     * IsFileTextContailsクラスは、ファイルのテキストが指定された文字列を含むかどうかを確認するためのコマンドクラスです。
     * このクラスは、MacroCommandInterfaceを実装しており、Executeメソッドを呼び出すことで、指定されたファイルのテキストが指定された文字列を含むかどうかを確認します。
     */
    public class IsFileTextContains : MacroCommandInterface
    {
        // 文字コード
        private Encoding encoding;
        // ファイルパス
        private string filePath;
        // 検査対象の文字列
        private string targetString;
        // ファイルのテキストが指定された文字列を含むかどうかの結果
        private bool result;

        /**
         * IsFileTextContailsクラスのコンストラクタ
         * 引数には、ファイルパスと検索する文字列を指定します。
         * 引数の数が不正な場合は、ArgumentExceptionをスローします。
         */
        public IsFileTextContains(params string[] args)
        {
            // 引数の数をチェックする
            if (args.Length != 3)
            {
                throw new ArgumentException(@"文字コード(""UTF-8"", ""SJIS""), ファイルパス, 検査対象の文字列の3つの引数を指定してください。");
            }

            // 文字コードを取得する
            string charCode = args[0];
            Encoding encoding;
            if ("UTF-8".Equals(charCode))
            {
                encoding = Encoding.UTF8;
            }
            else if ("SJIS".Equals(charCode))
            {
                EncodingProvider provider = CodePagesEncodingProvider.Instance;
                encoding = provider.GetEncoding("shift-jis");
            } else
            {
                throw new ArgumentException(@"文字コードは ""UTF-8"" または ""SJIS"" のいずれかを指定してください。");
            }

            // ファイルパスにファイルが存在することを確認する
            string filePath = args[1];
            if (!System.IO.File.Exists(filePath))
            {
                throw new ArgumentException($"ファイル '{filePath}' が存在しません。");
            }

            // 検査対象の文字列が空でないことを確認する
            string targetString = args[2];
            if (string.IsNullOrWhiteSpace(targetString))
            {
                throw new ArgumentException("検査対象の文字列が空です。検査対象の文字列を指定してください。");
            }

            // 文字コードを取得する
            this.encoding = encoding;
            // ファイルパスを取得する
            this.filePath = filePath;
            // 検査対象の文字列を取得する
            this.targetString = targetString;
        }

        /**
         * Executeメソッドは、指定されたファイルのテキストが指定された文字列を含むかどうかを確認します。
         * 結果は、GetResultメソッドで取得できます。
         */
        public void Execute()
        {
            // ファイルのテキストを読み取る
            string fileText = System.IO.File.ReadAllText(filePath, this.encoding);

            // ファイルのテキストが指定された文字列を含むかどうかを確認する
            if (fileText.Contains(targetString)) {
                this.result = true;
            } else {
                this.result = false;
            }
        }

        /**
         * GetResultメソッドは、Executeメソッドの実行結果を取得します。
         * "1":文字列が含まれている
         * "0":文字列が含まれていない
         */
        public String? GetResult()
        {
            if (this.result)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
    }
}
