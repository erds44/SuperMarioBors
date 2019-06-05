using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using System.Collections.Generic;

namespace SuperMarioBros.Objects
{
    public class ObjectsManager
    {
        private List<IObject> objects;
        private IMario mario;
        private CollisionManager collisionManager;
        public ObjectsManager(IMario mario)
        {
            this.mario = mario;
            Initialize();
            collisionManager = new CollisionManager(this, mario, objects);
        }
        private void Initialize()
        {
            objects = new List<IObject>
            {
                new GreenMushroom(new Vector2(100, 100)),
                new RedMushroom(new Vector2(150, 100)),
                new Flower(new Vector2(300, 100)),  
                new Star(new Vector2(400,100)),
                new Pipe(new Vector2(500,300))
            };
        }
        public void Update()
        {
            objects.ForEach(element => element.Update());
            mario.Update();
            collisionManager.HandleCollision();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Draw(spriteBatch);
            objects.ForEach(element => element.Draw(spriteBatch));
        }
        //private void CollisionAgainstItems()
        //{
        //    for (int i = 0; i < items.Count; i++)
        //    {
        //        if (MarioItemCollisionHandler.HandleCollision(mario, items[i], CollisionDetection.Detect(mario, items[i])))
        //        {
        //            items.RemoveAt(i);
        //        }
        //    }
        //}
        //private void CollisionAgainstStars()
        //{
        //    for (int i = 0; i < stars.Count; i++)
        //    {
        //        if (MarioStarCollisionHandler.HandleCollision(this, mario, stars[i], CollisionDetection.Detect(mario, stars[i])))
        //        {
        //            stars.RemoveAt(i);
        //        }
        //    }
        //}
        //private void CollisionAgainstPipes()
        //{
        //    for (int i = 0; i <pipes.Count; i++)
        //    {
        //        MarioItemCollisionHandler.HandleCollision(mario, pipes[i], CollisionDetection.Detect(mario, pipes[i]));
        //    }
        //}
        public void DecorateMario(IMario mario)
        {
            this.mario = mario;
        }

    }
}
