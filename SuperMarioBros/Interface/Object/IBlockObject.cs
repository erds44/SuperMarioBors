using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;
using SuperMarioBros.Interface.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Interface.Object.BlockObject
{
    public interface IBlockObject : IObject
    {
        void ChangeState(IBlockState state);
        void Used();
        void Disappear();
    }
}
