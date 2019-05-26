using SuperMarioBros.Interface.Object;
using SuperMarioBros.Interface.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object.MushroomObject
{
    public class LeftMovingMushroomState : IMushroomState
    {
        private MushroomObject mushroomObject;
        public LeftMovingMushroomState(MushroomObject mushroomObject)
        {
            this.mushroomObject = mushroomObject;
        }
        
        public void BeKicked()
        {

        }
    }
}
