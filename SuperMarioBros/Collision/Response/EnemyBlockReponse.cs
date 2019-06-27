using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Collisions
{
    public class EnemyBlockResponse : GeneralResponse
    {
        private readonly IEnemy enemy;
        private readonly IBlock block;
        private readonly Direction direction;
        private delegate void MarioBlockHandler (IEnemy enemy, IBlock block);

        public EnemyBlockResponse(IObject enemy, IObject block, Direction direction)
        {
            this.enemy = (IEnemy)enemy;
            this.block = (IBlock)block;
            this.direction = direction;
        }
        public override void HandleCollision()
        {
            if (!(block is HiddenBlock))
            {
                ResolveOverlap(enemy, block, direction);
                switch (direction)
                {
                    case Direction.top: EnemyVsBlockTopCollision(); break;
                    case Direction.bottom: GroundOrTopBounce(enemy); break;
                    default: LeftOrRightBounce(enemy); enemy.ChangeDirection(); break;
                }
            }
        }
        private void EnemyVsBlockTopCollision()
        {
            if(block.State is BumpedState)
            {
                if(enemy is Koopa)
                    enemy.Stomped();
                enemy.Flipped();
                enemy.ObjState = ObjectState.NonCollidable;
            }
            else
            {
                OnGround(enemy);
            }
        }
    }
}
