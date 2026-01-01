using System;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// 描画領域の境界を表すクラス
    /// </summary>
    public class BoundingRect
    {
        private int _top;
        private int _left;
        private int _width;
        private int _height;

        public BoundingRect(int top, int left) : this(top, left, 0, 0)
        {
        }

        public BoundingRect(int top, int left, int width, int height)
        {
            _top = top;
            _left = left;
            _width = width;
            _height = height;
        }

        public int GetTop() => _top;
        public int GetLeft() => _left;
        public int GetWidth() => _width;
        public int GetHeight() => _height;

        public int GetCenterX() => _left + _width / 2;
        public int GetCenterY() => _top + _height / 2;

        public void SetPosition(int top, int left)
        {
            _top = top;
            _left = left;
        }
    }
}