using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Sprites;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;
using System;

namespace SuperMarioBros.Goombas
{
    public abstract class AbstractEnemy : IEnemy
    {
        private protected IEnemyMovementState state;
        private protected Point location;
        private protected ISprite sprite;

        public void ChangeDirection()
        {
            state.ChangeDirection();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void ChangeSprite(ISprite inputSprite)
        {
            this.sprite = inputSprite;
        }

        public void ChangeState(IEnemyMovementState inputState)
        {
            this.state = inputState;
        }

        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.ObjectSize(GetType());
            return new Rectangle(location.X, location.Y - size.Y, size.X, size.Y);
        }
    }
}
