using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Objects
{
    public  class ObjectsManager
    {
        private Collection<IObject> StaticObjects;
        private Collection<IMario> Mario; // For now it is a list of maro, later it is a list of dynamic objects
        private readonly static ObjectsManager instance = new ObjectsManager();
        public static ObjectsManager Instance { get { return instance; } }
        private ObjectsManager() { }
        public void Initialize()
        {
            StaticObjects = ObjectLoading.LoadObject();
            Mario = ObjectLoading.LoadMario();
        }
        public void Update()
        {
            foreach (IObject obj in StaticObjects)
            {
                obj.Update();
            }
            for (int i = 0; i < Mario.Count; i++)
            {
                // The update method might change element in the list, so no for each loop
                Mario[i].Update(); 
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IObject obj in StaticObjects)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IMario mario in Mario)
            {
                mario.Draw(spriteBatch);
            }
        }
        public void DecorateMario(IMario oldMario, IMario newMario)
        {
            if(!(oldMario.HealthState is DeadMario))
            {
                Mario.Remove(oldMario);
                Mario.Add(newMario);
            }
        }
        public void Remove(IObject gameObject)
        {
            StaticObjects.Remove(gameObject);
        }
        /*  The following methods might not be put in the ObjetcsManager class
         *  They will be refactored later
         */
        public void ChangeObject(IObject oldObject, IObject newObject)
        {
            StaticObjects.Remove(oldObject);
            StaticObjects.Add(newObject);
        }
        public void RemoveDecoration(IMario oldMario, IMario newMario)
        {
            Mario.Remove(oldMario);
            Mario.Add(newMario);
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
            // the usage of indeof is necessary here
            // if mario is flashing and hits a star
            // mario will end flashing state then become star mario
        }
        public void HiddenUsed(IBlock block)
        {
            int height = Rectangle.Intersect(Mario[0].HitBox(), block.HitBox()).Height;
            if (Mario[0].MarioPhysics.HitHidden(height))
            {
                block.Used();
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
        public Collection<IMario> MarioObject()
        {
            return Mario;
        }
    }
}
