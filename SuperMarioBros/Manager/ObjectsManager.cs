using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.GameCoreComponents;
using SuperMarioBros.Loading;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Managers
{
    public class ObjectsManager
    {
        public MarioGame Game { get => ObjectLoader.Game;}
        //change to private later
        public List<IStatic> staticObjects { get; private set; }
        public List<IDynamic> dynamicObjects{ get; private set; }
        private List<IObject> nonCollidableObjects;
        public IMario Mario { get; private set; }
        public static ObjectsManager Instance { get => instance; }
        private static ObjectsManager instance; //Shouldn't use singleton but currently this is the only solution.
        public ObjectLoader ObjectLoader { get; private set; }
        private readonly DynamicLoader dynamicLoader;
        public ObjectsManager(ObjectLoader objectLoader) {
            instance = this;
            staticObjects = new List<IStatic>();
            dynamicObjects = new List<IDynamic>();
            nonCollidableObjects = new List<IObject>();
            ObjectLoader = objectLoader;
            Mario = objectLoader.Mario;
            dynamicLoader = new DynamicLoader(this, objectLoader);
        }
        public void Initialize()
        {
            staticObjects.Clear();
            dynamicObjects.Clear();
            nonCollidableObjects.Clear();
            dynamicLoader.Initialize();
        }

        public void Update(GameTime gameTime)
        {
            dynamicLoader.Load(Game.Camera.RightBound + 100); // We set the load range to 100.
            if (Mario.Position.X < Game.Camera.LeftBound)
            {
                Mario.Position = new Vector2(Game.Camera.LeftBound, Mario.Position.Y);
            }
            //if (dynamicObjects[0] != Mario) dynamicObjects.Insert(0, Mario); //Not working. At least the game doesn't crash due to Mario's death.
            for (int i = (staticObjects.Count - 1); i >= 0 && i < staticObjects.Count; i--)
            {
                IStatic obj = staticObjects[i];
                BoundaryCheck(obj);
                obj.Update(gameTime);
                if (obj.ObjState == ObjectState.Destroy) DestroyFromManager(obj);
                if (obj.ObjState == ObjectState.NonCollidable) MoveToNonCollidable(obj);
            }
            for (int i = (dynamicObjects.Count - 1); i >= 0 && i < dynamicObjects.Count; i--)
            {
                IDynamic obj = dynamicObjects[i];
                BoundaryCheck(obj);
                obj.Update(gameTime);
                if (obj.ObjState == ObjectState.Destroy) DestroyFromManager(obj);
                if (obj.ObjState == ObjectState.NonCollidable) MoveToNonCollidable(obj);
            }
            for (int i = (nonCollidableObjects.Count - 1); i >= 0 && i < nonCollidableObjects.Count; i--)
            {
                BoundaryCheck(nonCollidableObjects[i]);
                IObject obj;
                if (nonCollidableObjects[i] is IStatic)
                {
                    obj = (IStatic)nonCollidableObjects[i];
                    ((IStatic)obj).Update(gameTime);
                }
                else
                {
                    obj = (IDynamic)nonCollidableObjects[i];
                    ((IDynamic)obj).Update(gameTime);
                }
                if (obj.ObjState == ObjectState.Destroy) DestroyFromNonCollidable(obj);
                if (obj.ObjState == ObjectState.Normal) MoveToCollidable(obj);
            }

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

        public void LevelLoading(ContentManager content, string path)
        {
            ObjectLoader.LevelLoading(content, path);
        }
        private void DestroyFromManager(IDynamic gameObject)
        {
            dynamicObjects.Remove(gameObject);
            gameObject.Destroy();
        }
        private void DestroyFromManager(IStatic gameObject)
        {
            staticObjects.Remove(gameObject);
            gameObject.Destroy();
        }
        private void DestroyFromNonCollidable(IObject gameObject)
        {
            nonCollidableObjects.Remove(gameObject);
            gameObject.Destroy();
        }

        private void MoveToNonCollidable(IObject gameObject)
        {
            nonCollidableObjects.Add(gameObject);
            if (gameObject is IDynamic) dynamicObjects.Remove((IDynamic)gameObject);
            if (gameObject is IStatic) staticObjects.Remove((IStatic)gameObject);
        }
        private void MoveToCollidable(IObject gameObject)
        {
            nonCollidableObjects.Remove(gameObject);
            if (gameObject is IDynamic) dynamicObjects.Add((IDynamic)gameObject);
            if (gameObject is IStatic) staticObjects.Add((IStatic)gameObject);
        }

        public void AddObject(IStatic gameObject)
        {
            staticObjects.Add(gameObject);
        }
        public void AddObject(IDynamic gameObject)
        {
            dynamicObjects.Add(gameObject);
        }
        public void AddNonCollidableObject(IObject gameObject)
        {
            nonCollidableObjects.Add(gameObject);
        }

        public void CreateObject(Type type, Vector2 position)
        {
            IObject obj = (IObject)Activator.CreateInstance(type, position);
            if (obj is IStatic) staticObjects.Add((IStatic)obj);
            if (obj is IDynamic) dynamicObjects.Add((IDynamic)obj);
        }

        public void CreateNonCollidableObject(Type type, Vector2 position)
        {
            IObject obj = (IObject)Activator.CreateInstance(type, position);
            obj.ObjState = ObjectState.NonCollidable;
            nonCollidableObjects.Add(obj);
        }
        public IMario MarioObject()
        {
            return Mario; /* for controller bind mario as receiver */
        }
        public void SetMario(IMario mario)
        {
            Mario = mario;
            dynamicObjects.Add(mario);
        }
        private void BoundaryCheck(IObject obj)
        {
            if (obj.Position.Y > MarioGame.WindowHeight + 100) obj.ObjState = ObjectState.Destroy;
            if (obj.Position.X < Game.Camera.LeftBound - 300) obj.ObjState = ObjectState.Destroy;
            if (obj.Position.X > Game.Camera.RightBound + 300) obj.ObjState = ObjectState.Destroy;
        }
    }
}
