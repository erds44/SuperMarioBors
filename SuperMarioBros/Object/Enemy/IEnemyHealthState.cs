using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.Objects.Enemy
{
    public interface IEnemyHealthState
    {
        void Update(GameTime gameTime);
        void Stomped();
    }
}
