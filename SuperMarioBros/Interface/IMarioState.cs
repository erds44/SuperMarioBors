using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    public interface IMarioState
    {
        void Left();
        void Down();
        void Up();
        void Right();
        void Update();
    }
}
