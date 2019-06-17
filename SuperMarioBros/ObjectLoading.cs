using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using SuperMarioBros.Blocks;
using SuperMarioBros.Items;
using SuperMarioBros.LevelLoading;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
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
                new Star(new Vector2(200,400))
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
                new RockBlock(new Vector2(100,410)),
                new RockBlock(new Vector2(100,370)),
                new RockBlock(new Vector2(100,330)),
                
                new RockBlock(new Vector2(140, 330)),
                new RockBlock(new Vector2(180, 330)),
                new RockBlock(new Vector2(220, 330)),
                new RockBlock(new Vector2(260, 330)),

                new RockBlock(new Vector2(260,330)),
                new RockBlock(new Vector2(260,370)),
                new RockBlock(new Vector2(260,410)),

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
