using System;
using System.Reflection;
[assembly: AssemblyVersionAttribute("4.3.2.1")]
[assembly: CLSCompliant(true)]
[assembly: System.Runtime.InteropServices.ComVisible(false)]
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
