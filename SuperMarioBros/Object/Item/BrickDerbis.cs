using Microsoft.Xna.Framework;
using SuperMarioBros.Managers;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using System.Collections.Generic;

namespace SuperMarioBros.Items
{
    public enum BrickPosition { leftTop, leftBottom, rightTop, rightBottom }
    public class BrickDerbis : AbstractItem, IItem
    {
        private Dictionary<BrickPosition, (Vector2, Vector2)> derbisInfo = new Dictionary<BrickPosition, (Vector2, Vector2)>
        {
            { BrickPosition.leftTop, (new Vector2(0,-40), new Vector2(-60,60))},
            { BrickPosition.leftBottom, (new Vector2(0,0), new Vector2(-60,60)) },
            { BrickPosition.rightTop, (new Vector2(20,-40), new Vector2(60,60)) },
            { BrickPosition.rightBottom, (new Vector2(20,0), new Vector2(60,60)) }
        };
        private readonly ItemPhysics physics;
        private float timer;
        public BrickDerbis(Vector2 location, BrickPosition brickPosition)
        {
            ObjState = ObjectState.NonCollidable;
            derbisInfo.TryGetValue(brickPosition, out var tuple);
            Vector2 offSet = tuple.Item1;
            Vector2 velocity = tuple.Item2;
            Position = location + offSet;
            sprite = SpriteFactory.CreateDerbisSprite(brickPosition);
            physics = new ItemPhysics(this, velocity);
            physics.SetGravity();
            timer = 0;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            sprite.Update();
            Position += physics.Displacement(gameTime);
            if (timer >= 0.5 )
            {
                ObjState = ObjectState.Destroy;
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

        public void ChangeDirection()
        {
            //Do Nothing
        }

        public void BumpUp()
        {
            // Do Nothing
        }
    }
}
