using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    class FaceLeftOrRightCommand: ICommand
    {
        private IReceiver action;
        public FaceLeftOrRightCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.FaceLeftOrRight();
        }
    }
}
