using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
namespace SuperMarioBros.Interface.State
{
    interface IGoombaState : IState
    {
        void ChangeDirection();
        void BeStomped();
        void BeFlipped();
        void Update();
    }
}
