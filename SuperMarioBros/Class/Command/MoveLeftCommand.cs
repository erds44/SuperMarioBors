using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    class MoveLeftCommand : ICommand
    {
        private IReceiver action;
        public MoveLeftCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.MoveLeft();
        }
    }
}
