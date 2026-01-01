using System;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// 描画に必要な情報を保持するコンテキスト
    /// </summary>
    public class DrawContext
    {
        public Expression Expression { get; private set; }
        public float Breath { get; private set; }
        public Gaze LeftGaze { get; private set; }
        public float LeftEyeOpenRatio { get; private set; }
        public Gaze RightGaze { get; private set; }
        public float RightEyeOpenRatio { get; private set; }
        public float MouthOpenRatio { get; private set; }
        public ColorPalette Palette { get; private set; }
        public string SpeechText { get; private set; }
        public float Rotation { get; private set; }
        public float Scale { get; private set; }
        public int ColorDepth { get; private set; }
        public BatteryIconStatus BatteryIconStatus { get; private set; }
        public int BatteryLevel { get; private set; }

        public DrawContext(
            Expression expression,
            float breath,
            ColorPalette palette,
            Gaze rightGaze,
            float rightEyeOpenRatio,
            Gaze leftGaze,
            float leftEyeOpenRatio,
            float mouthOpenRatio,
            string speechText,
            float rotation,
            float scale,
            int colorDepth,
            BatteryIconStatus batteryIconStatus,
            int batteryLevel)
        {
            Expression = expression;
            Breath = breath;
            Palette = palette;
            RightGaze = rightGaze;
            RightEyeOpenRatio = rightEyeOpenRatio;
            LeftGaze = leftGaze;
            LeftEyeOpenRatio = leftEyeOpenRatio;
            MouthOpenRatio = mouthOpenRatio;
            SpeechText = speechText;
            Rotation = rotation;
            Scale = scale;
            ColorDepth = colorDepth;
            BatteryIconStatus = batteryIconStatus;
            BatteryLevel = batteryLevel;
        }
    }
}