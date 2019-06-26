using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects
{
    public interface IDynamic : IObject
    {
        void Update(GameTime gameTime);
    }
}
