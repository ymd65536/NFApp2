using System;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// アバターの表情
    /// </summary>
    public enum Expression
    {
        Happy,
        Angry,
        Sad,
        Doubt,
        Sleepy,
        Neutral
    }

    /// <summary>
    /// バッテリーアイコンのステータス
    /// </summary>
    public enum BatteryIconStatus
    {
        Discharging,
        Charging,
        Invisible,
        Unknown
    }
}