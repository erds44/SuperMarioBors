using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;
using SuperMarioBros.Utility;
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
            LeftBound = GeneralConstants.InitialLeftBound;
            UpperBound = GeneralConstants.InitialUpperBound;
        }
        public void SetFocus(IObject obj)
        {
            focus = obj;
        }
        public void Reset()
        {
            LeftBound = GeneralConstants.InitialLeftBound;
            prevLeftBound = GeneralConstants.InitialLeftBound;
            UpperBound = GeneralConstants.InitialUpperBound;
        }
        public void Reset(IObject obj)
        {
            LeftBound = GeneralConstants.InitialLeftBound;
            prevLeftBound = GeneralConstants.InitialLeftBound;
            UpperBound = GeneralConstants.InitialUpperBound;
            focus = obj;
        }
        public void Update()
        {
            if (focus is null) return;
            Vector2 targetPosition = focus.Position;
            LeftBound = Math.Max(prevLeftBound, targetPosition.X + focus.HitBox.Width / GeneralConstants.MidPoint - windowWidth / GeneralConstants.MidPoint); //2 for the midpoint.
            prevLeftBound = LeftBound;
            var position = Matrix.CreateTranslation(-LeftBound-windowWidth / GeneralConstants.MidPoint, GeneralConstants.NonChange, GeneralConstants.NonChange); //2 for the midpoint.
            var offset = Matrix.CreateTranslation(windowWidth / GeneralConstants.MidPoint, GeneralConstants.NonChange, GeneralConstants.NonChange); //2 for the midpoint.
            Transform = position * offset;
            if (UpperBound != GeneralConstants.InitialUpperBound)
                UpperBound = GeneralConstants.InitialUpperBound;
        }

        public void Update(Vector2 focus) //focus on given point. This does not have a "left-only" limit. Given point will be the center of the camera.
        {
            LeftBound = focus.X - windowWidth / GeneralConstants.MidPoint; //2 for the midpoint.
            var position = Matrix.CreateTranslation(-LeftBound - windowWidth / GeneralConstants.MidPoint, -focus.Y, GeneralConstants.NonChange); //2 for the midpoint.
            var offset = Matrix.CreateTranslation(windowWidth / GeneralConstants.MidPoint, GeneralConstants.NonChange, GeneralConstants.NonChange); //2 for the midpoint.
            Transform = position * offset;
            UpperBound = focus.Y ;
        }
    }
}
