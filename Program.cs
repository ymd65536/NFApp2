using dotNETM5StackAvatar;
using nanoFramework.M5Stack;
using System.Drawing;
using System.Threading;
using Console = nanoFramework.M5Stack.Console;
using Math = System.Math;

Fire.InitializeScreen();
Console.Clear();
Console.WriteLine("Fast Mouth Animation Example");
Thread.Sleep(2000);
var ledBar = Fire.LedBar;

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
    if (i >= 100) // 定期的に初期化
    {
        i = 0;
        Console.Clear();
    }

    Thread.Sleep(50); // 50ms ごとに更新 → 高速な開閉

    var red = Color.FromArgb(255, 255, 0, 0);
    var green = Color.FromArgb(255, 0, 255, 0);
    var blue = Color.FromArgb(255, 0, 0, 255);

    ledBar.Image.SetPixel(0, 0, red);
    ledBar.Image.SetPixel(1, 0, green);
    ledBar.Image.SetPixel(2, 0, blue);
    ledBar.Update();
}
