using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;
using System;

namespace SuperMarioBros.GameCoreComponents
{
    public class Camera
    {
        public static Camera Instance { get {
                if (instance is null) instance = new Camera();
                return instance;
            }
        }
        private static Camera instance;
        public float LeftBound { get; private set; }
        public float RightBound { get; private set; }
        public IObject focus { get; private set; }
        public Matrix Transform { get; private set; }
        public Camera()
        {
            LeftBound = 0;
            RightBound = LeftBound + MarioGame.WindowWidth;
        }
        public void SetFocus(IObject obj)
        {
            focus = obj;
        }
        public void Reset()
        {
            LeftBound = 0;
            RightBound = LeftBound + MarioGame.WindowWidth;
        }
        public void Reset(IObject obj)
        {
            LeftBound = 0;
            RightBound = LeftBound + MarioGame.WindowWidth;
            focus = obj;
        }
        public void Follow()
        {
            if (focus is null) return;
            Vector2 targetPosition = focus.Position;
            LeftBound = Math.Max(LeftBound, targetPosition.X + focus.HitBox().Width / 2 - MarioGame.WindowWidth / 2);
            RightBound = LeftBound + MarioGame.WindowWidth;
            var position = Matrix.CreateTranslation(-LeftBound-MarioGame.WindowWidth / 2, 0, 0);
            var offset = Matrix.CreateTranslation(MarioGame.WindowWidth/2, 0,0);
            Transform = position * offset;
        }

    }
}
