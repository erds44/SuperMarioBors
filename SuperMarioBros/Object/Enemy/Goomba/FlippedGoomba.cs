using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Goombas
{

    public class FlippedGoomba : AbstractEnemy
    {
        public FlippedGoomba(Goomba goomba)
        {
            Sprite = goomba.Sprite;
            Position = goomba.Position;
            physics = new EnemyPhysics(this, new Vector2(0, 0));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            ((UniversalSprite)Sprite).Draw(spriteBatch, Position, SpriteEffects.FlipVertically);
        }

        public override void TakeDamage()
        {
            //Do Nothing
        }

        public override void Flip()
        {
            //DO Nothing
        }

        public override void MoveLeft()
        {
            //Do Nothing
        }

        public override void MoveRight()
        {
            //Do Nothing
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update();
            Position += physics.Displacement(gameTime);
        }
    }
  
}
