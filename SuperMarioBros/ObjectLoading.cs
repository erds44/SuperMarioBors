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
                new Mario(new Vector2(0, 400)),
                new Star(new Vector2(200,400)),
                new RedMushroom(new Vector2(100,400)),
                new GreenMushroom(new Vector2(200,400)),
                new Flower(new Vector2(300,400)),
                new Koopa(new Vector2(450, 410)),
                new Goomba(new Vector2(500, 410))
            };
            statics = new Collection<IStatic>
            {
                new RockBlock(new Vector2(0,450)),
                new RockBlock(new Vector2(40,450)),
                new RockBlock(new Vector2(80,450)),
                new RockBlock(new Vector2(120,450)),
                new RockBlock(new Vector2(160,450)),
                new RockBlock(new Vector2(200,450)),
                new RockBlock(new Vector2(240,450)),
                new RockBlock(new Vector2(280,450)),
                new RockBlock(new Vector2(320,450)),
                new RockBlock(new Vector2(360,450)),
                new RockBlock(new Vector2(400,450)),
                new RockBlock(new Vector2(440,450)),
                new RockBlock(new Vector2(480,450)),
                new RockBlock(new Vector2(520,450)),
                new RockBlock(new Vector2(560,450)),
                new RockBlock(new Vector2(600,450)),
                new RockBlock(new Vector2(640,450)),
                new RockBlock(new Vector2(680,450)),
                new Pipe(new Vector2(360,410)),
                new HiddenBlock(new Vector2 (0, 300)),
                new BrickBlock(new Vector2 (40, 300)),
                new ConcreteBlock(new Vector2 (80, 300)),
                new QuestionBlock(new Vector2 (120, 300)),

            };

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
