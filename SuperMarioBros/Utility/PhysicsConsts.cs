using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Utility
{
    internal static class PhysicsConsts
    {
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

        public static Vector2 IdleVelocity = new Vector2(0, 0);
        public static Vector2 BumpedBlockInitialVelocity = new Vector2(0, -150);
        public static Vector2 LeftMovingGoombaVelocity = new Vector2(-60, 0);
        public static Vector2 RightMovingGoombaVelocity = new Vector2(60, 0);
        public static Vector2 LeftMovingNormalKoopaVelocity = new Vector2(-80, 0);
        public static Vector2 LeftMovingShelledKoopaVelocity = new Vector2(-160, 0);
        public static Vector2 RightMovingNormalKoopaVelocity = new Vector2(80, 0);
        public static Vector2 RightMovingShelledKoopaVelocity = new Vector2(160, 0);
        public static Vector2 EnemyInitialVelocity = new Vector2(-30, 0);
        public static Vector2 ItemInitialVelocity = new Vector2(0, -180);
        public static Vector2 ItemCollidableVelocity = new Vector2(40, 0);
        public static Vector2 BigCoinInitialVelocity = new Vector2(0, 0);
        public static Vector2 LeftTopBlockDebrisVelocity = new Vector2(-60, 60);
        public static Vector2 LeftBottomBlockDebrisVelocity = new Vector2(-60, 60);
        public static Vector2 RightTopBlockDebrisVelocity = new Vector2(60, 60);
        public static Vector2 RightBottomBlockDebrisVelocity = new Vector2(60, 60);
        public static Vector2 CoinInitialVelocity = new Vector2(0, -100);
        public static Vector2 LeftFireBallVelocity = new Vector2(-400, 50);
        public static Vector2 RightFireBallVelocity = new Vector2(400, 50);
        public static Vector2 FlagVelocity = new Vector2(0, 150);
        public static Vector2 GreenMushrromCollidableVelicity = new Vector2(80, 0);
        public static Vector2 ScoreTextVelocity = new Vector2(0, -100);
        public static Vector2 StarInitialVelocity = new Vector2(40, -140);
        public static Vector2 WinFlagVelocity = new Vector2(0, -14);
        public static Vector2 SlidingMarioVelocity = new Vector2(0, 150);
        public static Vector2 DeadMarioVelocity = new Vector2(0, -150);
        public static Vector2 MarioTeleportTopVelocity = new Vector2(0, -32);
        public static Vector2 MarioTeleportBottomVelocity = new Vector2(0, 35);
        public static Vector2 MarioTeleportleftVelocity = new Vector2(-35, 0);
        public static Vector2 MarioTeleportRightVelocity = new Vector2(35, 0);
        public static Vector2 MarioJumpOffFlagVelocity = new Vector2(100, -180);


    }
}

