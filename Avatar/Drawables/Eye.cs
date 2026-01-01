using System;
using System.Drawing;
using nanoFramework.UI;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// 楕円形の目
    /// </summary>
    public class EllipseEye : IDrawable
    {
        private int _width;
        private int _height;
        private bool _isLeft;

        public EllipseEye() : this(16, 16, false)
        {
        }

        public EllipseEye(int width, int height, bool isLeft)
        {
            _width = width;
            _height = height;
            _isLeft = isLeft;
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
            float openRatio = _isLeft ? ctx.LeftEyeOpenRatio : ctx.RightEyeOpenRatio;
            Gaze gaze = _isLeft ? ctx.LeftGaze : ctx.RightGaze;

            int offsetX = (int)(gaze.GetHorizontal() * 5);
            int offsetY = (int)(gaze.GetVertical() * 5);

            Color color = Color.White; // TODO: パレット対応する場合は置き換え

            if (openRatio == 0)
            {
                // 閉じ目は横線1pxで描画
                bmp.DrawLine(color, 1, cx - _width / 2, cy, cx + _width / 2, cy);
                return;
            }

            // 開いた目は円形に近い塗りつぶしを水平スキャンで描画
            int eyeHeight = Math.Max(1, (int)(_height * openRatio));
            int radius = Math.Max(1, Math.Min(_width, eyeHeight) / 2);

            for (int y = -radius; y <= radius; y++)
            {
                int dx = (int)Math.Sqrt(radius * radius - y * y);
                int yPos = cy + offsetY + y;
                bmp.DrawLine(color, 1, cx + offsetX - dx, yPos, cx + offsetX + dx, yPos);
            }
        }
    }

    /// <summary>
    /// シンプルな円形の目
    /// </summary>
    public class Eye : IDrawable
    {
        private int _radius;
        private bool _isLeft;

        public Eye(int radius, bool isLeft)
        {
            _radius = radius;
            _isLeft = isLeft;
        }

        public void Draw(object canvas, BoundingRect rect, DrawContext ctx)
        {
            int cx = rect.GetCenterX();
            int cy = rect.GetCenterY();
            float openRatio = _isLeft ? ctx.LeftEyeOpenRatio : ctx.RightEyeOpenRatio;

            if (openRatio == 0)
            {
                return;
            }

            // DrawCircle(canvas, cx, cy, _radius);
        }
    }
}
