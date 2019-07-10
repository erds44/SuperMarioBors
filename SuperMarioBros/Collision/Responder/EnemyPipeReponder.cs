using SuperMarioBros.Object.Pipes;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class EnemyPipeResponder : EnemyPipeCollisionHandler, ICollisionResponder
    {
        private delegate void EnemyPipeHandler(IEnemy enemy, IPipe pipe, Direction direction);
        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            IEnemy enemy = (IEnemy)mover;
            IPipe pipe = (IPipe)target;
            if (handlerDictionary.ContainsKey(direction))
                handlerDictionary[direction](enemy, pipe, direction);
        }
        private readonly Dictionary<Direction, EnemyPipeHandler> handlerDictionary = new Dictionary<Direction, EnemyPipeHandler>
        {
            { Direction.top, MoverOnGround},
            { Direction.left, EnemyHorizontalBounce},
            { Direction.right, EnemyHorizontalBounce},
            { Direction.bottom, MoverVerticallyBounce},
        };
    }
}
