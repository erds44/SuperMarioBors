using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class StarMarioCommand : ICommand
    {
        private readonly IMario mario;
        private readonly ObjectsManager objectsManager;
        public StarMarioCommand(ObjectsManager objectsManager, IMario mario)
        {
            this.objectsManager = objectsManager;
            this.mario = mario;
        }
        public void Execute()
        {
            objectsManager.DecorateMario(new StarMario(mario, objectsManager));
        }
    }
}
