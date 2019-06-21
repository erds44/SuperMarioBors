using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Managers;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Items
{
    public class RedMushroom : AbstractItem, IItem
    {
        private readonly ItemPhysics physics;
        private bool addFlag;
        private Vector2 offset = new Vector2(5, 0);
        private readonly float speedChangeFlag = 0;
        public RedMushroom(Vector2 location)
        {
            Position = location + offset;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0);
            physics = new ItemPhysics(this, new Vector2(0, -180));
            addFlag = false;
            speedChangeFlag += location.Y - 50;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update();
            Position += physics.Displacement(gameTime);
            if(Position.Y <= speedChangeFlag && !addFlag)
            {
                physics.SetSpeed(new Vector2(40, 0));
                sprite.SetLayer(1.0f);
                ObjectsManager.Instance.AddObject(this);
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

        public void MoveLeft()
        {
            physics.MoveLeft();
        }

        public void MoveRight()
        {
            physics.MoveRight();
        }

        public void Destroy()
        {
            //Do nothing.
        }

        public void ChangeDirection()
        {
            physics.ChangeDirection();
        }

        public void BumpUp()
        {
            physics.BumpUp();
        }
    }
}
