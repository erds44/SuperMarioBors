using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBros.Utility
{
    public class VectorEventArgs : EventArgs
    {
        public Vector2 Vector { get; }
        public VectorEventArgs(Vector2 eventVector)
        {
            Vector = eventVector;
        }
    }
}
