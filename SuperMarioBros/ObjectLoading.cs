using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.Blocks;
using SuperMarioBros.Goombas;
using SuperMarioBros.Items;
using SuperMarioBros.Koopas;
using SuperMarioBros.LoadingTest;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMarioBros
{
    public static class ObjectLoading
    {
        private static List<IStatic> statics;
        private static List<IDynamic> dynamics;
        private static List<IObject> nonCollidableObjects;
        public static IMario mario;
        public static int LevelLength { get; private set; }
        public static void LevelLoading(ContentManager content, string path)
        {
            mario = new Mario(new Vector2(0, 410));
/*            nonCollidableObjects = new List<IObject>
            {

            };
            dynamics = new List<IDynamic>
            {
                //new Goomba(new Vector2(550, 410)),
                //new Koopa(new Vector2(200, 410)),
                new Goomba(new Vector2(2000,40)),
                new Goomba(new Vector2(2200,410)),
                new Koopa(new Vector2(1800,40)),
                new RedMushroom(new Vector2(60, 400)),
                new Koopa(new Vector2(550, 410)),
                //new Goomba(new Vector2(500, 60)), 
                //new Koopa(new Vector2(600, 60))
            };
            statics = new List<IStatic>
            {
                new Pipe(new Vector2(420,410)),
                new Pipe(new Vector2(700,410)),

                new QuestionBlock(new Vector2(0, 290)),
                new ItemBrickBlock(new Vector2(100, 290), typeof(Star), 1),

                new PowerUpBlock(new Vector2(200, 290)),
                new QuestionBlock(new Vector2(240, 290), typeof(GreenMushroom)),
                new BrickBlock(new Vector2(280, 290)),
                new BrickBlock(new Vector2(320, 290)),

                new HiddenBlock(new Vector2(50, 150)),            
                new QuestionBlock(new Vector2(520, 250)),
                new QuestionBlock(new Vector2(560, 250)),
                new BrickBlock(new Vector2(440, 60)),
                new BrickBlock(new Vector2(720, 60))
            };*/

            XMLProcessor xml = new XMLProcessor();

            statics = xml.StaticList();
            dynamics = xml.DynamicList();
            nonCollidableObjects = xml.NonCollidableList();
            //for (int i = 0; i < 80; i++)
            //{
            //    statics.Add(new RockBlock(new Vector2(0 + 40 * i, 450)));
            //    statics.Add(new RockBlock(new Vector2(0 + 40 * i, 490)));
            //}
            //for (int i = 0; i < 6; i++)
            //    statics.Add(new BrickBlock(new Vector2(480 + 40 * i, 100)));
        }
        public static List<IStatic> LoadStatics()
        {
            return statics;
        }
        public static List<IDynamic> LoadDynamics()
        {
            return dynamics;
        }
        public static List<IObject> LoadNonCollidable()
        {
            return nonCollidableObjects;
        }
    }
}
