using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuperMarioBros
{
    public class BigMario : IMarioObject
    {
        public IMarioState state { get; set; }
        public ISprite sprite { get; set; }
        public BigMario(MarioGame game)
        {
            // Assume it is facing right, change later
            // Actually, it depends on small mario
            state = new RightIdleMarioState(this, game,"bigMario");
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
