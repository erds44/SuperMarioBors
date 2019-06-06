using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.Goombas;
using SuperMarioBros.Items;
using SuperMarioBros.Koopas;
using SuperMarioBros.Marios;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Objects
{
    public  class ObjectsManager
    {
        private List<IObject> objects;
        private IMario mario;
        private CollisionManager collisionManager;
        private readonly static ObjectsManager instance = new ObjectsManager();
        public static ObjectsManager Instance { get { return instance; } }
        private ObjectsManager() { }

        public void Initialize(IMario mario)
        {
            this.mario = mario;
            objects = new List<IObject>
            {
                new GreenMushroom(new Vector2(100, 100)),
                new RedMushroom(new Vector2(200, 100)),
                new Flower(new Vector2(300, 100)),
                new Star(new Vector2(400,100)),
                new Pipe(new Vector2(600,300)),
                new Coin(new Vector2(500,100)),
                new Koopa(new Vector2(100,150)),
                new Goomba(new Vector2(200,150))
            };
            collisionManager = new CollisionManager(mario, objects);
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
        public void Remove(IObject gameObject, int index)
        {
            if(gameObject != null)
            {
                objects.RemoveAt(index);
            }
        }
        public void DecorateObject( IObject obj1, int index)
        {
            objects[index] = obj1;
        }

    }
}
