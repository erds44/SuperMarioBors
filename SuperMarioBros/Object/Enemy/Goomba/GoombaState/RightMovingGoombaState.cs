using System;
using SuperMarioBros.GoombaStates;

namespace SuperMarioBros.Goombas.GoombaStates
{
    public class RightMovingGoombaState : IGoombaState
    {
        private readonly Goomba goomba;
        public RightMovingGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
            //Goomba moves left and right using the same sprite
        }
        public void BeFlipped()
        {
            throw new NotImplementedException();
        }

        public void BeStomped()
        {
            throw new NotImplementedException();
        }

        public void ChangeDirection()
        {
            goomba.ChangeState(new LeftMovingGoombaState(goomba));
            // More to do
        }
    }
}
