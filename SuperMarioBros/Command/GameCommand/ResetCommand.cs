﻿namespace SuperMarioBros.Commands
{
    class ResetCommand : ICommand
    {
        public void Execute()
        {
            MarioGame.Instance.InitializeGame();
        }
    }
}
