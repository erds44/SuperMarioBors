using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.Blocks;
using SuperMarioBros.Goombas;
using SuperMarioBros.Items;
using SuperMarioBros.Koopas;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System.Collections.ObjectModel;

namespace SuperMarioBros
{
    public static class ObjectLoading
    {
        private static Collection<IStatic> statics;
        private static Collection<IDynamic> dynamics;
        public static void LevelLoading(ContentManager content, string path)
        {
            dynamics = new Collection<IDynamic>
            {
                new Mario(new Vector2(0, 410)),
                new Star(new Vector2(200,400)),
                new RedMushroom(new Vector2(240,290)),
                new GreenMushroom(new Vector2(200,400)),
                new Flower(new Vector2(300,400)),
               // new Koopa(new Vector2(450, 410)),
                new Goomba(new Vector2(550, 410)),
                new Koopa(new Vector2(600, 410)),
                new Goomba(new Vector2(500, 60)),
                new Koopa(new Vector2(600, 60))
            };
            statics = new Collection<IStatic>
            {
                new Pipe(new Vector2(420,410)),
                new Pipe(new Vector2(700,410)),
                new BrickBlock(new Vector2(0, 290)),
                new BrickBlock(new Vector2(100, 290)),
                new QuestionBlock(new Vector2(200, 290)),
                new QuestionBlock(new Vector2(240, 290)),
                new QuestionBlock(new Vector2(280, 290)),
                new QuestionBlock(new Vector2(320, 290)),
                new HiddenBlock(new Vector2(50, 150)),
                new QuestionBlock(new Vector2(520, 250)),
                new QuestionBlock(new Vector2(560, 250)),
                new BrickBlock(new Vector2(440, 60)),
                new BrickBlock(new Vector2(720, 60))
            };
            for (int i = 0; i < 20; i++)
                statics.Add(new RockBlock(new Vector2(0 + 40 * i, 450)));
            for (int i = 0; i < 6; i++)
                statics.Add(new BrickBlock(new Vector2(480 + 40 * i, 100)));
        }
        public static Collection<IStatic> LoadStatics()
        {
            return statics;
        }
        public static Collection<IDynamic> LoadDynamics()
        {
            return dynamics;
        }
    }
}
