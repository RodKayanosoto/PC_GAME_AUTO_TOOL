using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.Enums;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.Logic;

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
            const int maxSuccessCount = 200;
            // 黒猫エンチャントの総試行回数の上限
            const int maxTotalCount = 20000;

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

            // Elonaの実行ファイルのパス
            const String elonaExePath = @"C:\インストール\ゲーム\elona\elona.exe";
            // サクラエディタのexeのパス(終了させるために使用する)
            const String sakuraEditorExePath = @"C:\Program Files (x86)\sakura\sakura.exe";

            // 現在のセーブデータを元のセーブデータで上書きする
            new Command.CopyDirectory(originalSaveDir, currentSaveDir).Execute();

            // 黒猫エンチャントリロード
            while (successCount < maxSuccessCount && totalCount < maxTotalCount)
            {
                // 総試行回数をカウントする
                totalCount++;

                // Elonaのプロセスを終了する
                {
                    // Elonaのプロセスが存在するか確認する
                    PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic isExistsProcess = new IsExistsProcess(elonaExePath);

                    // Elonaのプロセスが存在する場合は、Elonaのプロセスを終了する
                    if (isExistsProcess.execute())
                    {
                         new Command.Terminate(elonaExePath).Execute();
                    }
                }

                // サクラエディタのプロセスを終了する
                {
                    // サクラエディタのプロセスが存在するか確認する
                    PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic isExistsProcess = new IsExistsProcess(sakuraEditorExePath);

                    // サクラエディタのプロセスが存在する場合は、サクラエディタのプロセスを終了する
                    if (isExistsProcess.execute())
                    {
                        new Command.Terminate(sakuraEditorExePath).Execute();
                    }
                }

                // ゲームを開始する
                {
                    // ゲームを起動する
                    new Command.Start(elonaExePath).Execute();
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
                        new Command.PressKey(KeyBordEnum.KeyEnum.D9.ToString()).Execute();
                        // 0.5秒待機する
                        new Command.Wait("500").Execute();
                    }
                    // Enterを押下する(10回)　→　市民が死亡するまでの待機
                    for (int i = 0; i < 10; i++)
                    {
                        new Command.PressKey(KeyBordEnum.KeyEnum.Enter.ToString()).Execute();
                        new Command.PressKey(KeyBordEnum.KeyEnum.Enter.ToString()).Execute();
                        // 0.5秒待機する
                        new Command.Wait("500").Execute();
                    }
                }

                // ドロップアイテムを拾う
                {
                    // ↑←を押下する　→　死亡した市民の位置へ移動
                    for (int i = 0; i < 10; i++)
                    {
                        new Command.PressKey(KeyBordEnum.KeyEnum.Up.ToString()).Execute();
                        new Command.PressKey(KeyBordEnum.KeyEnum.Up.ToString()).Execute();
                        new Command.PressKey(KeyBordEnum.KeyEnum.Up.ToString()).Execute();
                        new Command.Wait("500").Execute();
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        new Command.PressKey(KeyBordEnum.KeyEnum.Left.ToString()).Execute();
                        new Command.PressKey(KeyBordEnum.KeyEnum.Left.ToString()).Execute();
                        new Command.PressKey(KeyBordEnum.KeyEnum.Left.ToString()).Execute();
                        new Command.Wait("500").Execute();
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        // gキーを押下する　→　落ちているアイテムを拾うコマンドへ移行
                        new Command.PressKey(KeyBordEnum.KeyEnum.G.ToString()).Execute();
                        // 1秒待機する
                        new Command.Wait("1000").Execute();
                        // Enterを押下する(10回)　→　落ちているアイテムを全て拾い、更にアイテム回収画面が終了する
                        for (int j = 0; j < 5; j++)
                        {
                            // Enterキーを押下する
                            new Command.PressKey(KeyBordEnum.KeyEnum.Enter.ToString()).Execute();
                            new Command.PressKey(KeyBordEnum.KeyEnum.Enter.ToString()).Execute();
                            // 0.5秒待機する
                            new Command.Wait("500").Execute();
                        }
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

                    // Shitキーを押下する(念のため10回)　→　装備画面を終了する
                    for (int i = 0; i < 10; i++)
                    {
                        // Shiftキーを押下する
                        new Command.PressKey(KeyBordEnum.KeyEnum.Shift.ToString()).Execute();
                        new Command.PressKey(KeyBordEnum.KeyEnum.Shift.ToString()).Execute();
                        // 0.5秒待機する
                        new Command.Wait("500").Execute();
                    }
                }

                // 装備を確認する
                {
                    for (int i = 0; i < 10; i++)
                    {
                        // F11キーを押下する　→　装備情報をファイル出力する
                        new Command.PressKey(KeyBordEnum.KeyEnum.F11.ToString()).Execute();
                        new Command.PressKey(KeyBordEnum.KeyEnum.F11.ToString()).Execute();
                        // 0.5秒待機する
                        new Command.Wait("500").Execute();
                    }

                    // 装備情報ファイルを閉じる(サクラエディタで開かれる)
                    {
                        // サクラエディタのプロセスが存在するか確認する
                        PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic isExistsProcess = new IsExistsProcess(sakuraEditorExePath);

                        // サクラエディタのプロセスが存在する場合は、サクラエディタのプロセスを終了する
                        if (isExistsProcess.execute())
                        {
                            new Command.Terminate(sakuraEditorExePath).Execute();
                        }
                    }

                    // 1秒待機する
                    new Command.Wait("1000").Execute();
                }

                // エンチャント失敗している場合、次の処理へ
                {
                    // 装備情報ファイルに「銅の瞳」と「それは幻惑への耐性を授ける」が記入されているか確認する
                    PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic command = new IsFileTextContains("SJIS", currentEquipFilePath, "エヘカトルの祝福");

                    //if (!fileContent.Contains("エヘカトルの祝福") ||
                    //    !fileContent.Contains("それは幻惑への耐性を授ける"))
                    if (!command.execute())
                    {
                        // エンチャント失敗している場合は、Elonaのプロセスを終了する
                        {
                            // Elonaのプロセスが存在するか確認する
                            PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic isExistsProcess = new IsExistsProcess(elonaExePath);

                            // Elonaのプロセスが存在する場合は、Elonaのプロセスを終了する
                            if (isExistsProcess.execute())
                            {
                                new Command.Terminate(elonaExePath).Execute();
                            }
                        }

                        // 2秒待機する
                        new Command.Wait("2000").Execute();
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
                    // Enterを押下する(4回)　→　Elonaを終了する
                    for (int i = 0; i < 4; i++)
                    {
                        // Enterキーを押下する
                        new Command.PressKey(KeyBordEnum.KeyEnum.Enter.ToString()).Execute();
                        // 1秒待機する
                        new Command.Wait("1000").Execute();
                        // Elonaのプロセスが存在しない場合は、セーブ成功とみなす
                        PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic isExistsProcess = new IsExistsProcess(elonaExePath);
                        if (!isExistsProcess.execute())
                        {
                            break;
                        }
                    }
                }

                // Elonaのプロセスが存在する場合は終了する
                {
                    // Elonaのプロセスが存在するか確認する
                    PC_GAME_AUTO_TOOL.Functions.Macro.Logic.InterFace.Logic isExistsProcess = new IsExistsProcess(elonaExePath);

                    // Elonaのプロセスが存在する場合は、Elonaのプロセスを終了する
                    if (isExistsProcess.execute())
                    {
                        // Elonaのプロセスを終了する
                        new Command.Terminate(elonaExePath).Execute();
                        // ここまでプロセスが残っている場合はセーブ失敗が考えられる。しかしとりあえず終了して次の試行へ移る
                        continue;
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
                    // 現在のセーブデータを元のセーブデータで上書きする
                    new Command.CopyDirectory(originalSaveDir, currentSaveDir).Execute();
                }
            }
        }
    }
}
