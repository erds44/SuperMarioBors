using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class FireMario :  IMarioHealthState
    {
        private bool power;
        public int fireCount = 2; //Can throw 2 fireballs.
        private readonly IMario mario;
        public FireMario(IMario mario)
        {
            this.mario = mario;
            mario.Sprite = SpriteFactory.CreateSprite(GetType().Name + mario.MovementState.GetType().Name);
            mario.MarioPhysics.SetSprintVelocityRate(1);
        }

        public void Coin()
        {
            // To Do
        }

        public void OnFireFlower()
        {
            // Do Nothing
        }

        public void GreenMushroom()
        {
            // Do Nothing
        }

        public void RedMushroom()
        {
            // Do Nothing
        }

        public void TakeDamage()
        {
            mario.HealthState = new BigMario(mario);
        }

        public void Power()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            if (!(power && mario.PowerFlag) && mario.PowerFlag && fireCount>0 )
            {
                fireCount--;
                ObjectsManager.Instance.Add(new FireBall(this, mario));
            }
            power = mario.PowerFlag;
        }
    }
}
