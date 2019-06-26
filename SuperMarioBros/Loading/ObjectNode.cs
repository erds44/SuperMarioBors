using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBros.LoadingTest
{
    public class ObjectNode
    {
        public string objectType;
        public Vector2 position;
        public int shape;
        public int size;
        public int width;
        public string itemType;
        public int itemCount;


        public ObjectNode(string objectType, Vector2 position, int shape, int size, int width, string itemType= "noType", int itemCount=0)
        {
            this.objectType = objectType;
            this.position = position;
            this.shape = shape;
            this.size = size;
            this.width = width;
            this.itemType = itemType;
            this.itemCount = itemCount;
        }

        //This constructor is required by the serialization
        public ObjectNode()
        {

        }
    }
}
