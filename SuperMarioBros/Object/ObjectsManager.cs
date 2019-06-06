using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Collisions;
using SuperMarioBros.Goombas;
using SuperMarioBros.Items;
using SuperMarioBros.Koopas;
using SuperMarioBros.Marios;
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
                new GreenMushroom(new Vector2(100, 300)),
                new RedMushroom(new Vector2(200, 300)),
                new Flower(new Vector2(300, 300)),
                new Star(new Vector2(400,300)),
                new Pipe(new Vector2(600,300)),
                new Coin(new Vector2(500,300)),
                new Koopa(new Vector2(100,200)),
                new Goomba(new Vector2(200,200))
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
            collisionManager.Mario = mario;
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
