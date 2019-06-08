using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks;
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
        public List<IObject> Objects { get; set; }
        public IMario Mario { get; set; }
        private CollisionManager collisionManager;
        private readonly static ObjectsManager instance = new ObjectsManager();
        public static ObjectsManager Instance { get { return instance; } }
        private ObjectsManager() { }

        public void Initialize()
        {
            collisionManager = new CollisionManager(Mario, Objects);
        }
        public void Update()
        {
            Objects.ForEach(element => element.Update());
            Mario.Update();
            collisionManager.HandleCollision();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Mario.Draw(spriteBatch);
            Objects.ForEach(element => element.Draw(spriteBatch));
        }
        public void DecorateMario(IMario mario)
        {
            this.Mario = mario;
            collisionManager.Mario = mario;
        }
        public void Remove(IObject gameObject, int index)
        {
            if(gameObject != null)
            {
                Objects.RemoveAt(index);
            }
        }
        public void DecorateObject( IObject obj1, int index)
        {
            Objects[index] = obj1;
        }

    }
}
