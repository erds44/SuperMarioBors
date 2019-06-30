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

        public event Action Click;
        public bool Clicked { get; private set; }
        public Color PenColor;
        private Vector2 position;
        private Rectangle rectangle;

        private string text;
        public Buttons(SpriteFont spriteFont, string text, Vector2 position)
        {
            this.spriteFont = spriteFont;
            PenColor = Color.Black;
            this.text = text;
            this.position = position;
            rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, (int)spriteFont.MeasureString(text).X, (int)spriteFont.MeasureString(text).Y);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (isHovering)
                color = Color.Gray;

            if (!string.IsNullOrEmpty(text))
            {
                spriteBatch.DrawString(spriteFont, text, position, color);
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
