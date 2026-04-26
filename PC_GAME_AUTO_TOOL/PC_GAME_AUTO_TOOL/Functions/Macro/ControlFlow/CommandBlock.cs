using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow.InterFace;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.ControlFlow
{
    public class CommandBlock : InterFace.CommandBlock
    {
        // 数値型の変数リスト　(変数名, 値)のキーバリューセット
        Dictionary<string, int> numericVariableDictionary;
        // 文字列型の変数リスト　(変数名, 値)のキーバリューセット
        Dictionary<string, string> stringVariableDictionary;

        // コマンドブロック内のコマンドのリスト
        private List<ControlFlow.Schema.Line> commands;
        // コンストラクタ
        public CommandBlock()
        {
            this.numericVariableDictionary = new Dictionary<string, int>();
            this.stringVariableDictionary = new Dictionary<string, string>();
        }
        // 新しいコマンドを追加するためのメソッド
        public void AddCommand(MacroCommandInterface command) { }
        // 次のコマンドを取得するためのメソッド
        public MacroCommandInterface GetNextCommand()
        {
            return null;
        }
        // 次のコマンドが存在するかどうかを確認するためのメソッド
        public bool HasNextCommand()
        {
            return false;
        }

        /**
         * 数値型の変数を追加するためのメソッド
         * @param variableName 変数名
         * @param value 変数の値
         */
        public void addNumericVariable(string variableName, int value)
        {
            // 変数名が既に存在する場合は例外をスロー
            if (this.numericVariableDictionary.ContainsKey(variableName))
            {
                throw new InvalidOperationException($"数値型の変数 '{variableName}' は既に存在しています。");
            }

            // 変数を追加
            this.numericVariableDictionary.Add(variableName, value);
        }

        /**
         * 文字列型の変数を追加するためのメソッド
         * @param variableName 変数名
         * @param value 変数の値
         */
        public void addStringVariable(string variableName, string value)
        {
            // 変数名が既に存在する場合は例外をスロー
            if (this.stringVariableDictionary.ContainsKey(variableName))
            {
                throw new InvalidOperationException($"文字列型の変数 '{variableName}' は既に存在しています。");
            }
            // 変数を追加
            this.stringVariableDictionary.Add(variableName, value);
        }

        /**
         * 数値型の変数の値を取得するためのメソッド
         * @param variableName 変数名
         * @return 変数の値
         */
        public int getNumericVariable(string variableName)
        {
            // 変数名が存在しない場合は例外をスロー
            if (!this.numericVariableDictionary.ContainsKey(variableName))
            {
                throw new InvalidOperationException($"数値型の変数 '{variableName}' は存在しません。");
            }
            // 変数の値を返す
            return this.numericVariableDictionary[variableName];
        }

        /**
         * 文字列型の変数の値を取得するためのメソッド
         * @param variableName 変数名
         * @return 変数の値
         */
        public string getStringVariable(string variableName)
        {
            // 変数名が存在しない場合は例外をスロー
            if (!this.stringVariableDictionary.ContainsKey(variableName))
            {
                throw new InvalidOperationException($"文字列型の変数 '{variableName}' は存在しません。");
            }
            // 変数の値を返す
            return this.stringVariableDictionary[variableName];
        }
    }

}
