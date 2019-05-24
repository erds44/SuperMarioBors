﻿using SuperMarioBros.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    class SmallMarioCommand : ICommand
    {
        private IReceiver action;
        public SmallMarioCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.SmallMario();
        }
    }
}
