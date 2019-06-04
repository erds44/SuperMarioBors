using System;
using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces.States;


namespace SuperMarioBros.Classes.Objects.GoombaObject.GoombaState
{
    public class LeftMovingGoombaState : IGoombaState
    {
        private readonly GoombaObject goomba;
        public LeftMovingGoombaState(GoombaObject goomba)
        {
            this.goomba = goomba;
            goomba.ChangeSprite(SpriteFactory.CreateSprite("Goomba"));
        }
        public void BeFlipped()
        {
            throw new NotImplementedException();
        }

        public void BeStomped()
        {
            throw new NotImplementedException();
        }

        private void ChangeDirection()
        {
            if (goomba.CheckLeftEdge())
            {
                goomba.ChangeState(new RightMovingGoombaState(goomba));
            }
        }

        public void Update()
        {
           // goomba.Move(new Vector2(-5, 0));
           // ChangeDirection();
        }
    }
}
