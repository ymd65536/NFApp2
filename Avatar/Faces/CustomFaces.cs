using System;

namespace dotNETM5StackAvatar
{
    /// <summary>
    /// A simple face implementation with basic features
    /// </summary>
    public class SimpleFace : Face
    {
        public SimpleFace() : base(
            new RectMouth(50, 90, 4, 60),
            new BoundingRect(148, 163),
            new EllipseEye(16, 16, false),
            new BoundingRect(93, 90),
            new EllipseEye(16, 16, true),
            new BoundingRect(96, 230),
            new EllipseEyebrow(32, 5, false),
            new BoundingRect(67, 96),
            new EllipseEyebrow(32, 5, true),
            new BoundingRect(72, 230)
        )
        {
        }
    }

    /// <summary>
    /// A girly face with larger eyes and expressive features
    /// </summary>
    public class GirlyFace : Face
    {
        public GirlyFace() : base(
            new UShapeMouth(40, 20, 2, 15),
            new BoundingRect(148, 163),
            new EllipseEye(20, 20, false),
            new BoundingRect(93, 90),
            new EllipseEye(20, 20, true),
            new BoundingRect(96, 230),
            new EllipseEyebrow(40, 3, false),
            new BoundingRect(67, 96),
            new EllipseEyebrow(40, 3, true),
            new BoundingRect(72, 230)
        )
        {
        }
    }
}
