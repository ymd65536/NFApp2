using System;
using nanoFramework.UI;
using System.Drawing;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// アバターの顔を表すクラス
    /// </summary>
    public class Face
    {
        private readonly Bitmap _canvas;
        private IDrawable _mouth;
        private IDrawable _rightEye;
        private IDrawable _leftEye;
        private IDrawable _rightEyebrow;
        private IDrawable _leftEyebrow;

        private BoundingRect _mouthPos;
        private BoundingRect _rightEyePos;
        private BoundingRect _leftEyePos;
        private BoundingRect _rightEyebrowPos;
        private BoundingRect _leftEyebrowPos;
        private BoundingRect _boundingRect;

        public Face()
        {
            // デフォルトの顔を生成
            _mouth = new RectMouth(50, 90, 4, 60);
            _mouthPos = new BoundingRect(148, 163);

            _rightEye = new EllipseEye(16, 16, false);
            _rightEyePos = new BoundingRect(93, 90);

            _leftEye = new EllipseEye(16, 16, true);
            _leftEyePos = new BoundingRect(96, 230);

            _rightEyebrow = new EllipseEyebrow(32, 0, false);
            _rightEyebrowPos = new BoundingRect(67, 96);

            _leftEyebrow = new EllipseEyebrow(32, 0, true);
            _leftEyebrowPos = new BoundingRect(72, 230);

            _boundingRect = new BoundingRect(0, 0, 320, 240);

            _canvas = new Bitmap(320, 240);
        }

        public Face(
            IDrawable mouth, BoundingRect mouthPos,
            IDrawable rightEye, BoundingRect rightEyePos,
            IDrawable leftEye, BoundingRect leftEyePos,
            IDrawable rightEyebrow, BoundingRect rightEyebrowPos,
            IDrawable leftEyebrow, BoundingRect leftEyebrowPos)
        {
            _mouth = mouth;
            _mouthPos = mouthPos;
            _rightEye = rightEye;
            _rightEyePos = rightEyePos;
            _leftEye = leftEye;
            _leftEyePos = leftEyePos;
            _rightEyebrow = rightEyebrow;
            _rightEyebrowPos = rightEyebrowPos;
            _leftEyebrow = leftEyebrow;
            _leftEyebrowPos = leftEyebrowPos;
            _boundingRect = new BoundingRect(0, 0, 320, 240);

            _canvas = new Bitmap(320, 240);
        }

        public BoundingRect GetBoundingRect() => _boundingRect;

        public void Draw(DrawContext ctx)
        {
            // 画面クリア（色指定できないため、黒でクリア）
            _canvas.Clear();

            // 各パーツを描画
            _mouth?.Draw(_canvas, _mouthPos, ctx);
            _rightEye?.Draw(_canvas, _rightEyePos, ctx);
            _leftEye?.Draw(_canvas, _leftEyePos, ctx);
            _rightEyebrow?.Draw(_canvas, _rightEyebrowPos, ctx);
            _leftEyebrow?.Draw(_canvas, _leftEyebrowPos, ctx);

            // 画面に反映
            _canvas.Flush(0, 0, 320, 240);
        }

        public void SetMouth(IDrawable mouth) => _mouth = mouth;
        public void SetRightEye(IDrawable eye) => _rightEye = eye;
        public void SetLeftEye(IDrawable eye) => _leftEye = eye;
        public IDrawable GetMouth() => _mouth;
        public IDrawable GetRightEye() => _rightEye;
        public IDrawable GetLeftEye() => _leftEye;
    }
}
