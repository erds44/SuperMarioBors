using SuperMarioBros.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Command
{
    class LeftCommand : ICommand
    {
        private IReceiver action;
        public LeftCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.Left();
        }
    }
}
