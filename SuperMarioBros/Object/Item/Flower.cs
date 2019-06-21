using Microsoft.Xna.Framework;
using SuperMarioBros.Managers;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Flower : AbstractItem , IItem
    {
        private readonly ItemPhysics physics;
        private bool addFlag;
        private Vector2 offset = new Vector2(5, 0);
        private readonly float speedChangeFlag = 0;
        public Flower(Vector2 location)
        {
            Position = location + offset;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0);
            physics = new ItemPhysics(this, new Vector2(0, -180));
            addFlag = false;
            speedChangeFlag += location.Y - 40;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update();
            Position += physics.Displacement(gameTime);
            if (Position.Y <= speedChangeFlag  && !addFlag)
            {
                physics.SetSpeed(new Vector2(0, 0));
                sprite.SetLayer(1.0f);
                ObjectsManager.Instance.AddDynamic(this);
                ObjectsManager.Instance.RemoveFromNonCollidable(this);
                addFlag = true;
            }

        }
        public void MoveUp()
        {
            physics.MoveUp();
        }

        public void MoveDown()
        {
            physics.MoveDown();
        }

        public void ReverseDirection()
        {
            physics.MoveLeft();
        }

        public void MoveLeft()
        {
            physics.MoveRight();
        }

        public void Destroy()
        {
            //Do nothing.
        }

        public void ChangeDirection()
        {
            // Do Nothing
        }

        public void BumpUp()
        {
           // Do Nothing
        }
    }
}
