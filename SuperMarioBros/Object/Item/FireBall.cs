using Microsoft.Xna.Framework;
using SuperMarioBros.Items;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Marios
{
    public class FireBall : AbstractItem
    {

        private List<Type> direction = new List<Type>
        {
            typeof(LeftBreaking),
            typeof(LeftCrouching),
            typeof(LeftIdle),
            typeof(LeftJumping),
            typeof(LeftMoving),
        };
        private FireMario fireMario;
        private Vector2 LeftMovingVelocity = new Vector2(-100, 50);
        private Vector2 RightMovingVelocity = new Vector2(100, 50);
        private float gravity = 200f;
        private float weight = 20f;
        public bool Explosion { get; private set; }
        private float explosionTimer = 0.2f;
        private Vector2 explosionOffSet = new Vector2(-16, 0);
        public FireBall(FireMario fireMario, IMario mario)
        {
            this.fireMario = fireMario;
            if (direction.Contains(mario.MovementState.GetType()))
            {
                Position = mario.Position + new Vector2(-22, -1 * mario.HitBox().Height / 2);
                Physics = new Physics(LeftMovingVelocity, gravity, weight);
            }
            else
            {
                Position = mario.Position + new Vector2(40, -1 * mario.HitBox().Height / 2);
                Physics = new Physics(RightMovingVelocity, gravity, weight);
            }
            Physics.ApplyGravity();
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            Explosion = false;
        }

        public override Rectangle HitBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y - 16, 16, 16);
        }

        public override void Destroy()
        {
            fireMario.fireCount++;
        }
        public void FireExplosion()
        {
            sprite = SpriteFactory.CreateSprite(nameof(FireExplosion));
            Position += explosionOffSet;
            Explosion = true;
        }
        public override void Update(GameTime gameTime)
        {
            if (Explosion)
            {
                sprite.Update();
                explosionTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (explosionTimer <= 0)
                    ObjState = ObjectState.Destroy;
            }
            else
                base.Update(gameTime);
        }
    }
}
