using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Sprites
{
    public interface ISprite : IUpdate
    {
        void Draw(SpriteBatch spriteBatch, Point location);
        void SetColor(Collection<Color> colors);
    }
}
