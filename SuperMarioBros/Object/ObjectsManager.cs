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
        private readonly CollisionManager collisionManager;
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
                new RedMushroom(new Vector2(200, 100)),
                new Flower(new Vector2(300, 100)),  
                new Star(new Vector2(400,100)),
                new Pipe(new Vector2(600,300)),
                new Coin(new Vector2(500,100))
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
        public void DecorateMario(IMario mario)
        {
            this.mario = mario;
        }

    }
}
