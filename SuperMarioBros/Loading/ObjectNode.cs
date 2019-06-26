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
        public string itemType = "noType";
        public int itemCount = 0;

        public ObjectNode(string name, Vector2 vector,int shape, int size, int width)
        {
            objectType = name;
            position = vector;
            this.shape = shape;
            this.size = size;
            this.width = width;

        }

        public ObjectNode(string objectType, Vector2 position, int shape, int size, int width, string itemType, int itemCount)
        {
            this.objectType = objectType;
            this.position = position;
            this.shape = shape;
            this.size = size;
            this.width = width;
            this.itemType = itemType;
            this.itemCount = itemCount;
        }

        public ObjectNode(string objectType, Vector2 position, int shape, int size, int width, int itemCount)
        {
            this.objectType = objectType;
            this.position = position;
            this.shape = shape;
            this.size = size;
            this.width = width;
            this.itemCount = itemCount;
        }

        public ObjectNode()
        {

        }
    }
}
