using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    class Invoker
    {
        private ICommand command;
        public Invoker(ICommand commandInput)
        {
            command = commandInput;
        }
        public void press()
        {
            command.Execute();
        }
    }
}
