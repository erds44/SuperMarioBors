using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;
using System;

namespace SuperMarioBros.GameCoreComponents
{
    public class Camera
    {
        public float LeftBound { get; private set; }
        public float RightBound { get; private set; }
        public IObject Focus { get; private set; }
        public Matrix Transform { get; private set; }
        public Camera()
        {
            LeftBound = 0;
            RightBound = LeftBound + MarioGame.Instance.WindowWidth;
        }
        public void SetFocus(IObject obj)
        {
            Focus = obj;
        }
        public void Reset()
        {
            LeftBound = 0;
            RightBound = LeftBound + MarioGame.Instance.WindowWidth;
        }
        public void Reset(IObject obj)
        {
            LeftBound = 0;
            RightBound = LeftBound + MarioGame.Instance.WindowWidth;
            Focus = obj;
        }
        public void Update()
        {
            if (Focus is null) return;
            Vector2 targetPosition = Focus.Position;
            LeftBound = Math.Max(LeftBound, targetPosition.X + Focus.HitBox().Width / 2 - MarioGame.Instance.WindowWidth / 2);
            RightBound = LeftBound + MarioGame.Instance.WindowWidth;
            var position = Matrix.CreateTranslation(-LeftBound-MarioGame.Instance.WindowWidth / 2, 0, 0);
            var offset = Matrix.CreateTranslation(MarioGame.Instance.WindowWidth / 2, 0,0);
            Transform = position * offset;
        }

    }
}
