using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.GameCoreComponents;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Managers
{
    public class ObjectsManager
    {
        //change to private later
        public Collection<IStatic> staticObjects;
        private Collection<IDynamic> dynamicObjects;
        private Collection<IObject> nonCollidableObjects;
        public static ObjectsManager Instance { get; } = new ObjectsManager();
        private ObjectsManager() { }
        public void Initialize()
        {
            staticObjects = ObjectLoading.LoadStatics();
            dynamicObjects = ObjectLoading.LoadDynamics();
            nonCollidableObjects = ObjectLoading.LoadNonCollidable();
        }
        public void Update(GameTime gameTime)
        {
            for (int i = (staticObjects.Count - 1); i >= 0; i--)
            {
                staticObjects[i].Update();
                BoundaryCheck(staticObjects[i]);
                if (staticObjects[i].IsInvalid) RemoveFromStatic(staticObjects[i]);
            }
            for (int i = (dynamicObjects.Count - 1); i >= 0; i--)
            {
                dynamicObjects[i].Update(gameTime);
                BoundaryCheck(dynamicObjects[i]);
                if (dynamicObjects[i].IsInvalid) RemoveFromDynamic(dynamicObjects[i]);
            }
            for (int i = (nonCollidableObjects.Count - 1); i >= 0; i--)
            {
                System.Console.WriteLine(nonCollidableObjects[i]);
                if (nonCollidableObjects[i] is IStatic)
                    ((IStatic)nonCollidableObjects[i]).Update();
                else
                    ((IDynamic)nonCollidableObjects[i]).Update(gameTime);
            }

        }
        private void BoundaryCheck(IObject obj)
        {
                if (obj.Position.Y > MarioGame.WindowHeight + 100) obj.IsInvalid |= true;
                if (obj.Position.X < Camera.Instance.LeftBound - 100) obj.IsInvalid |= true;
                if (obj.Position.X > Camera.Instance.RightBound + 100) obj.IsInvalid |= true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IStatic obj in staticObjects)
                obj.Draw(spriteBatch);
            foreach (IDynamic obj in dynamicObjects)
                obj.Draw(spriteBatch);
            foreach (IObject obj in nonCollidableObjects)
                obj.Draw(spriteBatch);
        }


        public void RemoveFromStatic(IStatic gameObject)
        {
            gameObject.Destroy();
            staticObjects.Remove(gameObject);
        }
        public void RemoveFromDynamic(IDynamic gameObject)
        {
            gameObject.Destroy();
            dynamicObjects.Remove(gameObject);
        }
        public void MoveToNoncollidable(IObject gameObject)
        {
            if (gameObject is IDynamic) dynamicObjects.Remove((IDynamic)gameObject);
            if (gameObject is IStatic) dynamicObjects.Remove((IDynamic)gameObject);
            nonCollidableObjects.Add(gameObject);
        }
        public void RemoveFromNonCollidable(IObject gameObject)
        {
            nonCollidableObjects.Remove(gameObject);
        }
        public void AddNonCollidable(IObject gameObject)
        {
            nonCollidableObjects.Add(gameObject);
        }
        public void AddStatic(IStatic gameObject)
        {
            staticObjects.Add(gameObject);
        }
        public void AddDynamic(IDynamic gameObject)
        {
            dynamicObjects.Add(gameObject);
        }
        public void Decoration(IMario oldMario, IMario newMario)
        {
            int index = dynamicObjects.IndexOf(oldMario);
            dynamicObjects[index] = newMario;
        }
        public void StarMario(IMario mario)
        {
            int index = dynamicObjects.IndexOf(mario);
            ((IMario)dynamicObjects[index]).NoMovementTimer = 0;
            dynamicObjects[index] = new StarMario(mario);
        }
        public IMario MarioObject()
        {
            return (IMario)dynamicObjects[0]; /* for controller bind mario as receiver */
        }
    }
}
