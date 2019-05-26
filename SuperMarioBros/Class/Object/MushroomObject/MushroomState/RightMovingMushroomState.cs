using SuperMarioBros.Interface.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object.MushroomObject.MushroomState
{
    class RightMovingMushroomState : IMushroomState
    {
        private MushroomObject mushroomObject;
        public RightMovingMushroomState(MushroomObject mushroomObject)
        {
            this.mushroomObject = mushroomObject;
        }

        public void BeKicked()
        {

        }
    }
}
