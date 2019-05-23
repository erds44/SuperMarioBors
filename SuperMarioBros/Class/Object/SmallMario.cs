﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object
{
    class SmallMario : IMarioObject
    {
        public IMarioState state { get; set; }
        public SmallMario(MarioGame game)
        {
            // Assume it is facing right, change later
            state = new RightIdleMarioState(this, game, "SmallMario");
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
