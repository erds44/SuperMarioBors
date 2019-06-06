using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Objects
{
    public static class ObjectSizeManager
    {
        /* all the size infomation will not get from texture width and height any more 
           we have to predefine a size infomation
        */
        private readonly static Dictionary<Type, Point> objectDictionary = new Dictionary<Type, Point>
        {
           { typeof(Goomba), new Point(15,20) },
                // More to add
        };
        private readonly static Dictionary<(Type, Type), Point> marioDictionary = new Dictionary<(Type, Type), Point>
        {
           { (typeof(BigMario),typeof(LeftCrouchingMarioState)), new Point(1,1) }
            // more to add
        };

    }
}
