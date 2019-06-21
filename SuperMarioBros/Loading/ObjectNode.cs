using Microsoft.Xna.Framework;
using SuperMarioBros.Koopas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.LoadingTest
{
    public class ObjectNode
    {
        public string objectType;
        public Vector2 position;
        public int shape;
        public int size;
        public int width;
        public ObjectNode(String name, Vector2 vector,int shape, int size, int width)
        {
            objectType = name;
            position = vector;
            this.shape = shape;
            this.size = size;
            this.width = width;
        }

        public ObjectNode()
        {

        }
    }
}
