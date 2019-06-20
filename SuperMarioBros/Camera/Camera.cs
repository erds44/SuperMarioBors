using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.GameCoreComponents
{
    public class Camera
    {
        public float LeftBound { get; private set; }
        public float RightBound { get; private set; }
        private IObject focus;
        public Matrix Transform { get; private set; }
        public Camera(IObject focusOn)
        {
            focus = focusOn;
            LeftBound = 0;
            RightBound = LeftBound + MarioGame.WindowWidth;
        }
        public void Follow()
        {
            Vector2 targetPosition = focus.Position;
            LeftBound = Math.Max(LeftBound, targetPosition.X + focus.HitBox().Width / 2 - MarioGame.WindowWidth / 2);
            RightBound = LeftBound + MarioGame.WindowWidth;
            Console.WriteLine(LeftBound.ToString());
            var position = Matrix.CreateTranslation(-LeftBound-MarioGame.WindowWidth / 2, 0, 0);
            var offset = Matrix.CreateTranslation(MarioGame.WindowWidth/2, 0,0);
            Transform = position * offset;
        }

    }
}
