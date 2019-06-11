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
        public List<IObject> StaticObjects { get; set; }
        public List<IMario> Mario { get; set; } // For now it is a list of maro, later it is a list of dynamic objects
        private readonly static ObjectsManager instance = new ObjectsManager();
        public static ObjectsManager Instance { get { return instance; } }
        private ObjectsManager() { }
        public void Update()
        {
            StaticObjects.ForEach(element => element.Update());
            for (int i = 0; i < Mario.Count; i++)
            {
                Mario[i].Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            StaticObjects.ForEach(element => element.Draw(spriteBatch));
            Mario.ForEach(element => element.Draw(spriteBatch));
        }
        public void DecorateMario(IMario mario, int index)
        {
            Mario[index] = mario;
           // collisionManager.Mario = mario;
        }
        public void Remove(IObject gameObject, int index)
        {
            if(gameObject != null)
            {
                StaticObjects.RemoveAt(index);
            }
        }
        public void DecorateObject( IObject obj1, int index)
        {
            StaticObjects[index] = obj1;
        }

    }
}
