using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SuperMarioBros.GameStates
{
    public class Buttons
    {
        private MouseState currentMouse;
        private MouseState previousMouse;
        private SpriteFont spriteFont;
        private bool isHovering;
        private Texture2D texture;

        public event Action Click;
        public bool Clicked { get; private set; }
        public Color PenColor;
        public Vector2 Position { get; set; }
        public Rectangle rectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height); }
        }

        public string Text { get; set; }
        public Buttons(Texture2D texture, SpriteFont spriteFont)
        {
            this.texture = texture;
            this.spriteFont = spriteFont;
            PenColor = Color.Black;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (isHovering)
                color = Color.Gray;
            spriteBatch.Draw(texture, rectangle, color);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (rectangle.X + (rectangle.Width / 2)) - (spriteFont.MeasureString(Text).X / 2);
                var y = (rectangle.Y + (rectangle.Height / 2)) - (spriteFont.MeasureString(Text).Y / 2);
                spriteBatch.DrawString(spriteFont, Text, new Vector2(x, y), PenColor);
            }
        }

        public void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);
            isHovering = false;
            if (mouseRectangle.Intersects(rectangle))
            {
                isHovering = true;
                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke();
                }
            }
        }
    }
}
