using System;
using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Classes.Objects.KoopaObject.KoopaState
{
    public class RightMovingGoombaState : IGoombaState
    {
        private readonly KoopaObject koopa;
        public RightMovingGoombaState(KoopaObject koopa)
        {
            this.koopa = koopa;
            koopa.ChangeSprite(SpriteFactory.CreateSprite("KoopaMovingRight"));
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
            if (koopa.CheckRightEdge())
            {
                koopa.ChangeState(new LeftMovingKoopaState(koopa));
            }
        }


        public void Update()
        {
            koopa.Move(new Vector2(5, 0));
            ChangeDirection();
        }
    }
}
