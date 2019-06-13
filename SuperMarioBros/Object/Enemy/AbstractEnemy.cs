using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Sprites;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Goombas
{
    public abstract class AbstractEnemy : IEnemy
    {
        public IEnemyMovementState State { get; set; }
        private protected Point location;
        public ISprite Sprite { get; set; }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, location);
        }

        public void Update()
        {
            Sprite.Update();
        }

        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.ObjectSize(GetType());
            return new Rectangle(location.X, location.Y - size.Y, size.X, size.Y);
        }
    }
}
