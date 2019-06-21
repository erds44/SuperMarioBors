﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.GameCoreComponents;
using SuperMarioBros.Loading;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System.Collections.Generic;

namespace SuperMarioBros.Managers
{
    public class ObjectsManager
    {
        //change to private later
        public List<IStatic> staticObjects { get; private set; }
        public List<IDynamic> dynamicObjects{get; private set;}
        public List<IObject> nonCollidableObjects{get; private set;}
        public IMario Mario { get; private set ; }
        public static ObjectsManager Instance { get; } = new ObjectsManager();
        private ObjectsManager() {
            staticObjects = new List<IStatic>();
            dynamicObjects = new List<IDynamic>();
            nonCollidableObjects = new List<IObject>();
        }

        public void Update(GameTime gameTime)
        {
            for (int i = (staticObjects.Count - 1); i >= 0; i--)
            {
                IStatic obj = staticObjects[i];
                BoundaryCheck(obj);
                obj.Update();
                if (obj.IsInvalid) RemoveFromManager(obj);
            }
            for (int i = (dynamicObjects.Count - 1); i >= 0; i--)
            {
                IDynamic obj = dynamicObjects[i];
                BoundaryCheck(obj);
                obj.Update(gameTime);
                if (obj.IsInvalid) RemoveFromManager(obj);
            }
            for (int i = (nonCollidableObjects.Count - 1); i >= 0; i--)
            {
                BoundaryCheck(nonCollidableObjects[i]);
                IObject obj;
                if (nonCollidableObjects[i] is IStatic)
                {
                    obj = (IStatic)nonCollidableObjects[i];
                    ((IStatic)obj).Update();
                }
                else
                {
                    obj = (IDynamic)nonCollidableObjects[i];
                    ((IDynamic)obj).Update(gameTime);
                }
                if (obj.IsInvalid) RemoveFromNonCollidable(obj);
            }

        }
        private void BoundaryCheck(IObject obj)
        {
                if (obj.Position.Y > MarioGame.WindowHeight + 100) obj.IsInvalid |= true;
                if (obj.Position.X < Camera.Instance.LeftBound - 300) obj.IsInvalid |= true;
                if (obj.Position.X > Camera.Instance.RightBound + 300) obj.IsInvalid |= true;
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
        public void RemoveFromManager(IStatic gameObject)
        {
            gameObject.Destroy();
            staticObjects.Remove(gameObject);
        }
        public void RemoveFromManager(IDynamic gameObject)
        {
            gameObject.Destroy();
            dynamicObjects.Remove(gameObject);
        }
        public void MoveToNonCollidable(IObject gameObject)
        {
            if (gameObject is IDynamic) dynamicObjects.Remove((IDynamic)gameObject);
            if (gameObject is IStatic) dynamicObjects.Remove((IDynamic)gameObject);
            nonCollidableObjects.Add(gameObject);
        }
        public void RemoveFromNonCollidable(IObject gameObject)
        {
            gameObject.Destroy();
            nonCollidableObjects.Remove(gameObject);
        }
        public void AddNonCollidable(IObject gameObject)
        {
            nonCollidableObjects.Add(gameObject);
        }
        public void AddObject(IStatic gameObject)
        {
            staticObjects.Add(gameObject);
        }
        public void AddObject(IDynamic gameObject)
        {
            dynamicObjects.Add(gameObject);
        }

        internal void Initialize()
        {
            staticObjects.Clear();
            dynamicObjects.Clear();
            nonCollidableObjects.Clear();
            DynamicLoading.Instance.Initialize();
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
            return Mario; /* for controller bind mario as receiver */
        }
        public void SetMario(IMario mario)
        {
            Mario = mario;
            dynamicObjects.Add(mario);
        }
    }
}