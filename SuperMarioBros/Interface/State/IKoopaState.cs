using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Interface.State
{
    interface IKoopaState : IState
    {
        // void ChangeDirection(); Not used in current Senario
        void BeStomped();
        void BeFlipped();
    }
}
