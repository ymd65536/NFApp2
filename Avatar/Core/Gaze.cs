using System;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// 視線の方向を表すクラス
    /// </summary>
    public class Gaze
    {
        private float _vertical;
        private float _horizontal;

        public Gaze() : this(0.0f, 0.0f)
        {
        }

        public Gaze(float vertical, float horizontal)
        {
            _vertical = vertical;
            _horizontal = horizontal;
        }

        public float GetVertical() => _vertical;
        public float GetHorizontal() => _horizontal;

        public void Set(float vertical, float horizontal)
        {
            _vertical = vertical;
            _horizontal = horizontal;
        }
    }
}