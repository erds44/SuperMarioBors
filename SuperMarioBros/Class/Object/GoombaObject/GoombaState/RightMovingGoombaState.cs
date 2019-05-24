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
    public class RightMovingGoombaState : IGoombaState
    {
        private GoombaObject goomba;
        public RightMovingGoombaState(GoombaObject goomba)
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

        private void ChangeDirection()
        {
            if (goomba.CheckRightEdge())
            {
                goomba.ChangeState(new LeftMovingGoombaState(goomba));
            }
        }


        public void Update()
        {
            goomba.Move(new Vector2(5, 0));
            ChangeDirection();
        }
    }
}
