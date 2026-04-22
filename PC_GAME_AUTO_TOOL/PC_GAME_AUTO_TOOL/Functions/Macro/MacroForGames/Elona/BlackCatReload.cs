using PC_GAME_AUTO_TOOL.Functions.Macro.Command.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.MacroForGames.Elona
{
    public static class BlackCatReload
    {
        // ゲーム開始
        public static void DoMacro()
        {
            // 黒猫エンチャント成功回数
            int successCount = 0;
            // 総試行回数
            int totalCount = 0;

            // 黒猫エンチャントの成功回数の上限
            const int maxSuccessCount = 100;
            // 黒猫エンチャントの総試行回数の上限
            const int maxTotalCount = 10000;

            // 現在の装備情報ファイルのパス
            const String currentEquipFilePath = @"C:\インストール\ゲーム\elona\save\sav_リュカ.txt";
            // 成功時の装備情報ファイルを保存するディレクトリ
            const String backupEquipFileDir = @"C:\インストール\ゲーム\elona\bk_save\2.黒猫保存\装備ファイル";
            // 元のセーブデータのパス
            const String originalSaveDir = @"C:\インストール\ゲーム\elona\bk_save\1.黒猫トライ前\save";
            // 現在のセーブデータのパス
            const String currentSaveDir = @"C:\インストール\ゲーム\elona\save";
            // 成功時のセーブデータのバックアップを保存するディレクトリのパス
            const String backupSaveDir = @"C:\インストール\ゲーム\elona\bk_save\2.黒猫保存";

            // 黒猫エンチャントリロード
            while (successCount < maxSuccessCount && totalCount < maxTotalCount)
            {
                // 総試行回数をカウントする
                totalCount++;

                // 現在のセーブデータを元のセーブデータで上書きする
                new Command.CopyDirectory(originalSaveDir, currentSaveDir).Execute();

                // ゲームを開始する
                {
                    // ゲームを起動する
                    new Command.Start(@"C:\インストール\ゲーム\elona\elona.exe").Execute();
                    // 6秒待機する
                    new Command.Wait("6000").Execute();
                    // Enterを押下する(2回)　→　ここでゲームスタート
                    for (int i = 0; i < 2; i++)
                    {
                        new Command.PressKey(KeyBordEnum.KeyEnum.Enter.ToString()).Execute();
                        // 6秒待機する
                        new Command.Wait("6000").Execute();
                    }
                }

                // 市民を殺害する
                {
                    // 9を押下する　→　黒猫が市民と戦闘状態に入る
                    for (int i = 0; i < 7; i++)
                    {
                        new Command.PressKey(KeyBordEnum.KeyEnum.D9.ToString()).Execute();
                        // 1秒待機する
                        new Command.Wait("1000").Execute();
                    }
                    // Enterを押下する(10回)　→　市民が死亡するまでの待機
                    for (int i = 0; i < 10; i++)
                    {
                        new Command.PressKey(KeyBordEnum.KeyEnum.Enter.ToString()).Execute();
                        // 1秒待機する
                        new Command.Wait("1000").Execute();
                    }
                }

                // ドロップアイテムを拾う
                {
                    // ↑←を押下する　→　死亡した市民の位置へ移動
                    for (int i = 0; i < 5; i++)
                    {
                        new Command.PressKey(KeyBordEnum.KeyEnum.Up.ToString()).Execute();
                        new Command.Wait("2000").Execute();
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        new Command.PressKey(KeyBordEnum.KeyEnum.Left.ToString()).Execute();
                        new Command.Wait("2000").Execute();
                    }

                    // gキーを押下する　→　落ちているアイテムを拾うコマンドへ移行
                    new Command.PressKey(KeyBordEnum.KeyEnum.G.ToString()).Execute();
                    // 1秒待機する
                    new Command.Wait("1000").Execute();
                    // Enterを押下する(10回)　→　落ちているアイテムを全て拾い、更にアイテム回収画面が終了する
                    for (int i = 0; i < 10; i++)
                    {
                        // Enterキーを押下する
                        new Command.PressKey(KeyBordEnum.KeyEnum.Enter.ToString()).Execute();
                        // 1秒待機する
                        new Command.Wait("1000").Execute();
                    }
                }

                // アイテムを装備する
                {
                    // Wキー→gキー→fキーを押下する　→　指輪を拾った場合に装備する
                    new Command.PressKey(KeyBordEnum.KeyEnum.W.ToString()).Execute();
                    new Command.Wait("2000").Execute();
                    new Command.PressKey(KeyBordEnum.KeyEnum.G.ToString()).Execute();
                    new Command.Wait("2000").Execute();
                    new Command.PressKey(KeyBordEnum.KeyEnum.F.ToString()).Execute();
                    new Command.Wait("2000").Execute();

                    // Shitキーを押下する(念のため4回)　→　装備画面を終了する
                    for (int i = 0; i < 4; i++)
                    {
                        // Shiftキーを押下する
                        new Command.PressKey(KeyBordEnum.KeyEnum.Shift.ToString()).Execute();
                        // 1秒待機する
                        new Command.Wait("1000").Execute();
                    }
                }

                // 装備を確認する
                {
                    for (int i = 0; i < 10; i++)
                    {
                        // F11キーを押下する　→　装備情報をファイル出力する
                        new Command.PressKey(KeyBordEnum.KeyEnum.F11.ToString()).Execute();
                        // 2秒待機する
                        new Command.Wait("2000").Execute();
                    }

                    // Escキーを押下する　→　F11キーを多重に押下してしまった場合のフォロー
                    new Command.PressKey(KeyBordEnum.KeyEnum.Escape.ToString()).Execute();
                    // 1秒待機する
                    new Command.Wait("1000").Execute();
                    // Alt + F4を押下する　→　装備情報ファイルを閉じる
                    new Command.PressKey(KeyBordEnum.KeyEnum.Alt.ToString(), KeyBordEnum.KeyEnum.F4.ToString()).Execute();
                    // 1秒待機する
                    new Command.Wait("1000").Execute();
                }

                // エンチャント失敗している場合、次の処理へ
                {
                    // 装備情報ファイルに「銅の瞳」と「それは幻惑への耐性を授ける」が記入されているか確認する
                    Encoding sjis = Encoding.GetEncoding("shift_jis");
                    string fileContent = File.ReadAllText(currentEquipFilePath, sjis);

                    if (!fileContent.Contains("銅の瞳") ||
                        !fileContent.Contains("それは幻惑への耐性を授ける"))
                    {
                        // エンチャント失敗している場合は、Alt + F4を押下する　→　Elonaを終了する
                        new Command.PressKey(KeyBordEnum.KeyEnum.Alt.ToString(), KeyBordEnum.KeyEnum.F4.ToString()).Execute();
                        // 4秒待機する
                        new Command.Wait("4000").Execute();
                        // エンチャント失敗している場合は、次のループへ
                        continue;
                    }
                }

                // エンチャント成功している場合
                {
                    // 成功回数をカウントする
                    successCount++;
                    // Shift + s を押下する　→　セーブする
                    new Command.PressKey(KeyBordEnum.KeyEnum.Shift.ToString(), KeyBordEnum.KeyEnum.S.ToString()).Execute();
                    // 4秒待機する
                    new Command.Wait("4000").Execute();
                    // Enterを押下する(2回)　→　Elonaを終了する
                    for (int i = 0; i < 2; i++)
                    {
                        // Enterキーを押下する
                        new Command.PressKey(KeyBordEnum.KeyEnum.Enter.ToString()).Execute();
                        // 1秒待機する
                        new Command.Wait("1000").Execute();
                    }
                }

                // 成功時のセーブデータのバックアップ取得および現在のセーブデータを元に戻す
                {
                    // 成功時の装備情報ファイルのバックアップを保存するディレクトリのパス
                    String backupEquipFilePath = System.IO.Path.Combine(backupEquipFileDir, "save_" + successCount.ToString() + ".txt");
                    // 成功時の装備情報ファイルのバックアップを保存する
                    new Command.CopyFile(currentEquipFilePath, backupEquipFilePath).Execute();
                    // 成功時のセーブデータのバックアップを保存するディレクトリ
                    String backupSaveFilePath = System.IO.Path.Combine(backupSaveDir, "save_" + successCount.ToString());
                    // 成功時のセーブデータのバックアップを保存する
                    new Command.CopyDirectory(currentSaveDir, backupSaveFilePath).Execute();
                }
            }

            // 現在のセーブデータを元のセーブデータで上書きする
            new Command.CopyDirectory(originalSaveDir, currentSaveDir).Execute();
        }
    }
}
