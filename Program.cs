using nanoFramework.M5Stack;
using System.Threading;
using System.Drawing;

Fire.InitializeScreen();
var ledBar = Fire.LedBar;

// Color.FromArgbを直接使う
var red = Color.FromArgb(255, 255, 0, 0);
var green = Color.FromArgb(255, 0, 255, 0);
var blue = Color.FromArgb(255, 0, 0, 255);

ledBar.Image.SetPixel(0, 0, red);
ledBar.Image.SetPixel(1, 0, green);
ledBar.Image.SetPixel(2, 0, blue);
ledBar.Update();

Thread.Sleep(Timeout.Infinite);
