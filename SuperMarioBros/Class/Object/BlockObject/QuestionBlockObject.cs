using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Class.Object.BlockObject.BlockState;
using SuperMarioBros.Interface;
using SuperMarioBros.Interface.Object.BlockObject;
using SuperMarioBros.Interface.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object.BlockObject
{
    public class QuestionBlockObject : BlockObject
    {
        public QuestionBlockObject(MarioGame game, Vector2 location)
        {
            this.game = game;
            this.location = location;
            this.state = new QuestionBlockState(this);
        }
    }
}
