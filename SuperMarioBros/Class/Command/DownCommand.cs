using SuperMarioBros.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Command
{
    class DownCommand : ICommand
    {
        private IReceiver action;
        public DownCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.Down();
        }
    }
}
