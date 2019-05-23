using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    public interface IMarioObject
    {
        IMarioState state { get; set; }
        void Left();
        void Down();
        void Up();
        void Right();
    }
}
