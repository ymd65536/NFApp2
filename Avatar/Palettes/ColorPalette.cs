using System;
using System.Collections;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// 顔の描画用カラーパレット
    /// </summary>
    public class ColorPalette
    {
        // Color constants (16-bit RGB565 format)
        public const ushort TFT_BLACK = 0x0000;
        public const ushort TFT_WHITE = 0xFFFF;
        public const ushort TFT_RED = 0xF800;
        public const ushort TFT_PINK = 0xFE19;
        public const ushort TFT_YELLOW = 0xFFE0;
        public const ushort TFT_DARKCYAN = 0x03EF;
        public const ushort TFT_DARKGREY = 0x7BEF;

        // Color keys
        public const string COLOR_PRIMARY = "primary";
        public const string COLOR_SECONDARY = "secondary";
        public const string COLOR_BACKGROUND = "background";
        public const string COLOR_BALLOON_FOREGROUND = "balloon_f";
        public const string COLOR_BALLOON_BACKGROUND = "balloon_b";

        private Hashtable _colors;

        public ColorPalette()
        {
            _colors = new Hashtable
            {
                { COLOR_PRIMARY, TFT_WHITE },
                { COLOR_SECONDARY, TFT_BLACK },
                { COLOR_BACKGROUND, TFT_BLACK },
                { COLOR_BALLOON_FOREGROUND, TFT_BLACK },
                { COLOR_BALLOON_BACKGROUND, TFT_WHITE }
            };
        }

        public ushort Get(string key)
        {
            if (_colors.Contains(key))
            {
                return (ushort)_colors[key];
            }
            return TFT_BLACK;
        }

        public void Set(string key, ushort value)
        {
            if (_colors.Contains(key))
            {
                _colors[key] = value;
            }
            else
            {
                _colors.Add(key, value);
            }
        }

        public void Clear()
        {
            _colors.Clear();
        }
    }
}