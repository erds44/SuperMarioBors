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
        ISprite sprite { get; set; }
        void Left();
        void Down();
        void Up();
        void Right();
        void ToSmall();
        void ToBig();
        void ToFire();
        void Die();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
