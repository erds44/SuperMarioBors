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
            { (typeof(Goomba), Direction.top),   (typeof(Nullable),typeof(GoombaStompedCommand)) },
            { (typeof(StompedGoomba), Direction.none),  (typeof(Nullable),typeof(EnemyDisappearCommand)) },
            { (typeof(Koopa), Direction.left),   (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Koopa), Direction.right),  (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Koopa), Direction.bottom), (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Koopa), Direction.top),    (typeof(Nullable),typeof(KoopaStompedCommand)) },
            { (typeof(StompedKoopa), Direction.top),    (typeof(ObstacleCommand),typeof(Nullable)) },
            { (typeof(StompedKoopa), Direction.left),    (typeof(ObstacleCommand),typeof(Nullable)) },
            { (typeof(StompedKoopa), Direction.right),    (typeof(ObstacleCommand),typeof(Nullable)) },
            { (typeof(StompedKoopa), Direction.bottom),    (typeof(ObstacleCommand),typeof(Nullable)) }


        };
        public static void HandleCollision(IMario mario,  IEnemy enemy, Direction direction, int index)
        {
                if ( collisionDictionary.TryGetValue((enemy.GetType(), direction),  out var type ))
                {
                Console.WriteLine(enemy);
                    Type typ1 = type.Item1;
                    Type typ2 = type.Item2;
                    if(typ1 != typeof(Nullable))
                    {
                        ((ICommand)Activator.CreateInstance(typ1, mario)).Execute();
                    }
                    if(typ2 != typeof(Nullable))
                    {
                        ((ICommand)Activator.CreateInstance(typ2, enemy, index)).Execute();
                    }       
            }

        }
    }
}
