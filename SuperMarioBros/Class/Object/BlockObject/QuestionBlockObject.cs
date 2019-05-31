using Microsoft.Xna.Framework;
using SuperMarioBros.Class.Object.BlockObject.BlockState;

namespace SuperMarioBros.Class.Object.BlockObject
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
