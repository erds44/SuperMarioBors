using SuperMarioBros.Commands;
using SuperMarioBros.Goombas;
using SuperMarioBros.Koopas;
using SuperMarioBros.Marios;
using SuperMarioBros.Object.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public static class MarioEnemyCollisionHandler
    {
        private static readonly Dictionary<(Type,Direction),(Type,Type)> collisionDictionary = new Dictionary<(Type, Direction), (Type, Type)>
        {
            { (typeof(Goomba), Direction.left),  (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Goomba), Direction.right), (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Goomba), Direction.bottom),(typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Goomba), Direction.top),   (typeof(Nullable),typeof(StompedCommand)) },
            { (typeof(Koopa), Direction.left),   (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Koopa), Direction.right),  (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Koopa), Direction.bottom), (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Koopa), Direction.top),    (typeof(Nullable),typeof(StompedCommand)) }


        };
        public static bool HandleCollision(IMario mario, IEnemy enemy, Direction direction)
        {
            if (direction != Direction.none)
            {
                Console.WriteLine(direction);
                if ( collisionDictionary.TryGetValue((enemy.GetType(), direction),  out var type ))
                {
                    Type tpy1 = type.Item1;
                    Type tpy2 = type.Item2;
                    if( tpy1 == typeof(TakeDamageCommand))
                    {
                   
                        ((ICommand)Activator.CreateInstance(tpy1, mario)).Execute();
                    }
                    if(tpy2 == typeof(StompedCommand))
                    {
                        ((ICommand)Activator.CreateInstance(tpy2, enemy)).Execute();
                    }

                }
              
            }

            return false;
        }
    }
}
