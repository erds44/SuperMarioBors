using Microsoft.Xna.Framework;

namespace SuperMarioBros.Stats
{
    public class CoinStats
    {
        public int currentCoin { get; private set; }
        public CoinStats()
        {
            currentCoin = 0;
        }
        public void Reset()
        {
            currentCoin = 0;
        }
        
        public void CoinCollected()
        {
            currentCoin++;
        }
       
    }
}
