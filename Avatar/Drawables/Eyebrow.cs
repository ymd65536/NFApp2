using System;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// 楕円形の眉
    /// </summary>
    public class EllipseEyebrow : IDrawable
    {
        private int _width;
        private int _height;
        private bool _isLeft;

        public EllipseEyebrow(int width, int height, bool isLeft)
        {
            _width = width;
            _height = height;
            _isLeft = isLeft;
        }

        public void Draw(object canvas, BoundingRect rect, DrawContext ctx)
        {
            if (_width == 0 || _height == 0)
            {
                return; // 眉を非表示
            }

            int cx = rect.GetCenterX();
            int cy = rect.GetCenterY();

            // DrawEllipse(canvas, cx, cy, _width/2, _height/2);
        }
    }
}
