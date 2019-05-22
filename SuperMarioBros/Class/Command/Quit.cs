using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    class Quit : ICommand
    {
        private IReceiver action;
        public Quit(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.Quit();
        }
    }
}
