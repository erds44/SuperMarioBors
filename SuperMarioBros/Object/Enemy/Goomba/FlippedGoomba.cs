using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas.GoombaStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Goombas
{
 
    public class FlippedGoomba 
    {
        public Vector2 Position { get; set; }
        public FlippedGoomba(Vector2 position)
        {
           
            Position = position;
        }

       
    }
  
}
