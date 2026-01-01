using System;
using System.Drawing;
using nanoFramework.UI;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// 矩形の口
    /// </summary>
    public class RectMouth : IDrawable
    {
        private int _minWidth;
        private int _maxWidth;
        private int _minHeight;
        private int _maxHeight;

        public RectMouth(int minWidth, int maxWidth, int minHeight, int maxHeight)
        {
            _minWidth = minWidth;
            _maxWidth = maxWidth;
            _minHeight = minHeight;
            _maxHeight = maxHeight;
        }

        public void Draw(object canvas, BoundingRect rect, DrawContext ctx)
        {
            var bmp = canvas as Bitmap;
            if (bmp == null)
            {
                return;
            }

            int cx = rect.GetCenterX();
            int cy = rect.GetCenterY();
            float openRatio = ctx.MouthOpenRatio;

            int height = Math.Max(1, (int)(_minHeight + (_maxHeight - _minHeight) * openRatio));
            int width = Math.Max(1, (int)(_minWidth + (_maxWidth - _minWidth) * (1 - openRatio)));

            Color color = Color.White; // 口色。パレット対応するなら適宜置き換え

            // 塗りつぶし矩形で口を描画
            bmp.FillRectangle(cx - width / 2, cy - height / 2, width, height, color, Bitmap.OpacityOpaque);
        }
    }

    /// <summary>
    /// U字型の口
    /// </summary>
    public class UShapeMouth : IDrawable
    {
        private int _width;
        private int _height;
        private int _minHeight;
        private int _maxHeight;

        public UShapeMouth(int width, int height, int minHeight, int maxHeight)
        {
            _width = width;
            _height = height;
            _minHeight = minHeight;
            _maxHeight = maxHeight;
        }

        public void Draw(object canvas, BoundingRect rect, DrawContext ctx)
        {
            var bmp = canvas as Bitmap;
            if (bmp == null)
            {
                return;
            }

            int cx = rect.GetCenterX();
            int cy = rect.GetCenterY();
            float openRatio = ctx.MouthOpenRatio;

            int height = Math.Max(1, (int)(_minHeight + (_maxHeight - _minHeight) * openRatio));

            int radiusX = Math.Max(1, _width / 2);
            int radiusY = Math.Max(1, height / 2);
            Color color = Color.White;

            // U字の下側を横ラインで近似（楕円の下半分）
            for (int y = 0; y <= radiusY; y++)
            {
                double ratio = 1.0 - (y * y) / (double)(radiusY * radiusY);
                int dx = (int)(radiusX * Math.Sqrt(Math.Max(0, ratio)));
                int yPos = cy + y;
                bmp.DrawLine(color, 1, cx - dx, yPos, cx + dx, yPos);
            }

            // 両端を少し上に伸ばしてU形状を強調
            bmp.DrawLine(color, 1, cx - radiusX, cy, cx - radiusX, cy + radiusY / 2);
            bmp.DrawLine(color, 1, cx + radiusX, cy, cx + radiusX, cy + radiusY / 2);
        }
    }
}
