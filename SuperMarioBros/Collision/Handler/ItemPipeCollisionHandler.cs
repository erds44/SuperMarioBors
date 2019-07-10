using Microsoft.Xna.Framework;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Blocks;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Pipes;
using SuperMarioBros.Objects;
using System;

namespace SuperMarioBros.Collisions
{
    public class ItemPipeCollisionHandler : GeneralHandler
    {
        public static void FireExplosion(IItem item, IPipe pipe, Direction direction)
        {
            ((FireBall)item).FireExplosion();
        }
    }
}
