using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Managers;

namespace SuperMarioBros.GameCoreComponents
{
    public class ComponentTable
    { //Just a list of components. Don't want to put many fields in MarioGame class.
      //Use this class to eliminate all static classes and singletons.
        public MarioGame Game { get; private set; }
        public ObjectsManager Objects { get; private set; }
        public Camera Camera { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }
        public CollisionManager CollisionManager {get; private set;}

        public void Update(GameTime gameTime)
        {

        }
    }
}
