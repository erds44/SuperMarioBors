using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.Blocks;
using SuperMarioBros.Items;
using SuperMarioBros.LoadingTest;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System.Collections.Generic;

namespace SuperMarioBros.Loading
{
    public class ObjectLoader
    {
        public MarioGame Game { get; }
        public List<IStatic> Statics { get; private set; }
        public List<IDynamic> Dynamics { get; private set; }
        public List<IObject> NonCollidables { get; private set; }
        public IMario Mario { get; private set; }
        public int LevelLength { get; private set; }
        public ObjectLoader(MarioGame game)
        {
            this.Game = game;
        }
        public void LevelLoading(ContentManager content, string path)
        {
            Mario = new Mario(new Vector2(0, 410), Game);
            // For test use.
            NonCollidables = new List<IObject>
            {

            };
            Dynamics = new List<IDynamic>
             {
                            new Goomba(new Vector2(550, 410)),
                           // new Koopa(new Vector2(200, 410)),
                            //new Goomba(new Vector2(2000,40)),
                            //new Goomba(new Vector2(2200,410)),
                            //new Koopa(new Vector2(1800,40)),
                            new RedMushroom(new Vector2(60, 400)),
                            new Koopa(new Vector2(400, 410)),
                            new Goomba(new Vector2(500, 60)),
                            //new Koopa(new Vector2(600, 60))
                        };
            Statics = new List<IStatic>
                        {
                            new Pipe(new Vector2(420,410)),
                            new Pipe(new Vector2(700,410)),

                            new QuestionBlock(new Vector2(0, 290), null),
                            new ItemBrickBlock(new Vector2(100, 290), typeof(Star), 1),

                            new QuestionBlock(new Vector2(240, 290), typeof(GreenMushroom)),
                            new BrickBlock(new Vector2(280, 290)),
                            new BrickBlock(new Vector2(320, 290)),

                            new HiddenBlock(new Vector2(50, 150), typeof(GreenMushroom)),
                            new QuestionBlock(new Vector2(520, 250), null),
                            new QuestionBlock(new Vector2(560, 250), null),
                            new BrickBlock(new Vector2(440, 60)),
                            new BrickBlock(new Vector2(720, 60))
                        };

            //XMLProcessor xml = new XMLProcessor();

            //Statics = xml.StaticList();
            //Dynamics = xml.DynamicList();
            //NonCollidables = xml.NonCollidableList();
            for (int i = 0; i < 80; i++)
            {
                Statics.Add(new RockBlock(new Vector2(0 + 40 * i, 450)));
                Statics.Add(new RockBlock(new Vector2(0 + 40 * i, 490)));
            }
            for (int i = 0; i < 6; i++)
                Statics.Add(new BrickBlock(new Vector2(480 + 40 * i, 100)));
        }
    }
}
