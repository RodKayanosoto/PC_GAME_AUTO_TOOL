using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Resources
{
    /**
     * テストで使用するファイルのパスを定義するクラス
     */
    public static class TestResourcePaths
    {
        /**
         * テスト実行時のベースディレクトリ
         */
        public static string BaseDir()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /**
         * テストで使用するResourcesディレクトリのパス
         */
        public static string ResourcesDir()
        {
            return Path.Combine(BaseDir(), "Resources");
        }

        /**
         * テストで使用するリソースファイルのパス
         */
        public static string ResourceFilePath(string fileName)
        {
            return Path.Combine(ResourcesDir(), fileName);
        }

        /**
         * テストで使用するExeディレクトリのパス
         */
        public static string ExeDir()
        {
            return Path.Combine(ResourcesDir(), "Exe");
        }

        /**
         * テストで使用するexeファイルのパス
         */
        public static string ExePath(string fileName)
        {
            return Path.Combine(ExeDir(), fileName);
        }

        /**
         * テストで使用するFileディレクトリのパス
         */
        public static string FileDir()
        {
            return Path.Combine(ResourcesDir(), "File");
        }

        /**
         * テストで使用するexeファイルのパス
         */
        public static string FilePath(string fileName)
        {
            return Path.Combine(FileDir(), fileName);
        }
    }
}
