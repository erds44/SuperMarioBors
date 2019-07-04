using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{ 
    public class HugePipe: AbstractBlock
    {
        public HugePipe(Vector2 location)
        {
            Position = location;
            base.Initialize();
        }
    }
}
