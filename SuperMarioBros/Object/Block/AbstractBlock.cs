﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Blocks
{

    public abstract class AbstractBlock : IBlock
    {
        public bool IsInvalid { get; set; }

        public IBlockState State { get; protected set; }
        public Point Location { get; protected set; }
        public ISprite Sprite { get; protected set; }

        protected bool isBumping;
        protected int bumpingCount;
        protected Vector2 drawPosition;
        protected void Initialize()
        {
            drawPosition = Position;
            isBumping = false;
            bumpingCount = 0;
        }
        public void ChangeState(IBlockState state)
        {
            this.State = state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public void Move(Point motion)
        {
            this.Location += motion;
        }

        public void Update()
        {
            if (isBumping)
            {
                if(bumpingCount == 20) {
                    isBumping = false;
                    ((BumpBlockState)State).Restore();
                    drawPosition = Position;
                    bumpingCount = 0;
                }
                else
                {
                    bumpingCount++;
                    if(bumpingCount < 10)
                    {
                        drawPosition.Y -= 3;
                    }
                    else
                    {
                        drawPosition.Y += 3;
                    }
                }
            }
            this.Sprite.Update();
        }

        public void ChangeSprite(ISprite sprite)
        {
            this.Sprite = sprite;
        }
        public void Used()
        {
            this.State.ToUsed();
        }

        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.ObjectSize(GetType());
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }
    }
}
