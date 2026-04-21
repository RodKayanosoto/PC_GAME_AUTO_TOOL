using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Command
{
    /**
     * ファイルをコピーするコマンド
     * 既存のファイルが存在する場合は上書きする
     */
    public class CopyFile : MacroCommandInterface
    {
        // コピー元のファイルのパス
        private string sourcePath;
        // コピー先のファイルのパス
        private string destinationPath;

        /**
         * コンストラクタ
         * 引数の1つ目にコピー元のファイルのパス、2つ目にコピー先のファイルのパスを指定する
         */
        public CopyFile(params String[] args)
        {
            // 引数の数が2以外である場合は例外をスローする
            if (args.Length != 2)
            {
                throw new ArgumentException("エラー: コピー元とコピー先のパスを指定してください。");
            }
            // コピー元のファイルが存在しない場合は例外をスローする
            if (!System.IO.File.Exists(args[0]))
            {
                throw new FileNotFoundException($"エラー: コピー元のファイル '{args[0]}' が存在しません。");
            }

            this.sourcePath = args[0];
            this.destinationPath = args[1];
        }

        /**
         * 指定されたファイルをコピーする
         */
        public void Execute()
        {
            System.IO.File.Copy(this.sourcePath, this.destinationPath, true);
        }

        /**
         * このコマンドは実行結果が存在しないタイプのコマンドであるため、nullを返します。
         */
        public String? GetResult()
        {
            return null;
        }
    }
}
