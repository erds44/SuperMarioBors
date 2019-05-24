using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioBros.Interface.State;
using SuperMarioBros.Class.Object.GoombaObject;


namespace SuperMarioBros.Class.Object.GoombaObject.GoombaState
{
    public class LeftMovingGoombaState : IGoombaState
    {
        private GoombaObject goomba;
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
            goomba.Move(new Vector2(-5, 0));
            ChangeDirection();
        }
    }
}
