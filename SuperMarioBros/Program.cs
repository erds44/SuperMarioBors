using System.Reflection;
[assembly: AssemblyVersionAttribute("4.3.2.1")]
namespace SuperMarioBros
{
    static class Program
    {
        static void Main()
        {
            using (var game = new MarioGame())
                game.Run();

        }
    }
}
