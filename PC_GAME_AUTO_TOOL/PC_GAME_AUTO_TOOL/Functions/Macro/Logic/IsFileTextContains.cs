using PC_GAME_AUTO_TOOL.Functions.Macro.Logic.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Logic
{
    /**
     * IsFileTextContailsクラスは、ファイルのテキストが指定された文字列を含むかどうかを確認するためのコマンドクラスです。
     * このクラスは、MacroCommandInterfaceを実装しており、Executeメソッドを呼び出すことで、指定されたファイルのテキストが指定された文字列を含むかどうかを確認します。
     */
    public class IsFileTextContains : InterFace.Logic
    {
        private ArgMents argMents;

        /**
         * IsFileTextContailsクラスのコンストラクタ
         * 引数には、ファイルパスと検索する文字列を指定します。
         * 引数の数が不正な場合は、ArgumentExceptionをスローします。
         */
        public IsFileTextContains(int lineNum, params string[] args)
        {
            this.argMents = new ArgMents();
            // 引数の数をチェックする
            if (args.Length != 3)
            {
                throw new ArgumentException(@"文字コード(""UTF-8"", ""SJIS""), ファイルパス, 検査対象の文字列の3つの引数を指定してください。");
            }

            // 文字コードをチェックする
            string charCode = args[0];
            if (!"UTF-8".Equals(charCode) && !"SJIS".Equals(charCode))
            {
                throw new ArgumentException(@"文字コードは ""UTF-8"" または ""SJIS"" のいずれかを指定してください。");
            }

            // ファイルパスにファイルが存在することを確認する
            string filePath = args[1];
            if (!File.Exists(filePath))
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
            this.argMents.addArg(new KeyValuePair<string, string>(lineNum.ToString() + "_charCode", charCode));

            // ファイルパスを取得する
            this.argMents.addArg(new KeyValuePair<string, string>(lineNum.ToString() + "_filePath", filePath));

            // 検査対象の文字列を取得する
            this.argMents.addArg(new KeyValuePair<string, string>(lineNum.ToString() + "_targetString", targetString));
        }

        public IsFileTextContains(ArgMents arguments)
        {
            this.argMents = arguments;
        }

        /**
         * Executeメソッドは、指定されたファイルのテキストが指定された文字列を含むかどうかを確認します。
         * 結果は、GetResultメソッドで取得できます。
         */
        public bool execute()
        {
            string charCode = this.argMents.stringVariableList[0].Value;
            string filePath = this.argMents.stringVariableList[1].Value;
            string targetString = this.argMents.stringVariableList[2].Value;

            // 文字コードを取得する
            Encoding encoding;
            if ("UTF-8".Equals(charCode))
            {
                encoding = Encoding.UTF8;
            }
            else if ("SJIS".Equals(charCode))
            {
                EncodingProvider provider = CodePagesEncodingProvider.Instance;
                encoding = provider.GetEncoding("shift-jis");
            }
            else
            {
                throw new ArgumentException(@"文字コードは ""UTF-8"" または ""SJIS"" のいずれかを指定してください。");
            }

            // ファイルのテキストを読み取る
            string fileText = File.ReadAllText(filePath, encoding);

            // ファイルのテキストが指定された文字列を含むかどうかを確認する
            if (fileText.Contains(targetString)) {
                return true;
            } else {
                return false;
            }
        }

        /**
         * 引数全体を再セットする処理
         */
        public void setArgs(ArgMents argMents) { this.argMents = argMents; }
        /**
         * 引数を取得する処理
         */
        public ArgMents getArgs() { return this.argMents; }
        /**
         * 引数を追加する処理(int型)
         */
        public void addArg(KeyValuePair<string, int> arg) { this.argMents.addArg(arg); }
        /**
         * 引数を追加する処理(string型)
         */
        public void addArg(KeyValuePair<string, string> arg) { this.argMents.addArg(arg); }
    }
}
