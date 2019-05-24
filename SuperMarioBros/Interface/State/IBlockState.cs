using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Interface.State
{
    public interface IBlockState : IState
    {
        void ToUsed();
        void ToBrick();
        void ToDisappear();
        void ToQuestion();
        void ToHidden();
    }
}
