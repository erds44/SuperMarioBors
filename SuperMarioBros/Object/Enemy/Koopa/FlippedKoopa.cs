using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Goombas;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Koopas
{
    public class FlippedKoopa : AbstractEnemy

    {
        public FlippedKoopa(Koopa koopa)
        {
            Sprite = koopa.Sprite;
            Position = koopa.Position;
            physics = new EnemyPhysics(this, new Vector2(0, 0));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {           
            ((UniversalSprite)Sprite).Draw(spriteBatch, Position,SpriteEffects.FlipVertically);
        }
        public override void Flip()
        {
            //Do Nothing
        }

        public override void MoveLeft()
        {
            //Do Nothing
        }

        public override void MoveRight()
        {
            //Do Nothing
        }

        public override void TakeDamage()
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
