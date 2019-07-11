using Microsoft.Xna.Framework;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Stats;

namespace SuperMarioBros.Collisions
{
    public class MarioItemCollisionHandler : GeneralHandler
    {
        private static readonly Vector2 marioFlagOffset = new Vector2(14, 0);
        public static void EnterCastle(IMario mario, IItem item)
        {
            mario.ObjState = ObjectState.Destroy;
        }

        public static void SlidingFlagPole(IMario mario, IItem item)
        {
            mario.SlidingFlagPole();
            if (mario.Position.Y <= 88)
                mario.Position = new Vector2(mario.Position.X, 88);
            mario.Position += marioFlagOffset;
            item.ObjState = ObjectState.NonCollidable;
            StatsManager.Instance.CollectFlagPopleScore(mario.Position);
        }

        public static void TakeStar(IMario mario, IItem item)
        {
            mario.TakeStar();
            item.ObjState = ObjectState.Destroy;
        }
        public static void TakeRedMushroom(IMario mario, IItem item)
        {
            mario.TakeRedMushroom();
            item.ObjState = ObjectState.Destroy;
            StatsManager.Instance.CollectPowerUp(item.Position);
            AudioFactory.Instance.CreateSound("powerup").Play();
        }
        public static void TakeFlower(IMario mario, IItem item)
        {
            mario.TakeFlower();
            item.ObjState = ObjectState.Destroy;
            StatsManager.Instance.CollectPowerUp(item.Position);
            AudioFactory.Instance.CreateSound("powerup").Play();
        }
        public static void TakeGreenMushroom(IMario mario, IItem item)
        {
            item.ObjState = ObjectState.Destroy;
            StatsManager.Instance.GainExtraLife(item.Position);
            AudioFactory.Instance.CreateSound("1up").Play();
        }
        public static void TakeCoin(IMario mario, IItem item)
        {
            item.ObjState = ObjectState.Destroy;
        }

        public static void TakeBigCoin(IMario mario, IItem item)
        {
            var coin = (BigCoin)item;
            coin.CoinCollectedEvent?.Invoke(coin.Position);
            item.ObjState = ObjectState.Destroy;
            StatsManager.Instance.CoinCollected(item.Position);
            AudioFactory.Instance.CreateSound("coin").Play();
        }
    }
}
