﻿using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Objects.Enemy
{
    public class KoopaIdleState : IEnemyMovementState
    {
        private float respondingTimer = Timers.ShelledKoopaTimeSpan;
        private readonly Koopa koopa;
        public KoopaIdleState(Koopa koopa)
        {
            this.koopa = koopa;
            this.koopa.Sprite = SpriteFactory.CreateSprite(this.koopa.HealthState.GetType().Name + GetType().Name);
            this.koopa.Physics.Velocity = Vector2.Zero;
        }

        public void ChangeDirection() { }

        public void MoveLeft()
        {
            koopa.MovementState = new KoopaLeftMovingState(koopa);
        }

        public void MoveRight()
        {
            koopa.MovementState = new KoopaRightMovingState(koopa);
        }

        public void Stomped() { }

        public void Update(GameTime gameTime)
        {
            respondingTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(respondingTimer <= 0)
            {
                koopa.HealthState = new KoopaNormalState(koopa);
                koopa.MovementState = new KoopaLeftMovingState(koopa);
            } 
        }
    }
}
