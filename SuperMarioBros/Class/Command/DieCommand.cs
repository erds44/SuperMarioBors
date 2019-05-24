using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Command
{
    class DieCommand : ICommand
    {
        private IReceiver action;
        public DieCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public  void Execute()
        {
            action.DeadMario();
        }
    }
}
