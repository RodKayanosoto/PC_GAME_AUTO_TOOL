using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Command
{
    /**
     * CopyDirectoryクラスは、ディレクトリをコピーするためのコマンドクラスです。
     * このクラスは、MacroCommandInterfaceを実装しており、Executeメソッドを呼び出すことで、指定されたディレクトリをコピーします。
     */
    public class CopyDirectory : MacroCommandInterface
    {
        // コピー元のディレクトリパス
        private string sorceDirectoryPath;
        // コピー先のディレクトリ名
        private string destinationDirectoryPath;

        /**
         * CopyDirectoryクラスのコンストラクタ
         * 引数には、コピー元のディレクトリパスとコピー先のディレクトリ名を指定します。
         * 引数の数が不正な場合は、ArgumentExceptionをスローします。
         */
        public CopyDirectory(params string[] args)
        {
            // 引数の数をチェックする
            if (args.Length == 0 || args.Length == 1)
            {
                throw new ArgumentException("引数が不足しています。コピー元とコピー先のディレクトリパスを指定してください。");
            }
            else if (args.Length > 2)
            {
                throw new ArgumentException("引数が多すぎます。コピー元とコピー先のディレクトリパスのみを指定してください。");
            }

            // コピー元のディレクトリパス
            string sorceDirectoryPath = args[0];
            // コピー先のディレクトリ名
            string destinationDirectoryPath = args[1];

            // コピー先のディレクトリがコピー元のディレクトリと同じでないことを確認する
            if (System.IO.Path.GetFullPath(sorceDirectoryPath) == System.IO.Path.GetFullPath(destinationDirectoryPath))
            {
                throw new ArgumentException("コピー元とコピー先のディレクトリパスが同じです。異なるディレクトリパスを指定してください。");
            }

            // コピー元のディレクトリが存在することを確認する
            if (!System.IO.Directory.Exists(sorceDirectoryPath))
            {
                throw new ArgumentException($"コピー元のディレクトリ '{sorceDirectoryPath}' が存在しません。");
            }

            // コピー先のディレクトリの親ディレクトリが存在することを確認する
            {
                string destinationParentDirectoryPath = System.IO.Path.GetDirectoryName(destinationDirectoryPath);
                if (!System.IO.Directory.Exists(destinationParentDirectoryPath))
                {
                    throw new ArgumentException($"コピー先のディレクトリの親ディレクトリ '{destinationParentDirectoryPath}' が存在しません。");
                }
            }

            // コピー先のディレクトリが既に存在する場合は、ディレクトリを削除する
            if (System.IO.Directory.Exists(destinationDirectoryPath))
            {
                System.IO.Directory.Delete(destinationDirectoryPath, true);
            }

            // コピー元のディレクトリパス
            this.sorceDirectoryPath = sorceDirectoryPath;
            // コピー先のディレクトリ名
            this.destinationDirectoryPath = destinationDirectoryPath;
        }

        /**
         * Executeメソッドは、コピー元のディレクトリをコピー先のディレクトリにコピーします。
         * コピー先のディレクトリが存在する場合は、上書きされます。
         */
        public void Execute()
        {
            // コピー元存在確認
            if (!Directory.Exists(this.sorceDirectoryPath))
            {
                throw new DirectoryNotFoundException(
                    $"コピー元ディレクトリが存在しません: {this.sorceDirectoryPath}");
            }

            // コピー先ディレクトリ作成
            Directory.CreateDirectory(this.destinationDirectoryPath);

            // サブディレクトリ（空フォルダ含む）を作成
            foreach (string sourceDir in Directory.GetDirectories(
                this.sorceDirectoryPath,
                "*",
                SearchOption.AllDirectories))
            {
                string relativePath =
                    Path.GetRelativePath(this.sorceDirectoryPath, sourceDir);

                string destinationDir =
                    Path.Combine(this.destinationDirectoryPath, relativePath);

                Directory.CreateDirectory(destinationDir);
            }

            // 全ファイルコピー
            foreach (string sourceFile in Directory.GetFiles(
                this.sorceDirectoryPath,
                "*",
                SearchOption.AllDirectories))
            {
                string relativePath =
                    Path.GetRelativePath(this.sorceDirectoryPath, sourceFile);

                string destinationFile =
                    Path.Combine(this.destinationDirectoryPath, relativePath);

                string? destinationDir =
                    Path.GetDirectoryName(destinationFile);

                if (!string.IsNullOrEmpty(destinationDir))
                {
                    Directory.CreateDirectory(destinationDir);
                }

                File.Copy(sourceFile, destinationFile, true);
            }
        }

        /**
         * このコマンドは実行結果が存在しないタイプのコマンドであるため、nullを返します。
         */
        public String? GetResult() {
            return null;
        }
    }
}
