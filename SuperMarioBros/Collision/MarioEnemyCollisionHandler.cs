using SuperMarioBros.Commands;
using SuperMarioBros.Goombas;
using SuperMarioBros.Koopas;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
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
            { (typeof(StarMario),typeof(Goomba), Direction.left),  (typeof(Nullable),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Goomba), Direction.right), (typeof(Nullable),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Goomba), Direction.bottom),(typeof(Nullable),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Goomba), Direction.top),   (typeof(Nullable),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Koopa), Direction.left),   (typeof(Nullable),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Koopa), Direction.right),  (typeof(Nullable),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Koopa), Direction.bottom), (typeof(Nullable),typeof(DisappearCommand)) },
            { (typeof(StarMario),typeof(Koopa), Direction.top),    (typeof(Nullable),typeof(DisappearCommand)) }


        };
        public static  void HandleCollision(IObject mario,  IObject enemy, Direction direction)
        {
                if ( collisionDictionary.TryGetValue((mario.GetType(),enemy.GetType(), direction),  out var type ))
                {
                    Type typ1 = type.Item1;
                    Type typ2 = type.Item2;
                    if(typ1 != typeof(Nullable))
                    {
                       ((ICommand)Activator.CreateInstance(typ1, (IMario)mario)).Execute();

                    }

                    if(typ2 != typeof(Nullable))
                    {
                        ((ICommand)Activator.CreateInstance(typ2, (IEnemy)enemy)).Execute();
                    }       
                }

        }
    }
}
