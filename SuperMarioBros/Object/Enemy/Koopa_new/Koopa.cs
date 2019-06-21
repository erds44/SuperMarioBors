using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Goombas;
using SuperMarioBros.Koopas.States;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Koopas
{
    public class Koopa : AbstractEnemy
    {
        private bool flipped = false;
        public Koopa(Vector2 location)
        {
            physics = new EnemyPhysics(this, new Vector2(-30, 0));
            State = new LeftMovingKoopa(this);
            Position = location;
        }

        public void Stomped()
        {
            State.Stomped();
        }
        
        public override void TakeDamage()
        {
            Flip();
        }

        public override void Flip()
        {
            ObjectsManager.Instance.Remove(this);
            State = new StompedKoopa(this);
            ObjectsManager.Instance.AddNonCollidable(this);
            flipped = true;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (flipped)
            {
                ((UniversalSprite)Sprite).Draw(spriteBatch, Position, SpriteEffects.FlipVertically);
            }
            else
            {
                base.Draw(spriteBatch);
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(State is StompedKoopa&& ! flipped)
            {
                StompedKoopa sg = (StompedKoopa)State;
                sg.timeLength--;
                Console.WriteLine(sg.timeLength);
                if (sg.timeLength == 0)
                {
                    State = new RightMovingKoopa(this);
                    physics.SetVelocity(30, 0);
                }
            }
        }
    }
}
