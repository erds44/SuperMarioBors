using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Interface
{
    public interface IBlockState
    {
        void QuestionToUsed();
        void BrickToDisappear();
        void HiddenToUsed();
        void Update();
    }
}
