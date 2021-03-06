﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects.Mario.TransitionState;

namespace SuperMarioBros.Objects.Mario.MarioTransitionState
{
    public class NormalState : IMarioTransitionState
    {
        private readonly IMario mario;
        public NormalState(IMario mario)
        {
            this.mario = mario;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Sprite.Draw(spriteBatch, mario.Position);
        }

        public void OnFireFlower()
        {
            mario.HealthState.TakeFireFlower();
            mario.TransitionState = new GrowState(mario);
        }

        public void TakeRedMushroom()
        {
            mario.HealthState.TakeRedMushroom();
            mario.TransitionState = new GrowState(mario);
        }

        public void TakeDamage()
        {
            mario.HealthState.TakeDamage();
            if(!(mario.HealthState is DeadMario))
                mario.TransitionState = new DamageState(mario);
        }

        public void TakeStar()
        {
            mario.TransitionState = new StarState(mario);
        }

        public void Update(GameTime gameTime)
        {
            // Do Nothing
        }
    }
}
