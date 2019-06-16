using Microsoft.Xna.Framework;
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
        private static readonly Dictionary<(Type, Type, Direction), MarioEnemyHandler> collisionDictionary = new Dictionary<(Type, Type, Direction), MarioEnemyHandler>
        {
            { (typeof(Mario),typeof(Goomba), Direction.left),  new MarioEnemyHandler(MarioDamageEnemyUnchanged) },
            { (typeof(Mario),typeof(Goomba), Direction.right), new MarioEnemyHandler(MarioDamageEnemyUnchanged) },
            { (typeof(Mario),typeof(Goomba), Direction.bottom),new MarioEnemyHandler(MarioDamageEnemyUnchanged)},
            { (typeof(Mario),typeof(Goomba), Direction.top),   new MarioEnemyHandler(MarioUnchangedGoombaStomped)},
            { (typeof(Mario),typeof(StompedGoomba), Direction.none),  new MarioEnemyHandler(MarioUnchangedEnemyDisappear) },
            { (typeof(Mario),typeof(Koopa), Direction.left),   new MarioEnemyHandler(MarioDamageEnemyUnchanged) },
            { (typeof(Mario),typeof(Koopa), Direction.right),  new MarioEnemyHandler(MarioDamageEnemyUnchanged)},
            { (typeof(Mario),typeof(Koopa), Direction.bottom), new MarioEnemyHandler(MarioDamageEnemyUnchanged) },
            { (typeof(Mario),typeof(Koopa), Direction.top),    new MarioEnemyHandler(MarioUnchangedkoopaStomped)},
            { (typeof(Mario),typeof(StompedKoopa), Direction.top),    new MarioEnemyHandler(MarioObstacleEnemyUnchanged) },
            { (typeof(Mario),typeof(StompedKoopa), Direction.left),     new MarioEnemyHandler(MarioObstacleEnemyUnchanged)  },
            { (typeof(Mario),typeof(StompedKoopa), Direction.right),     new MarioEnemyHandler(MarioObstacleEnemyUnchanged)  },
            { (typeof(Mario),typeof(StompedKoopa), Direction.bottom),    new MarioEnemyHandler(MarioObstacleEnemyUnchanged)  },
            { (typeof(StarMario),typeof(Goomba), Direction.left),  new MarioEnemyHandler(MarioUnchangedEnemyDisappear) },
            { (typeof(StarMario),typeof(Goomba), Direction.right), new MarioEnemyHandler(MarioUnchangedEnemyDisappear)},
            { (typeof(StarMario),typeof(Goomba), Direction.bottom),new MarioEnemyHandler(MarioUnchangedEnemyDisappear)},
            { (typeof(StarMario),typeof(Goomba), Direction.top),   new MarioEnemyHandler(MarioUnchangedEnemyDisappear)},
            { (typeof(StarMario),typeof(Koopa), Direction.left),   new MarioEnemyHandler(MarioUnchangedEnemyDisappear) },
            { (typeof(StarMario),typeof(Koopa), Direction.right),  new MarioEnemyHandler(MarioUnchangedEnemyDisappear)},
            { (typeof(StarMario),typeof(Koopa), Direction.bottom), new MarioEnemyHandler(MarioUnchangedEnemyDisappear)},
            { (typeof(StarMario),typeof(Koopa), Direction.top),    new MarioEnemyHandler(MarioUnchangedEnemyDisappear)},
            { (typeof(StarMario),typeof(StompedKoopa), Direction.top),    new MarioEnemyHandler(MarioUnchangedEnemyDisappear) },
            { (typeof(StarMario),typeof(StompedKoopa), Direction.left),    new MarioEnemyHandler(MarioUnchangedEnemyDisappear)},
            { (typeof(StarMario),typeof(StompedKoopa), Direction.right),    new MarioEnemyHandler(MarioUnchangedEnemyDisappear)},
            { (typeof(StarMario),typeof(StompedKoopa), Direction.bottom),    new MarioEnemyHandler(MarioUnchangedEnemyDisappear)}


        };
        public static void HandleCollisionV1(IObject mario, IObject enemy, Direction direction)
        {
        /**
            if (collisionDictionary.TryGetValue((mario.GetType(), enemy.GetType(), direction), out var type))
            {
                //Type typ1 = type.Item1;
                //Type typ2 = type.Item2;
                if (typ1 != typeof(Nullable))
                {
                    ((ICommand)Activator.CreateInstance(typ1, (IMario)mario)).Execute();

                }

                if (typ2 != typeof(Nullable))
                {
                    ((ICommand)Activator.CreateInstance(typ2, (IEnemy)enemy)).Execute();
                }
            }
        **/

        }
        public static void HandleCollision(IMario mario, IObject enemy, Direction direction)
        {
            if (collisionDictionary.TryGetValue((mario.GetType(), enemy.GetType(), direction), out var handler))
            {
                handler(mario, enemy);
            }
        }
        private delegate void MarioEnemyHandler(IMario mario, IObject enemy);

        private static void MarioDamageEnemyUnchanged(IMario mario, IObject enemy)
        {
            mario.TakeDamage();
            ObjectsManager.Instance.DecorateMario(mario, new FlashingMario(mario));
        }
        private static void MarioUnchangedEnemyDisappear(IMario mario,IObject enemy)
        {
            ObjectsManager.Instance.Remove(enemy);
        }

        private static void MarioObstacleEnemyUnchanged(IMario mario, IObject enemy)
        {
            mario.Obstacle();
        }
        private static void MarioUnchangedGoombaStomped(IMario mario, IObject enemy)
        {
            ObjectsManager.Instance.ChangeObject(enemy, new StompedGoomba(new Point(enemy.HitBox().X, enemy.HitBox().Y + enemy.HitBox().Height)));
        }

        private static void MarioUnchangedkoopaStomped(IMario mario, IObject enemy)
        {
            ObjectsManager.Instance.ChangeObject(enemy, new StompedKoopa(new Point(enemy.HitBox().X, enemy.HitBox().Y + enemy.HitBox().Height)));
        }
    } 
}
