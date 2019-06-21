using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Goombas;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Enemy;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Koopas.States
{
    public class FlippedKoopa : AbstractEnemy

    {
        public FlippedKoopa(Koopa koopa)
        {
            Sprite = koopa.Sprite;
            Position = koopa.Position;
            physics = new EnemyPhysics(this, new Vector2(0, 0));

            //physics.velocity.X = 0;
            //physics.velocity.Y = -150;

        }

        public void ChangeDirection()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            ((UniversalSprite)Sprite).Draw(spriteBatch, Position,SpriteEffects.FlipVertically);
        }
        public override void Flip()
        {
            //Do Nothing
        }

        public void Stomped()
        {
            throw new NotImplementedException();
        }

        public override void TakeDamage()
        {
            //Do Nothing
        }

    }
}
