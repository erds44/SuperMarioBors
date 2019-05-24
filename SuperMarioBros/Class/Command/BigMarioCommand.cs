using SuperMarioBros.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    class BigMarioCommand : ICommand
    {
        private IReceiver action;
        public BigMarioCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.BigMario();
        }
    }
}
