using System;
using System.Threading;
using System.Diagnostics;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// M5Stack Avatar のメインクラス
    /// </summary>
    public class Avatar
    {
        private Face _face;
        private bool _isDrawing;
        private Expression _expression;
        private float _breath;

        // 右目の状態
        private float _rightEyeOpenRatio;
        private float _rightGazeV;
        private float _rightGazeH;

        // 左目の状態
        private float _leftEyeOpenRatio;
        private float _leftGazeV;
        private float _leftGazeH;

        private bool _isAutoBlink;
        private float _mouthOpenRatio;
        private float _rotation;
        private float _scale;
        private ColorPalette _palette;
        private string _speechText;
        private int _colorDepth;
        private BatteryIconStatus _batteryIconStatus;
        private int _batteryLevel;

        private Thread _drawThread;
        private Thread _facialThread;

        public Avatar() : this(new Face())
        {
        }

        public Avatar(Face face)
        {
            _face = face;
            _isDrawing = false;
            _expression = Expression.Neutral;
            _breath = 0.0f;
            _leftEyeOpenRatio = 1.0f;
            _leftGazeH = 0.0f;
            _leftGazeV = 0.0f;
            _rightEyeOpenRatio = 1.0f;
            _rightGazeH = 0.0f;
            _rightGazeV = 0.0f;
            _isAutoBlink = true;
            _mouthOpenRatio = 0.0f;
            _rotation = 0.0f;
            _scale = 1.0f;
            _palette = new ColorPalette();
            _speechText = "";
            _colorDepth = 1;
            _batteryIconStatus = BatteryIconStatus.Invisible;
            _batteryLevel = 0;
        }

        /// <summary>
        /// アバターの初期化と描画開始
        /// </summary>
        public void Init(int colorDepth = 1)
        {
            Start(colorDepth);
        }

        /// <summary>
        /// アバターの描画開始
        /// </summary>
        public void Start(int colorDepth = 1)
        {
            if (_isDrawing) return;

            _isDrawing = true;
            _colorDepth = colorDepth;

            // 描画スレッドの開始
            _drawThread = new Thread(DrawLoop);
            _drawThread.Start();

            // 顔のアニメーションスレッドの開始
            _facialThread = new Thread(FacialLoop);
            _facialThread.Start();
        }

        /// <summary>
        /// アバターの描画停止
        /// </summary>
        public void Stop()
        {
            _isDrawing = false;

            if (_drawThread != null)
            {
                _drawThread.Join(1000);
                _drawThread = null;
            }

            if (_facialThread != null)
            {
                _facialThread.Join(1000);
                _facialThread = null;
            }
        }

        /// <summary>
        /// 描画ループ
        /// </summary>
        private void DrawLoop()
        {
            while (_isDrawing)
            {
                Draw();
                Thread.Sleep(10); // 約100fps
            }
        }

        /// <summary>
        /// 顔のアニメーションループ
        /// </summary>
        private void FacialLoop()
        {
            Random random = new Random();
            int count = 0;
            int saccadeInterval = 1000;
            int blinkInterval = 1000;
            long lastSaccadeMillis = Stopwatch.GetTimestamp() / (Stopwatch.Frequency / 1000);
            long lastBlinkMillis = Stopwatch.GetTimestamp() / (Stopwatch.Frequency / 1000);
            bool eyeOpen = true;

            while (_isDrawing)
            {
                long currentMillis = Stopwatch.GetTimestamp() / (Stopwatch.Frequency / 1000);

                // サッケード（視線移動）
                if ((currentMillis - lastSaccadeMillis) > saccadeInterval)
                {
                    float vertical = (float)(random.NextDouble() * 2.0 - 1.0);
                    float horizontal = (float)(random.NextDouble() * 2.0 - 1.0);
                    SetRightGaze(vertical, horizontal);
                    SetLeftGaze(vertical, horizontal);
                    saccadeInterval = 500 + random.Next(2000);
                    lastSaccadeMillis = currentMillis;
                }

                // 自動まばたき
                if (_isAutoBlink)
                {
                    if ((currentMillis - lastBlinkMillis) > blinkInterval)
                    {
                        if (eyeOpen)
                        {
                            SetEyeOpenRatio(1.0f);
                            blinkInterval = 2500 + random.Next(2000);
                        }
                        else
                        {
                            SetEyeOpenRatio(0.0f);
                            blinkInterval = 300 + random.Next(200);
                        }
                        eyeOpen = !eyeOpen;
                        lastBlinkMillis = currentMillis;
                    }
                }

                // 呼吸アニメーション
                count = (count + 1) % 100;
                _breath = (float)Math.Sin(count * 2 * Math.PI / 100.0);

                Thread.Sleep(33); // 約30fps
            }
        }

        /// <summary>
        /// 描画実行
        /// </summary>
        private void Draw()
        {
            Gaze rightGaze = new Gaze(_rightGazeV, _rightGazeH);
            Gaze leftGaze = new Gaze(_leftGazeV, _leftGazeH);

            DrawContext ctx = new DrawContext(
                _expression,
                _breath,
                _palette,
                rightGaze,
                _rightEyeOpenRatio,
                leftGaze,
                _leftEyeOpenRatio,
                _mouthOpenRatio,
                _speechText,
                _rotation,
                _scale,
                _colorDepth,
                _batteryIconStatus,
                _batteryLevel
            );

            _face.Draw(ctx);
        }

        public bool IsDrawing() => _isDrawing;

        // プロパティアクセサー
        public void SetExpression(Expression expression) => _expression = expression;
        public Expression GetExpression() => _expression;

        public void SetBreath(float breath) => _breath = breath;
        public float GetBreath() => _breath;

        public void SetRightGaze(float vertical, float horizontal)
        {
            _rightGazeV = vertical;
            _rightGazeH = horizontal;
        }

        public void GetRightGaze(out float vertical, out float horizontal)
        {
            vertical = _rightGazeV;
            horizontal = _rightGazeH;
        }

        public void SetLeftGaze(float vertical, float horizontal)
        {
            _leftGazeV = vertical;
            _leftGazeH = horizontal;
        }

        public void GetLeftGaze(out float vertical, out float horizontal)
        {
            vertical = _leftGazeV;
            horizontal = _leftGazeH;
        }

        public void SetEyeOpenRatio(float ratio)
        {
            SetRightEyeOpenRatio(ratio);
            SetLeftEyeOpenRatio(ratio);
        }

        public void SetRightEyeOpenRatio(float ratio) => _rightEyeOpenRatio = ratio;
        public float GetRightEyeOpenRatio() => _rightEyeOpenRatio;

        public void SetLeftEyeOpenRatio(float ratio) => _leftEyeOpenRatio = ratio;
        public float GetLeftEyeOpenRatio() => _leftEyeOpenRatio;

        public void SetIsAutoBlink(bool isAutoBlink) => _isAutoBlink = isAutoBlink;
        public bool GetIsAutoBlink() => _isAutoBlink;

        public void SetMouthOpenRatio(float ratio) => _mouthOpenRatio = ratio;
        public void SetSpeechText(string speechText) => _speechText = speechText;
        public void SetRotation(float radian) => _rotation = radian;
        public void SetScale(float scale) => _scale = scale;

        public void SetPosition(int top, int left)
        {
            _face.GetBoundingRect().SetPosition(top, left);
        }

        public void SetColorPalette(ColorPalette palette) => _palette = palette;
        public ColorPalette GetColorPalette() => _palette;

        public Face GetFace() => _face;
        public void SetFace(Face face) => _face = face;

        public void SetBatteryIcon(bool batteryIcon)
        {
            _batteryIconStatus = batteryIcon ? BatteryIconStatus.Discharging : BatteryIconStatus.Invisible;
        }

        public void SetBatteryStatus(bool isCharging, int batteryLevel)
        {
            _batteryIconStatus = isCharging ? BatteryIconStatus.Charging : BatteryIconStatus.Discharging;
            _batteryLevel = batteryLevel;
        }
    }
}
