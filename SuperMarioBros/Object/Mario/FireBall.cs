using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Marios
{
    public class FireBall : IDynamic
    {
        public bool IsInvalid { get; set; }

        private List<Type> direction = new List<Type>
        {
            typeof(LeftBreaking),
            typeof(LeftCrouching),
            typeof(LeftIdle),
            typeof(LeftJumping),
            typeof(LeftMoving),
        };
        public Vector2 Position { get; set; }
        private ISprite sprite;
        private StarPhysics physics;
        private FireMario fireMario;
        public FireBall(FireMario fireMario, IMario mario)
        {
            this.fireMario = fireMario;
            if (direction.Contains(mario.MovementState.GetType()))
            {
                Position = mario.Position + new Vector2(-22, -1 * mario.HitBox().Height / 2);
                physics = new StarPhysics(this, new Vector2(-100, 20));
            }
            else
            {
                Position = mario.Position + new Vector2(40, -1 * mario.HitBox().Height / 2);
                physics = new StarPhysics(this, new Vector2(100, 20));
            }
            sprite = SpriteFactory.CreateSprite(GetType().Name);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public Rectangle HitBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y - 16, 16, 16);
        }

        public void MoveDown()
        {
            physics.MoveDown();
        }

        public void MoveLeft()
        {
            physics.MoveLeft();
        }

        public void MoveRight()
        {
            physics.MoveRight();
        }

        public void MoveUp()
        {
            physics.MoveUp();
        }

        public void Update(GameTime gameTime)
        {
            Position += physics.Displacement(gameTime);
            sprite.Update();
        }

        public void Destroy()
        {
            fireMario.fireCount++;
        }

        public void TakeDamage()
        {
            // Do Nothing
        }
    }
}
