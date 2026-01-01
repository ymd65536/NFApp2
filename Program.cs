using System;
using System.Threading;
using nanoFramework.M5Stack;
using dotNETM5StackAvatar;
using nanoFramework.Hardware.Esp32;
using Console = System.Console;

Fire.InitializeScreen();

// Initialize the avatar with default face
var avatar = new Avatar();

// Use rectangular mouth (keep square/rect style) and make it open/close faster
avatar.GetFace().SetMouth(new RectMouth(50, 90, 4, 60));

// Start avatar drawing/animation
avatar.Init();

// Fast continuous mouth animation with periodic counter reset
int i = 0;
while (true)
{
    // 速い振動: sin の係数を大きくし、Sleep を短くする
    float ratio = (float)((Math.Sin(i * 0.5) + 1.0) / 2.0); // 0..1 に正規化
    avatar.SetMouthOpenRatio(ratio);

    i++;
    if (i >= 1000) // 定期的に初期化
    {
        i = 0;
    }

    Thread.Sleep(50); // 50ms ごとに更新 → 高速な開閉
}
