using Microsoft.Xna.Framework;
using static SuperMarioBros.Utility.GeneralConstants;

namespace SuperMarioBros.Stats
{
    public class CoinStats
    {
        public int CurrentCoin { get; private set; }
        public CoinStats()
        {
            CurrentCoin = InitialCount;
        }
        public void Reset()
        {
            CurrentCoin = InitialCount;
        }
        
        public void CoinCollected()
        {
            CurrentCoin++;
        }
       
    }
}
