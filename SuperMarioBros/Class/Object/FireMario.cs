using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object
{
    class FireMario : IMarioObject
    {
        public IMarioState state { get; set; }
        public FireMario(MarioGame game)
        {
            // Assume it is facing right, change later
            state = new RightIdleMarioState(this, game, "FireMario");
        }

        public void Left()
        {
            state.Left();
        }

        public void Down()
        {
            state.Down();
        }

        public void Up()
        {
            state.Up();
        }

        public void Right()
        {
            state.Right();
        }
    }
}
