using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Utility
{
    public static class Constants
    {
        /*General*/
        public const int DefaultEnmeyScore = 100;
        public const int ShelledKoopaScore = 500;
        public const int DefaultEnmeyCount = 0;
        public const int InitialEnmeyCount = 1;
        public const int InitialCount = 0;
        public const int FireBallCount = 2;
        public const int DefaultDelayScale = 5;
        public const int DefaultItemContained = 0;
        public const int HorizontalLine = 1;
        public const int LeftTriangle = 3;
        public const int RightTriangle = 2;
        public const int VerticalLine = 4;

        /*Locations*/
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
        public const float ScoreOffset = -60f;
        public const float CastleOffset = 94f;
        public const int FireBallOffSet = 16;
        public const float FlagBottomOffset = 255f;
        public const float WinFlagOffset = 28f;

        /*Physics*/
        public const float DecayRatio = 0.96f;
        public const float DefaultAccelaration = 0f;
        public const float DecelarationScale = 2f;
        public const float GravityDecrement = 20f;
        public const float MinGravity = 280f;
        public const float MaxClamping = 200f;
        public const float MinClamping = -200f;
        public const float JumpVelocity = -450f;
        public const float DefaultSprintVelocityRate = 1f;
        public const float PoweredMarioSprintVelocityRate = 1.2f;
        public const float ZeroGravity = 0f;
        public const float ZeroWeight = 0f;
        public const float EnemyGravity = 800f;
        public const float EnemyWeight = 200f;
        public const float ItemGravity = 800f;
        public const float ItemWeight = 20f;
        public const float ItemPeak = 45f;
        public const float BigCoinGravity = 0f;
        public const float CoinGravity = 100f;
        public const float FireBallGravity = 600f;
        public const float FireBallWeight = 20f;
        public const float FlagGravity = 300f;
        public const float FlagWeight = 0f;
        public const float StarGravity = 200f;
        public const float SlidingMarioGravity = 100f;
        public const float MarioJumpingSpeed = 40f;
        public const float MarioGravity = 800f;
        public const float MarioWeight = 200f;
        public const float MarioAcceleration = 150f;
        public const float BumpedVelocity = -180f;
        public const int ZeroVelocity = 0;

        public readonly static Vector2 IdleVelocity = new Vector2(0, 0);
        public readonly static Vector2 BumpedBlockInitialVelocity = new Vector2(0, -150);
        public readonly static Vector2 LeftMovingGoombaVelocity = new Vector2(-60, 0);
        public readonly static Vector2 RightMovingGoombaVelocity = new Vector2(60, 0);
        public readonly static Vector2 LeftMovingNormalKoopaVelocity = new Vector2(-80, 0);
        public readonly static Vector2 LeftMovingShelledKoopaVelocity = new Vector2(-160, 0);
        public readonly static Vector2 RightMovingNormalKoopaVelocity = new Vector2(80, 0);
        public readonly static Vector2 RightMovingShelledKoopaVelocity = new Vector2(160, 0);
        public readonly static Vector2 EnemyInitialVelocity = new Vector2(-30, 0);
        public readonly static Vector2 ItemInitialVelocity = new Vector2(0, -180);
        public readonly static Vector2 ItemCollidableVelocity = new Vector2(40, 0);
        public readonly static Vector2 BigCoinInitialVelocity = new Vector2(0, 0);
        public readonly static Vector2 LeftTopBlockDebrisVelocity = new Vector2(-60, 60);
        public readonly static Vector2 LeftBottomBlockDebrisVelocity = new Vector2(-60, 60);
        public readonly static Vector2 RightTopBlockDebrisVelocity = new Vector2(60, 60);
        public readonly static Vector2 RightBottomBlockDebrisVelocity = new Vector2(60, 60);
        public readonly static Vector2 CoinInitialVelocity = new Vector2(0, -100);
        public readonly static Vector2 LeftFireBallVelocity = new Vector2(-400, 50);
        public readonly static Vector2 RightFireBallVelocity = new Vector2(400, 50);
        public readonly static Vector2 FlagVelocity = new Vector2(0, 150);
        public readonly static Vector2 GreenMushrromCollidableVelicity = new Vector2(80, 0);
        public readonly static Vector2 ScoreTextVelocity = new Vector2(0, -100);
        public readonly static Vector2 StarInitialVelocity = new Vector2(40, -140);
        public readonly static Vector2 WinFlagVelocity = new Vector2(0, -14);
        public readonly static Vector2 SlidingMarioVelocity = new Vector2(0, 150);
        public readonly static Vector2 DeadMarioVelocity = new Vector2(0, -150);
        public readonly static Vector2 MarioTeleportTopVelocity = new Vector2(0, -32);
        public readonly static Vector2 MarioTeleportBottomVelocity = new Vector2(0, 35);
        public readonly static Vector2 MarioTeleportleftVelocity = new Vector2(-35, 0);
        public readonly static Vector2 MarioTeleportRightVelocity = new Vector2(35, 0);
        public readonly static Vector2 MarioJumpOffFlagVelocity = new Vector2(100, -180);
    }
}
