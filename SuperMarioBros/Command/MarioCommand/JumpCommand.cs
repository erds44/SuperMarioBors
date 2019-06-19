using SuperMarioBros.Marios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Commands
{
    class JumpCommand : ICommand
    {
        private readonly IMario mario;
        public JumpCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            //mario.Jump();
        }
    }
}
