using System;
using System.Threading;
using nanoFramework.M5Stack;
using dotNETM5StackAvatar;
using nanoFramework.Hardware.Esp32;
using Console = System.Console;

Fire.InitializeScreen();

Console.WriteLine("M5Stack Avatar Sample Starting...");

// Initialize the avatar with default face
var avatar = new Avatar();
avatar.Init();
avatar.Start();

Console.WriteLine("Avatar initialized and started");

// Demonstrate different expressions
Thread.Sleep(200);

// Happy expression
Console.WriteLine("Expression: Happy");
avatar.SetExpression(Expression.Happy);
Thread.Sleep(300);

// Angry expression
Console.WriteLine("Expression: Angry");
avatar.SetExpression(Expression.Angry);
Thread.Sleep(300);

// Sleepy expression
Console.WriteLine("Expression: Sleepy");
avatar.SetExpression(Expression.Sleepy);
Thread.Sleep(300);

// Sad expression
Console.WriteLine("Expression: Sad");
avatar.SetExpression(Expression.Sad);
Thread.Sleep(3000);

// Switch to SimpleFace
Console.WriteLine("Switching to SimpleFace");
// avatar.SetFace(new SimpleFace());
avatar.SetExpression(Expression.Neutral);
Thread.Sleep(300);

// Switch to GirlyFace
Console.WriteLine("Switching to GirlyFace");
// avatar.SetFace(new GirlyFace());
avatar.SetExpression(Expression.Happy);
Thread.Sleep(300);

// Demonstrate speech
Console.WriteLine("Starting speech animation");
for (int i = 0; i < 10; i++)
{
    avatar.SetMouthOpenRatio((float)Math.Abs(Math.Sin(i * 0.5)));
    Thread.Sleep(200);
}

// Back to neutral
avatar.SetExpression(Expression.Neutral);

Console.WriteLine("Sample completed. Avatar will continue running.");
