using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks;
using SuperMarioBros.Collisions;
using SuperMarioBros.Goombas;
using SuperMarioBros.Items;
using SuperMarioBros.Koopas;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
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
                // The update method might change element in the list, so no for each loop
                Mario[i].Update(); 
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            StaticObjects.ForEach(element => element.Draw(spriteBatch));
            Mario.ForEach(element => element.Draw(spriteBatch));
        }
        public void DecorateMario(IMario oldMario, IMario newMario)
        {
            if(!(oldMario.HealthState is DeadMario))
            {
                Mario[Mario.IndexOf(oldMario)] = newMario;
            }
            // This method is used for flashing mario
            // No need to chekc if oldMario in Mario
        }
        public void Remove(IObject gameObject)
        {
            StaticObjects.Remove(gameObject);
        }
        public void DecorateObject(IObject oldObject, IObject newObject)
        {
            StaticObjects[StaticObjects.IndexOf(oldObject)] = newObject;
        }
        public void RemoveDecoration(IMario oldMario, IMario newMario)
        {
            Mario[Mario.IndexOf(oldMario)] = newMario;
        }
        public void StarMario(IMario mario)
        {
            int index = Mario.IndexOf(mario);
            if (mario is FlashingMario)
            {
                mario.Timer = 0;
                mario.Update();
            }
            Mario[index] = new StarMario(Mario[index]);
        }
        public void HiddenUsed(IBlock block)
        {
            int height = Rectangle.Intersect(Mario[0].HitBox(), block.HitBox()).Height;
            if (Mario[0].MarioPhysics.HitHidden(height))
            {
                StaticObjects[StaticObjects.IndexOf(block)] = new UsedBlock(new Point(block.HitBox().X, block.HitBox().Y + block.HitBox().Height));
                Mario[0].MarioPhysics.Down();
                Mario[0].Update();
            }
        }
        public void BrickDisappear(IBlock block)
        {
            if(Mario[0].HealthState is SmallMario)
            {
                Mario[0].Obstacle();
            }
            else
            {
                StaticObjects.Remove(block);
            }
        }
    }
}
