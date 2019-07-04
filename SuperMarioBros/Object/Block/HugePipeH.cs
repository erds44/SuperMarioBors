using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{ 
    public class HugePipeH: AbstractBlock
    {
        public HugePipeH(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
