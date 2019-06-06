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
        private readonly static Dictionary<Type, Vector2> objectDictionary = new Dictionary<Type, Vector2>
        {
           { typeof(Goomba), new Vector2(15,20) },
                // More to add
        };
        private readonly static Dictionary<(Type, Type), Vector2> marioDictionary = new Dictionary<(Type, Type), Vector2>
        {
           { (typeof(BigMario),typeof(LeftCrouchingMarioState)), new Vector2(1,1) }
            // more to add
        };

    }
}
