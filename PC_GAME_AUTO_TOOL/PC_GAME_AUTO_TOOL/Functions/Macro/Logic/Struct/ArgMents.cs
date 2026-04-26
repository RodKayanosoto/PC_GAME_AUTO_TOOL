using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Logic.Struct
{
    public class ArgMents
    {
        // 数値型の変数リスト　(変数名, 値)のキーバリューセット
        public List<KeyValuePair<string, int>> numericVariableList;
        // 文字列型の変数リスト　(変数名, 値)のキーバリューセット
        public List<KeyValuePair<string, string>> stringVariableList;

        public ArgMents()
        {
                numericVariableList = new List<KeyValuePair<string, int>>();
                stringVariableList = new List<KeyValuePair<string, string>>();
        }

        public ArgMents(List<KeyValuePair<string, int>> numericVariableList, List<KeyValuePair<string, string>> stringVariableList)
        {
            this.numericVariableList = numericVariableList;
            this.stringVariableList = stringVariableList;
        }

        /**
         * 引数を追加する処理(int型)
         * 既に同じキーが存在する場合は、値を更新する
         * 同じキーが存在しない場合は、新しいキーと値のペアを追加する
         */
        public void addArg(KeyValuePair<string, int> arg)
        {
            if (numericVariableList.Any(kv => kv.Key == arg.Key))
            {
                // 既に同じキーが存在する場合は、値を更新する
                int index = numericVariableList.FindIndex(kv => kv.Key == arg.Key);
                numericVariableList[index] = arg;
            }
            else
            {
                // 同じキーが存在しない場合は、新しいキーと値のペアを追加する
                numericVariableList.Add(arg);
            }
        }

        /**
         * 引数を追加する処理(string型)
         * 既に同じキーが存在する場合は、値を更新する
         * 同じキーが存在しない場合は、新しいキーと値のペアを追加する
         */
        public void addArg(KeyValuePair<string, string> arg)
        {
            if (stringVariableList.Any(kv => kv.Key == arg.Key))
            {
                // 既に同じキーが存在する場合は、値を更新する
                int index = stringVariableList.FindIndex(kv => kv.Key == arg.Key);
                stringVariableList[index] = arg;
            }
            else
            {
                // 同じキーが存在しない場合は、新しいキーと値のペアを追加する
                stringVariableList.Add(arg);
            }
        }
    }
}
