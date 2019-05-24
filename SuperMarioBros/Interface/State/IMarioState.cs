using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Interface.State
{
    public interface IMarioState : IState
    {
        void Left();
        void Down();
        void Up();
        void Right();
        void ToSmall();
        void ToBig();
        void ToFire();
        void Fire();
        void Die();
    }
}
