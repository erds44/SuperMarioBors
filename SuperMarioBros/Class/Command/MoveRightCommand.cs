using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    class MoveRightCommand : ICommand
    {
        private IReceiver action;
        public MoveRightCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.MoveRight();
        }
    }
}
