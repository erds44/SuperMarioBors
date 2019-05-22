using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    interface IReceiver
    {
        void Quit();
        void MoveLeft();
        void MoveRight();
        void FaceLeftOrRight();
    }
}
