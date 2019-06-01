﻿using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Command
{
    class ResetCommand : ICommand
    {
        private readonly IReceiver action;
        public ResetCommand(IReceiver receiver)
        {
            action = receiver;
        }
        public void Execute()
        {
            action.Reset();
        }
    }
}