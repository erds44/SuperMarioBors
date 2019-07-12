using SuperMarioBros.Marios;
using SuperMarioBros.Pipes;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class MarioPipeResponder : MarioPipeCollisionHandler, ICollisionResponder
    {
        private delegate void MarioBlockHandler(IMario mario, IPipe pipe, Direction direction);

        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            IMario mario = (IMario)mover;
            IPipe pipe = (IPipe)target;
            var key = (pipe.GetType(), pipe.Teleported, direction);
            if (handlerDictionary.ContainsKey(key))
                handlerDictionary[key](mario, pipe, direction);
        }

        private readonly Dictionary<(Type, bool, Direction), MarioBlockHandler> handlerDictionary = new Dictionary<(Type, bool, Direction), MarioBlockHandler>
        {
            { (typeof(Pipe), false, Direction.top), MarioVsRegularPipeTopOrBottomCollision},  
            { (typeof(Pipe), false, Direction.left), MarioVsRegularPipeLeftOrRightCollision},
            { (typeof(Pipe), false, Direction.right), MarioVsRegularPipeLeftOrRightCollision},
            { (typeof(Pipe), false, Direction.bottom), MarioVsRegularPipeTopOrBottomCollision},

            { (typeof(TeleportPipe), false, Direction.top), MarioVsTeleportPipeTopCollision},  
            { (typeof(TeleportPipe), false, Direction.left), MarioVsTeleportPipeLeftCollision},
            { (typeof(TeleportPipe), false, Direction.right), MarioVsTeleportPipeRightCollision},
        };
    }
}
