using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros
{
    public interface IBlockObject
    {
        IBlockState state { get; set; }
        ISprite sprite { get; set; }
        void QuestionToUsed();
        void BrickToDisappear();
        void HiddenToUsed();
        void Update();
        void Draw();
    }
}
