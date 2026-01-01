using nanoFramework.M5Stack;
using System.Threading;
using System.Drawing;

Fire.InitializeScreen();
var ledBar = Fire.LedBar;

// まず定義済みの色でテスト
ledBar.Image.SetPixel(0, 0, Color.Red);
ledBar.Update();

Thread.Sleep(Timeout.Infinite);
