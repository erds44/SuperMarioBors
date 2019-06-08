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
            //this.mario = mario;
            //objects = new List<IObject>
            //{
            //    new GreenMushroom(new Point(100, 350)),
            //    new RedMushroom(new Point(200, 350)),
            //    new Flower(new Point(300, 350)),
            //    new Star(new Point(400,350)),
            //    new Pipe(new Point(600,350)),
            //    new Coin(new Point(500,350)),
            //    new Koopa(new Point(100,200)),
            //    new Goomba(new Point(200,200)),
            //    new Block(new BrickBlock(new Point(200,100))),
            //    new Block(new RockBlock(new Point(250,100))),
            //    new Block(new QuestionBlock(new Point(300,100))),
            //    new Block(new ConcreteBlock(new Point(350,100))),
            //    new Block(new HiddenBlock(new Point(400,100)))

            //};
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
