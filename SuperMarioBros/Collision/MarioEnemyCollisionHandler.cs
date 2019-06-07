using SuperMarioBros.Commands;
using SuperMarioBros.Goombas;
using SuperMarioBros.Koopas;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public static class MarioEnemyCollisionHandler
    {
        private static readonly Dictionary<(Type,Type,Direction),(Type,Type)> collisionDictionary = new Dictionary<(Type,Type, Direction), (Type, Type)>
        {
            { (typeof(Mario),typeof(Goomba), Direction.left),  (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Mario),typeof(Goomba), Direction.right), (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Mario),typeof(Goomba), Direction.bottom),(typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Mario),typeof(Goomba), Direction.top),   (typeof(Nullable),typeof(GoombaStompedCommand)) },
            { (typeof(Mario),typeof(StompedGoomba), Direction.none),  (typeof(Nullable),typeof(DisappearCommand)) },
            { (typeof(Mario),typeof(Koopa), Direction.left),   (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Mario),typeof(Koopa), Direction.right),  (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Mario),typeof(Koopa), Direction.bottom), (typeof(TakeDamageCommand),typeof(Nullable)) },
            { (typeof(Mario),typeof(Koopa), Direction.top),    (typeof(Nullable),typeof(KoopaStompedCommand)) },
            { (typeof(Mario),typeof(StompedKoopa), Direction.top),    (typeof(ObstacleCommand),typeof(Nullable)) },
            { (typeof(Mario),typeof(StompedKoopa), Direction.left),    (typeof(ObstacleCommand),typeof(Nullable)) },
            { (typeof(Mario),typeof(StompedKoopa), Direction.right),    (typeof(ObstacleCommand),typeof(Nullable)) },
            { (typeof(Mario),typeof(StompedKoopa), Direction.bottom),    (typeof(ObstacleCommand),typeof(Nullable)) },
            { (typeof(StarMario),typeof(Goomba), Direction.left),  (typeof(TakeDamageCommand),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Goomba), Direction.right), (typeof(TakeDamageCommand),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Goomba), Direction.bottom),(typeof(TakeDamageCommand),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Goomba), Direction.top),   (typeof(Nullable),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Koopa), Direction.left),   (typeof(TakeDamageCommand),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Koopa), Direction.right),  (typeof(TakeDamageCommand),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Koopa), Direction.bottom), (typeof(TakeDamageCommand),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Koopa), Direction.top),    (typeof(Nullable),typeof(DisappearCommand)) }


        };
        public static void HandleCollision(IMario mario,  IEnemy enemy, Direction direction, int index)
        {
                if ( collisionDictionary.TryGetValue((mario.GetType(),enemy.GetType(), direction),  out var type ))
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
