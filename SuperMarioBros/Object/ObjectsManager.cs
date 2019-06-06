﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks;
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
                new GreenMushroom(new Point(100, 300)),
                new RedMushroom(new Point(200, 300)),
                new Flower(new Point(300, 300)),
                new Star(new Point(400,300)),
                new Pipe(new Point(600,300)),
                new Coin(new Point(500,300)),
                new Koopa(new Point(100,200)),
                new Goomba(new Point(200,200)),
                new BrickBlock(new Point(300,100)),
                new HiddenBlock(new Point(350, 100)),
                new RockBlock(new Point(400,100)),
                new QuestionBlock(new Point(450,100))
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
