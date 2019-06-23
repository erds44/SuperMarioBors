using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Physicses;

namespace SuperMarioBros.Goombas
{
    public class StompedGoomba : AbstractEnemy
    {
        private double deletetimer = 0.3;
        public StompedGoomba(Vector2 position)
        {
            State = new IdleEnemyState(this);
            Position = position;
            physics = new EnemyPhysics(this, new Vector2(0, 0));
        }

        public override void TakeDamage()
        {
           //Do Nothing
        }

        public override void Flip()
        {
            //Do Nothing
        }

        public override void MoveLeft()
        {
            // Do Nothing
        }

        public override void MoveRight()
        {
            //Do Nothing
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update();
            deletetimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (deletetimer <= 0)
                ObjState = ObjectState.Destroy;;
            Position += physics.Displacement(gameTime);
        }
    
    }
}
