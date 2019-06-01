﻿using System;
using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Classes.Objects.MarioObjects.MarioStates
{
    public class RightCrouchingMarioState : IMarioState
    {
        private readonly MarioObject mario;
        private readonly String type;
        public RightCrouchingMarioState(MarioObject mario, String type)
        {
            this.mario = mario;
            this.type = type;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "RightCrouching"));
        }

        public void Down()
        {
            // Do nothing
        }

        public void Right()
        {
            // Do nothing
        }

        public void Left()
        {
            // Do nothing
        }

        public void Up()
        {
            mario.ChangeState(new RightIdleMarioState(mario, type));
        }

        public void ToSmall()
        {
            // mario.ChangeState(new RightIdleMarioState(mario, "smallMario")); //smallMario cannot crouch.
        }

        public void ToBig()
        {
            mario.ChangeState(new RightCrouchingMarioState(mario, "BigMario"));
        }

        public void ToFire()
        {
            mario.ChangeState(new RightCrouchingMarioState(mario, "FireMario"));
        }

        public void Die()
        {
            mario.ChangeState(new DeadMarioState(mario, "SmallMario"));
        }

        public void Update()
        {
            // Do nothing.
        }

        public void Fire()
        {
            // Do nothing yet.
        }
    }
}