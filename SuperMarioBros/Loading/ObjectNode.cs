using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBros.LoadingTest
{
    public class ObjectNode
    {
        public string ObjectType { get; set; }
        public Vector2 Position { get; set; }
        public int Shape { get; set; }
        public int Size { get; set; }
        public int Width { get; set; }
        public string ItemType { get; set; }
        public int ItemCount { get; set; }


        public ObjectNode(string objectType, Vector2 position, int shape, int size, int width, string itemType= "noType", int itemCount=0)
        {
            this.ObjectType = objectType;
            this.Position = position;
            this.Shape = shape;
            this.Size = size;
            this.Width = width;
            this.ItemType = itemType;
            this.ItemCount = itemCount;
        }

        //This constructor is required by the serialization
        public ObjectNode()
        {

        }
    }
}
