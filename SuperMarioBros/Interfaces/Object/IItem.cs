namespace SuperMarioBros.Interfaces.Object
{
    public interface IItem : IObject
    {
        void Collide(IMario mario);
    }
}
