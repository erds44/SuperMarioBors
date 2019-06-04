using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Classes.Collision;
using SuperMarioBros.Classes.Objects.GoombaObject;
using SuperMarioBros.Classes.Objects.ItemObject;
using SuperMarioBros.Classes.Objects.KoopaObject;
using SuperMarioBros.Classes.Objects.MushroomObject;
using SuperMarioBros.Interfaces;
using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Classes.Object
{
    class ObjectsManager
    {
        private List<IObject> enermy;
        //private List<IObject> block;
        private List<IMushroom> mushroom;
        private List<IObject> item;
        private readonly IMario mario;
        public ObjectsManager(IMario mario)
        {
            this.mario = mario;
            Initialize();
        }
        private void Initialize()
        {
            enermy = new List<IObject>
            {
                new GoombaObject(new Vector2(100, 100)),
                new KoopaObject(new Vector2(100, 225))
            };
            mushroom = new List<IMushroom>
            {
                new Mushroom(new Vector2(100, 50), 20, 120, "Green"),
                new Mushroom(new Vector2(150, 50), 150, 250, "Red"),
                new Mushroom(new Vector2(400, 50), 150, 250, "Red")
            };
            item = new List<IObject>
            {
                new FlowerObject(new Vector2(200, 50))
            };
            
            
                
        }
        public void Update()
        {
            mario.Update();
            enermy.ForEach(element => element.Update());
            mushroom.ForEach(element => element.Update());
            item.ForEach(element => element.Update());
            CollisionAgainstMushroom();

            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Draw(spriteBatch);
            enermy.ForEach(element => element.Draw(spriteBatch));
            mushroom.ForEach(element => element.Draw(spriteBatch));
            item.ForEach(element => element.Draw(spriteBatch));
        }
        private void CollisionAgainstMushroom()
        {
            for (int i = 0; i < mushroom.Count; i++)
            {
               if(MarioMushroomCollisionHandler.HandleCollision(mario, mushroom[i], CollisionDetection.Detect(mario, mushroom[i])))
                {
                    mushroom.RemoveAt(i);
                }
            }
        }

    }
}
