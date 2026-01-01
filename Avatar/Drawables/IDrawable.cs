using System;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// 描画可能な要素の基底インターフェース
    /// </summary>
    public interface IDrawable
    {
        void Draw(object canvas, BoundingRect rect, DrawContext ctx);
    }
}