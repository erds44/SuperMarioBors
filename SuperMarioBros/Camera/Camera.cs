using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;
using System;

namespace SuperMarioBros.Cameras
{
    public class Camera
    {
        public float LeftBound { get; private set; }
        private float prevLeftBound;
        public float RightBound => LeftBound + windowWidth;
        public float UpperBound { get; private set; }
        private IObject focus;
        public Matrix Transform { get; private set; }
        private readonly float windowWidth;
        public Camera(float windowWidth)
        {
            this.windowWidth = windowWidth;
            LeftBound = 0;
            UpperBound = 0;
        }
        public void SetFocus(IObject obj)
        {
            focus = obj;
        }
        public void Reset()
        {
            LeftBound = 0;
            prevLeftBound = 0;
            UpperBound = 0;
        }
        public void Reset(IObject obj)
        {
            LeftBound = 0;
            prevLeftBound = 0;
            UpperBound = 0;
            focus = obj;
        }
        public void Update()
        {
            if (focus is null) return;
            Vector2 targetPosition = focus.Position;
            LeftBound = Math.Max(prevLeftBound, targetPosition.X + focus.HitBox.Width / 2 - windowWidth / 2); //2 for the midpoint.
            prevLeftBound = LeftBound;
            var position = Matrix.CreateTranslation(-LeftBound-windowWidth / 2, 0, 0); //2 for the midpoint.
            var offset = Matrix.CreateTranslation(windowWidth / 2, 0,0); //2 for the midpoint.
            Transform = position * offset;
            if (UpperBound != 0)
                UpperBound = 0;
        }

        public void Update(Vector2 focus) //focus on given point. This does not have a "left-only" limit. Given point will be the center of the camera.
        {
            LeftBound = focus.X - windowWidth / 2; //2 for the midpoint.
            var position = Matrix.CreateTranslation(-LeftBound - windowWidth / 2, -focus.Y, 0); //2 for the midpoint.
            var offset = Matrix.CreateTranslation(windowWidth / 2, 0, 0); //2 for the midpoint.
            Transform = position * offset;
            UpperBound = focus.Y ;
        }
    }
}
