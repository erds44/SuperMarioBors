﻿using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Items
{
    public interface IItem : IObject
    {
        void Collide(IMario mario);
    }
}
