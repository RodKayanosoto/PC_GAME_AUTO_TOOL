using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.InterFace;
using PC_GAME_AUTO_TOOL.Functions.Macro.Command.Enums;

namespace PC_GAME_AUTO_TOOL.Functions.Macro.Command
{
    public class PressKey : MacroCommandInterface
    {
        // 押下するキー(同時に2つまでOKとする)
        private KeyBordEnum.KeyEnum[] keys;

        public PressKey(params String[] args)
        {
            // 引数の数が1つもしくは2つ以外である場合は例外をスローする
            if (args.Length != 1 && args.Length != 2)
            {
                throw new ArgumentException("エラー: キーは1つか2つの引数で指定してください。");
            }

            // 引数のキーがKyeEnumに存在しない場合は例外をスローする
            foreach (string key in args)
            {
                if (!Enum.TryParse(key, true, out KeyBordEnum.KeyEnum _))
                {
                    throw new ArgumentException($"エラー: キー '{key}' は無効です。");
                }
            }

            // 引数のキーをenumに変換する
            KeyBordEnum.KeyEnum[] keys = new KeyBordEnum.KeyEnum[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                keys[i] = Enum.Parse<KeyBordEnum.KeyEnum>(args[i], true);
            }

            // 引数が2つ存在する場合
            if (keys.Length == 2)
            {
                // 一つ目のキーがShift、Control、Alt以外である場合は例外をスローする
                if (keys[0] != KeyBordEnum.KeyEnum.Shift && keys[0] != KeyBordEnum.KeyEnum.Control && keys[0] != KeyBordEnum.KeyEnum.Alt)
                {
                    throw new ArgumentException("エラー: 1つ目のキーはShift、Control、Altのいずれかで指定してください。");
                }
                // 二つ目のキーがShift、Control、Altである場合は例外をスローする
                if (keys[1] == KeyBordEnum.KeyEnum.Shift || keys[1] == KeyBordEnum.KeyEnum.Control || keys[1] == KeyBordEnum.KeyEnum.Alt)
                {
                    throw new ArgumentException("エラー: 2つ目のキーはShift、Control、Alt以外で指定してください。");
                }
            }

            this.keys = keys;
        }

        /**
         * 指定されたキーを押下する
         */
        public void Execute()
        {
            // SendKeys.SendWaitを使用してキーを押下するための文字列を作成する
            StringBuilder sendKeysStringBuilder = new StringBuilder();
            foreach (KeyBordEnum.KeyEnum key in this.keys)
            {
                sendKeysStringBuilder.Append(ToSendKeys(key));
            }

            // キーを押下する
            System.Windows.Forms.SendKeys.SendWait(sendKeysStringBuilder.ToString());
        }

        private static string ToSendKeys(KeyBordEnum.KeyEnum key)
        {
            return key switch
            {
                KeyBordEnum.KeyEnum.Shift => "+",
                KeyBordEnum.KeyEnum.Control => "^",
                KeyBordEnum.KeyEnum.Alt => "%",

                KeyBordEnum.KeyEnum.Enter => "{ENTER}",
                KeyBordEnum.KeyEnum.Tab => "{TAB}",
                KeyBordEnum.KeyEnum.Escape => "{ESC}",
                KeyBordEnum.KeyEnum.Space => " ",

                KeyBordEnum.KeyEnum.Up => "{UP}",
                KeyBordEnum.KeyEnum.Down => "{DOWN}",
                KeyBordEnum.KeyEnum.Left => "{LEFT}",
                KeyBordEnum.KeyEnum.Right => "{RIGHT}",

                KeyBordEnum.KeyEnum.F1 => "{F1}",
                KeyBordEnum.KeyEnum.F2 => "{F2}",
                KeyBordEnum.KeyEnum.F3 => "{F3}",
                KeyBordEnum.KeyEnum.F4 => "{F4}",
                KeyBordEnum.KeyEnum.F5 => "{F5}",
                KeyBordEnum.KeyEnum.F6 => "{F6}",
                KeyBordEnum.KeyEnum.F7 => "{F7}",
                KeyBordEnum.KeyEnum.F8 => "{F8}",
                KeyBordEnum.KeyEnum.F9 => "{F9}",
                KeyBordEnum.KeyEnum.F10 => "{F10}",
                KeyBordEnum.KeyEnum.F11 => "{F11}",
                KeyBordEnum.KeyEnum.F12 => "{F12}",

                KeyBordEnum.KeyEnum.D0 => "0",
                KeyBordEnum.KeyEnum.D1 => "1",
                KeyBordEnum.KeyEnum.D2 => "2",
                KeyBordEnum.KeyEnum.D3 => "3",
                KeyBordEnum.KeyEnum.D4 => "4",
                KeyBordEnum.KeyEnum.D5 => "5",
                KeyBordEnum.KeyEnum.D6 => "6",
                KeyBordEnum.KeyEnum.D7 => "7",
                KeyBordEnum.KeyEnum.D8 => "8",
                KeyBordEnum.KeyEnum.D9 => "9",

                KeyBordEnum.KeyEnum.NumPad0 => "{NUMPAD0}",
                KeyBordEnum.KeyEnum.NumPad1 => "{NUMPAD1}",
                KeyBordEnum.KeyEnum.NumPad2 => "{NUMPAD2}",
                KeyBordEnum.KeyEnum.NumPad3 => "{NUMPAD3}",
                KeyBordEnum.KeyEnum.NumPad4 => "{NUMPAD4}",
                KeyBordEnum.KeyEnum.NumPad5 => "{NUMPAD5}",
                KeyBordEnum.KeyEnum.NumPad6 => "{NUMPAD6}",
                KeyBordEnum.KeyEnum.NumPad7 => "{NUMPAD7}",
                KeyBordEnum.KeyEnum.NumPad8 => "{NUMPAD8}",
                KeyBordEnum.KeyEnum.NumPad9 => "{NUMPAD9}",

                KeyBordEnum.KeyEnum.A => "a",
                KeyBordEnum.KeyEnum.B => "b",
                KeyBordEnum.KeyEnum.C => "c",
                KeyBordEnum.KeyEnum.D => "d",
                KeyBordEnum.KeyEnum.E => "e",
                KeyBordEnum.KeyEnum.F => "f",
                KeyBordEnum.KeyEnum.G => "g",
                KeyBordEnum.KeyEnum.H => "h",
                KeyBordEnum.KeyEnum.I => "i",
                KeyBordEnum.KeyEnum.J => "j",
                KeyBordEnum.KeyEnum.K => "k",
                KeyBordEnum.KeyEnum.L => "l",
                KeyBordEnum.KeyEnum.M => "m",
                KeyBordEnum.KeyEnum.N => "n",
                KeyBordEnum.KeyEnum.O => "o",
                KeyBordEnum.KeyEnum.P => "p",
                KeyBordEnum.KeyEnum.Q => "q",
                KeyBordEnum.KeyEnum.R => "r",
                KeyBordEnum.KeyEnum.S => "s",
                KeyBordEnum.KeyEnum.T => "t",
                KeyBordEnum.KeyEnum.U => "u",
                KeyBordEnum.KeyEnum.V => "v",
                KeyBordEnum.KeyEnum.W => "w",
                KeyBordEnum.KeyEnum.X => "x",
                KeyBordEnum.KeyEnum.Y => "y",
                KeyBordEnum.KeyEnum.Z => "z",
                _ => throw new ArgumentException($"エラー: 未対応キーです: {key}")
            };
        }
    }
}
