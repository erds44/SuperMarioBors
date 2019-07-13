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
        private Vector2 position;
        private Rectangle rectangle;

        private string text;
        public Buttons(SpriteFont spriteFont, string text, Vector2 position)
        {
            this.spriteFont = spriteFont;
            this.text = text;
            this.position = position;
            rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, (int)spriteFont.MeasureString(text).X, (int)spriteFont.MeasureString(text).Y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (isHovering) color = Color.Gray;

            if (!string.IsNullOrEmpty(text))
                spriteBatch.DrawString(spriteFont, text, position, color);
        }

        public void Update()
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mousePoint = new Point(currentMouse.X, currentMouse.Y);
            isHovering = false;
            if (rectangle.Contains(mousePoint))
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
