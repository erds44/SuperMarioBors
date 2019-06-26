using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Managers;
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
            mario.Physics.SetSprintVelocityRate(1);
        }

        public void TakeDamage()
        {
            mario.HealthState = new SmallMario(mario);
        }

        public void TakeRedMushroom()
        {
            // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            if (!(power && mario.PowerFlag) && mario.PowerFlag && fireCount>0 )
            {
                fireCount--;
                ObjectsManager.Instance.AddObject(new FireBall(this, mario));
            }
            power = mario.PowerFlag;
        }

        public void OnFireFlower()
        {
           // Do Nothing
        }
    }
}
