using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.Objects.Mario.TransitionState
{
    public interface IMarioTransitionState 
    {
        void TakeDamage();
        void TakeRedMushroom();
        void TakeStar();
        void OnFireFlower();
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
