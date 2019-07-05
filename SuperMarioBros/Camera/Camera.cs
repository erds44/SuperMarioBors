using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;
using System;

namespace SuperMarioBros.Cameras
{
    public class Camera
    {
        public float LeftBound { get; set; }
        private float prevLeftBound;
        public float RightBound { get; set; }
        public float UpperBound { get; set; }
        public IObject Focus { get; private set; }
        public Matrix Transform { get; private set; }
        private readonly float windowWidth;
        public Camera(float windowWidth)
        {
            this.windowWidth = windowWidth;
            LeftBound = 0;
            RightBound = windowWidth;
            UpperBound = 0;
        }
        public void SetFocus(IObject obj)
        {
            Focus = obj;
        }
        public void Reset()
        {
            LeftBound = 0;
            prevLeftBound = 0;
            RightBound = LeftBound + windowWidth;
            UpperBound = 0;
        }
        public void Reset(IObject obj)
        {
            LeftBound = 0;
            prevLeftBound = 0;
            RightBound = LeftBound + windowWidth;
            UpperBound = 0;
            Focus = obj;
        }
        public void Update()
        {
            if (Focus is null) return;
            Vector2 targetPosition = Focus.Position;
            LeftBound = Math.Max(prevLeftBound, targetPosition.X + Focus.HitBox().Width / 2 - windowWidth / 2);
            prevLeftBound = LeftBound;
            RightBound = LeftBound + windowWidth;
            var position = Matrix.CreateTranslation(-LeftBound-windowWidth / 2, 0, 0);
            var offset = Matrix.CreateTranslation(windowWidth / 2, 0,0);
            Transform = position * offset;
            if (UpperBound != 0)
                UpperBound = 0;
        }

        public void Update(Vector2 focus) //Focus on given point. This does not have a "left-only" limit. Given point will be the center of the camera.
        {
            LeftBound = focus.X - windowWidth / 2;
            RightBound = LeftBound + windowWidth;
            var position = Matrix.CreateTranslation(-LeftBound - windowWidth / 2, -focus.Y, 0);
            var offset = Matrix.CreateTranslation(windowWidth / 2, 0, 0);
            Transform = position * offset;
            UpperBound = focus.Y ;
        }
    }
}
