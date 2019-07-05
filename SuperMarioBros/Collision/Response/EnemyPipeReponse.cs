using SuperMarioBros.Object.Pipes;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Collisions
{
    public class EnemyPipeResponse : GeneralResponse
    {
        private readonly IEnemy enemy;
        private readonly IPipe pipe;
        private readonly Direction direction;
        private delegate void MarioBlockHandler(IEnemy enemy, IPipe pipe);

        public EnemyPipeResponse(IObject enemy, IObject pipe, Direction direction)
        {
            this.enemy = (IEnemy)enemy;
            this.pipe = (IPipe)pipe;
            this.direction = direction;
        }
        public override void HandleCollision()
        {
            ResolveOverlap(enemy, pipe, direction);
            switch (direction)
            {
                case Direction.top: OnGround(enemy); break;
                case Direction.bottom: GroundOrTopBounce(enemy); break;
                default: LeftOrRightBounce(enemy); enemy.ChangeDirection(); break;
            }
        }
    }
}
