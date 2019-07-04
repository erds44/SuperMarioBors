using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{ 
    public class TeleportHugePipeH: AbstractBlock
    {
        public Vector2 TransferedLocation { get; private set; }
        public Direction TeleportDirection { get; private set; }
        public bool Teleported { get; set; }
        public TeleportHugePipeH(Vector2 location, Vector2 transferedLocation, Direction direction)
        {
            Position = location;
            TransferedLocation = transferedLocation;
            TeleportDirection = direction;
            Teleported = false;
            base.Initialize();
            Sprite.SetLayer(1f);
        }
    }
}
