using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioBros.Interface.State;
using SuperMarioBros.Class.Object.KoopaObject;

namespace SuperMarioBros.Class.Object.KoopaObject.KoopaState
{
    public class LeftMovingKoopaState : IGoombaState
    {
        private KoopaObject koopa;
        public LeftMovingKoopaState(KoopaObject koopa)
        {
            this.koopa = koopa;
            koopa.ChangeSprite(SpriteFactory.CreateSprite("KoopaMovingLeft"));
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
            if (koopa.CheckLeftEdge())
            {
                koopa.ChangeState(new RightMovingGoombaState(koopa));
            }
        }

        public void Update()
        {
            koopa.Move(new Vector2(-5, 0));
            ChangeDirection();
        }
    }
}
