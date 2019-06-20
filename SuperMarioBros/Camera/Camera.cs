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
        public int LeftBound { get; private set; }
        public int RightBound { get; private set; }
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
            var position = Matrix.CreateTranslation(-targetPosition.X - focus.HitBox().Width/2, 0, 0);
            var offset = Matrix.CreateTranslation(MarioGame.WindowWidth/2, 0,0);
            Transform = position * offset;
        }

    }
}
