using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.SpriteFactories;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class SmallMario : IMarioHealthState
    {
        private readonly IMario mario;
        private readonly Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>
        {
            {typeof(LeftCrouching), typeof(LeftIdle)},
            {typeof(RightCrouching), typeof(RightIdle)},
        };

        public SmallMario(IMario mario)
        {
            this.mario = mario;
            if (mario.MovementState != null)
            {
                if(dictionary.TryGetValue(mario.MovementState.GetType(), out Type type))
                {
                    mario.Sprite = SpriteFactory.CreateSprite(GetType().Name + type.Name);
                } else
                {
                    mario.Sprite = SpriteFactory.CreateSprite(GetType().Name + mario.MovementState.GetType().Name);
                }
            }
        }

        public void TakeDamage()
        {
            mario.HealthState = new DeadMario(mario);
        }

        public void RedMushroom()
        {
            mario.HealthState = new BigMario(mario);
        }

        public void FireFlower()
        {
            mario.HealthState = new FireMario(mario);
        }

        public void GreenMushroom()
        {
            //Do Nothing
        }

        public void Coin()
        {
            // To Do
        }
    }
}
