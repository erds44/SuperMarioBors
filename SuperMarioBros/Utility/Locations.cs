using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Utility
{
    public static class Locations
    {
        public readonly static Vector2 CoinOffset = new Vector2(12, -50);
        public readonly static Vector2 ItemOffset = new Vector2(1, 0); /* includes muhsrooms, star, flower */
        public readonly static Vector2 FlagOffset = new Vector2(68, -130);
        public readonly static Vector2 LeftTopDebrisOffset = new Vector2(0, -40);
        public readonly static Vector2 LeftBottomDebrisOffset = new Vector2(0, 0);
        public readonly static Vector2 RightTopDebrisOffset = new Vector2(20, -40);
        public readonly static Vector2 RightBottomDebrisOffset = new Vector2(20, 0);
        public readonly static Vector2 BumpedBlockOffset = new Vector2(0, -20);
        public readonly static Vector2 FireBallExplosionOffSet = new Vector2(-16, 0);
        public readonly static Vector2 MarioLeftCrouchingOffset = new Vector2(-22, -22);
        public readonly static Vector2 MarioRightNormalOffSet = new Vector2(52, -32);
        public readonly static Vector2 MarioRightCrouchingOffset = new Vector2(52, -22);
        public readonly static Vector2 MarioOffset = new Vector2(-22, -32);
        public readonly static Vector2 MarioJumpOffFlagOffSet = new Vector2(20, 0);
        public readonly static Vector2 MarioInitialLocation = new Vector2(0, 410);
        public static readonly Vector2 MarioFlagOffset = new Vector2(14, 0);
        public const float ScoreOffset = -60f;
        public const float CastleOffset = 94f;
        public const int FireBallOffSet = 16;
        public const float FlagBottomOffset = 255f;
        public const float WinFlagOffset = 28f;
        public const float FlagYAxisOffset = 88;

    }
}
