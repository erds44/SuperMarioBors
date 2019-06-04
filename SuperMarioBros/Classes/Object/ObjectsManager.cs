using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Classes.Collision;
using SuperMarioBros.Classes.Objects.ItemObject;
using SuperMarioBros.Classes.Objects.MushroomObject;
using SuperMarioBros.Interfaces.Object;
using System.Collections.Generic;

namespace SuperMarioBros.Classes.Object
{
    public class ObjectsManager
    {
        //private List<IObject> enermy;
        //private List<IObject> block;
        private List<IItem> items;
        private List<IStar> stars;
        private List<IItem> pipes;
        private IMario mario;
        public ObjectsManager(IMario mario)
        {
            this.mario = mario;
            Initialize();
        }
        private void Initialize()
        {
            //enermy = new List<IObject>
            //{
            //    new GoombaObject(new Vector2(100, 100)),
            //    new KoopaObject(new Vector2(100, 225))
            //};
            items = new List<IItem>
            {
                new GreenMushroom(new Vector2(100, 100), 20, 120),
                new RedMushroom(new Vector2(150, 100), 150, 250),
                new FlowerObject(new Vector2(300, 100))
            };
            stars = new List<IStar>
            {
                new StarObject(new Vector2(400,100))
            };
            pipes = new List<IItem>
            {
                new PipeObject(new Vector2(500,300))
            };
        }
        public void Update()
        {
            items.ForEach(element => element.Update());
            stars.ForEach(element => element.Update());
            pipes.ForEach(element => element.Update());
            mario.Update();
            CollisionAgainstItems();
            CollisionAgainstStars();
            CollisionAgainstPipes();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Draw(spriteBatch);
            items.ForEach(element => element.Draw(spriteBatch));
            stars.ForEach(element => element.Draw(spriteBatch));
            pipes.ForEach(element => element.Draw(spriteBatch));
        }
        private void CollisionAgainstItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
               if(MarioItemCollisionHandler.HandleCollision(mario, items[i], CollisionDetection.Detect(mario, items[i])))
                {
                    items.RemoveAt(i);
                }
            }
        }
        private void CollisionAgainstStars()
        {
            for (int i = 0; i < stars.Count; i++)
            {
                if (MarioStarCollisionHandler.HandleCollision(this, mario, stars[i], CollisionDetection.Detect(mario, stars[i])))
                {
                    stars.RemoveAt(i);
                }
            }
        }
        private void CollisionAgainstPipes()
        {
            for (int i = 0; i <pipes.Count; i++)
            {
                MarioItemCollisionHandler.HandleCollision(mario, pipes[i], CollisionDetection.Detect(mario, pipes[i]));
            }
        }
        public void DecorateMario(IMario mario)
        {
            this.mario = mario;
        }

    }
}
