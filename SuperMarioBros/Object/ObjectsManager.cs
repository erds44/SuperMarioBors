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
        private Collection<IStatic> staticObjects;
        private Collection<IDynamic> dynamicObjects;
        public static ObjectsManager Instance { get; } = new ObjectsManager();
        private ObjectsManager() { }
        private GameTime time;
        public void Initialize()
        {
            staticObjects = ObjectLoading.LoadStatics();
            dynamicObjects = ObjectLoading.LoadDynamics();
        }
        public void Update(GameTime gameTime)
        {
            time = gameTime;
            for (int i = 0; i < staticObjects.Count; i++)
                staticObjects[i].Update();
            for (int i = 0; i < dynamicObjects.Count; i++)
                dynamicObjects[i].Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IStatic obj in staticObjects)
                obj.Draw(spriteBatch);
            foreach (IDynamic obj in dynamicObjects)        
                obj.Draw(spriteBatch);
        }
        public void DecorateMario(IMario oldMario, IMario newMario)
        {
            if(!(oldMario.HealthState is DeadMario))
            {
                dynamicObjects.Remove(oldMario);
                dynamicObjects.Add(newMario);
            }
        }
        public void Remove(IObject gameObject)
        {
            if(gameObject is IStatic)
            {
                staticObjects.Remove((IStatic)gameObject);
            }
            else
            {
                dynamicObjects.Remove((IDynamic)gameObject);
            }
        }
        public void Add(IObject gameObject)
        {
            if (gameObject is IStatic)
            {
                staticObjects.Add((IStatic)gameObject);
            }
            else
            {
                dynamicObjects.Add((IDynamic)gameObject);
            }
        }
        /*  The following methods might not be put in the ObjetcsManager class
         *  They will be refactored later
         */
        public void ChangeObject(IObject oldObject, IObject newObject)
        {
            if (oldObject is IStatic)
            {
                staticObjects.Remove((IStatic)oldObject);
                staticObjects.Add((IStatic)newObject);
            }
            else
            {
                dynamicObjects.Remove((IDynamic)oldObject);
                dynamicObjects.Add((IDynamic)newObject);
            }
        }
        public void RemoveDecoration(IMario oldMario, IMario newMario)
        {
            dynamicObjects.Remove(oldMario);
            dynamicObjects.Add(newMario);
        }
        public void StarMario(IMario mario)
        {
            int index = dynamicObjects.IndexOf(mario);
            if (mario is FlashingMario)
            {
                mario.Timer = 0;
                mario.Update(time);
            }
            dynamicObjects[index] = new StarMario((IMario)dynamicObjects[index]); 
            // the usage of indeof is necessary here
            // if mario is flashing and hits a star
            // mario will end flashing state then become star mario
        }

        public IMario MarioObject()
        {
            return (IMario)dynamicObjects[0];
        }
    }
}
