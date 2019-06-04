using System;
using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Classes.Objects.KoopaObject.KoopaState
{
    public class LeftMovingKoopaState : IGoombaState
    {
        private readonly KoopaObject koopa;
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
            //koopa.Move(new Vector2(-5, 0));
            //ChangeDirection();
        }
    }
}
