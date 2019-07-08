using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Cameras;
using SuperMarioBros.HeadsUps;
using SuperMarioBros.Loading;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Managers
{
    public class ObjectsManager
    {
        public List<IStatic> StaticObjects { get; private set; }
        public List<IDynamic> DynamicObjects{ get; private set; }
        private readonly List<IObject> NonCollidableObjects;
        public IMario Mario { get; private set; }
        public ObjectLoader ObjectLoader { get; private set; }
        private readonly DynamicLoader dynamicLoader;
        private readonly MarioGame game;
        private readonly Camera gameCamera;
        public ObjectsManager(ObjectLoader objectLoader, MarioGame game, Camera camera) {
            StaticObjects = new List<IStatic>();
            DynamicObjects = new List<IDynamic>();
            NonCollidableObjects = new List<IObject>();
            ObjectLoader = objectLoader;
            Mario = objectLoader.Mario;
            dynamicLoader = new DynamicLoader(game, objectLoader, this);
            gameCamera = camera;
            this.game = game;
        }
        public void Initialize()
        {
            StaticObjects.Clear();
            DynamicObjects.Clear();
            NonCollidableObjects.Clear();
            dynamicLoader.Initialize();
        }

        public void Update(GameTime gameTime)
        {
            dynamicLoader.Load(gameCamera.RightBound + 100); // We set the load range to 100.
            if (Mario.Position.X < gameCamera.LeftBound)
            {
                Mario.Position = new Vector2(gameCamera.LeftBound, Mario.Position.Y);
            }
            for (int i = (StaticObjects.Count - 1); i >= 0 && i < StaticObjects.Count; i--)
            {
                IStatic obj = StaticObjects[i];
                BoundaryCheck(obj);
                obj.Update(gameTime);
                if (obj.ObjState == ObjectState.Destroy) DestroyFromManager(obj);
                if (obj.ObjState == ObjectState.NonCollidable) MoveToNonCollidable(obj);
            }
            for (int i = (DynamicObjects.Count - 1); i >= 0 && i < DynamicObjects.Count; i--)
            {
                IDynamic obj = DynamicObjects[i];
                BoundaryCheck(obj);
                obj.Update(gameTime);
                if (obj.ObjState == ObjectState.Destroy) DestroyFromManager(obj);
                if (obj.ObjState == ObjectState.NonCollidable) MoveToNonCollidable(obj);
            }
            for (int i = (NonCollidableObjects.Count - 1); i >= 0 && i < NonCollidableObjects.Count; i--)
            {
                BoundaryCheck(NonCollidableObjects[i]);
                IObject obj;
                if (NonCollidableObjects[i] is IStatic)
                {
                    obj = (IStatic)NonCollidableObjects[i];
                    ((IStatic)obj).Update(gameTime);
                }
                else
                {
                    obj = (IDynamic)NonCollidableObjects[i];
                    ((IDynamic)obj).Update(gameTime);
                }
                if (obj.ObjState == ObjectState.Destroy) DestroyFromNonCollidable(obj);
                if (obj.ObjState == ObjectState.Normal) MoveToCollidable(obj);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IStatic obj in StaticObjects)
                obj.Draw(spriteBatch);
            foreach (IDynamic obj in DynamicObjects)
                obj.Draw(spriteBatch);
            foreach (IObject obj in NonCollidableObjects)
                obj.Draw(spriteBatch);
        }

        //public void LevelLoading()
        //{
        //    ObjectLoader.LevelLoading();
        //}
        private void DestroyFromManager(IDynamic gameObject)
        {
            DynamicObjects.Remove(gameObject);
            gameObject.Destroy();
        }
        private void DestroyFromManager(IStatic gameObject)
        {
            StaticObjects.Remove(gameObject);
            gameObject.Destroy();
        }
        private void DestroyFromNonCollidable(IObject gameObject)
        {
            NonCollidableObjects.Remove(gameObject);
            gameObject.Destroy();
        }

        private void MoveToNonCollidable(IObject gameObject)
        {
            NonCollidableObjects.Add(gameObject);
            if (gameObject is IDynamic) DynamicObjects.Remove((IDynamic)gameObject);
            if (gameObject is IStatic) StaticObjects.Remove((IStatic)gameObject);
        }
        private void MoveToCollidable(IObject gameObject)
        {
            NonCollidableObjects.Remove(gameObject);
            if (gameObject is IDynamic) DynamicObjects.Add((IDynamic)gameObject);
            if (gameObject is IStatic) StaticObjects.Add((IStatic)gameObject);
        }

        public void AddObject(IStatic gameObject)
        {
            StaticObjects.Add(gameObject);
        }
        public void AddObject(IDynamic gameObject)
        {
            DynamicObjects.Add(gameObject);
        }
        public void AddNonCollidableObject(IObject gameObject)
        {
            NonCollidableObjects.Add(gameObject);
        }

        public void CreateObject(Type type, Vector2 position)
        {
            IObject obj = (IObject)Activator.CreateInstance(type, position);
            if (obj is IStatic) StaticObjects.Add((IStatic)obj);
            if (obj is IDynamic) DynamicObjects.Add((IDynamic)obj);
        }

        public void CreateNonCollidableObject(Type type, Vector2 position)
        {
            IObject obj = (IObject)Activator.CreateInstance(type, position);
            obj.ObjState = ObjectState.NonCollidable;
            NonCollidableObjects.Add(obj);
        }
        public IMario MarioObject()
        {
            return Mario; /* for controller bind mario as receiver */
        }
        public void SetMario(IMario mario)
        {
            Mario = mario;
            DynamicObjects.Add(mario);
        }
        private void BoundaryCheck(IObject obj)
        {
            if (obj.Position.Y > game.WindowHeight + 100) obj.ObjState = ObjectState.Destroy;
            if (obj.Position.X < gameCamera.LeftBound - 300) obj.ObjState = ObjectState.Destroy;
            if (obj.Position.X > gameCamera.RightBound + 300) obj.ObjState = ObjectState.Destroy;
        }
    }
}
