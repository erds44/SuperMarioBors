using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Interface
{
    public interface IReceiver
    {
        void Quit();
        void Left();
        void Right();
        void Up();
        void Down();
        // More Actions to add
    }
}
