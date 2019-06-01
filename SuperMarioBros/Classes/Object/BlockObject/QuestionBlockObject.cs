using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Objects.BlockObjects.BlockStates;

namespace SuperMarioBros.Classes.Objects.BlockObjects
{
    public class QuestionBlockObject : BlockObject
    {
        public QuestionBlockObject( Vector2 location)
        {
            this.location = location;
            this.state = new QuestionBlockState(this);
        }
    }
}
