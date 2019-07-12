using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;
using SuperMarioBros.Utility;
using System;

namespace SuperMarioBros.Loading
{
    public class ObjectsNode
    {
        public string ObjectType { get; set; }
        public Vector2 Position { get; set; }
        public int Shape { get; set; }
        public int Size { get; set; }
        public int Width { get; set; }
        public string ItemType { get; set; }
        public int ItemCount { get; set; }
        public Vector2 TransferedLocation { get; set; }
        public string PipeType { get; set; }
        public Direction Direction { get; set; }


        public ObjectsNode(string objectType, Vector2 position, int shape, int size, int width, string itemType= Strings.NoItemContained, int itemCount=GeneralConstants.DefaultItemContained)
        {
            this.ObjectType = objectType;
            this.Position = position;
            this.Shape = shape;
            this.Size = size;
            this.Width = width;
            this.ItemType = itemType;
            this.ItemCount = itemCount;
            this.Direction = Direction.none;
        }
        
        public ObjectsNode(string objectType, Vector2 position, int shape, int size, int width, Direction direction,string pipeType, Vector2 transferedLocation)
        {
            this.ObjectType = objectType;
            this.Position = position;
            this.Shape = shape;
            this.Size = size;
            this.Width = width;
            this.Direction = direction;
            this.PipeType = pipeType;
            this.TransferedLocation = transferedLocation;
        }

        //This constructor is required by the serialization
        public ObjectsNode()
        {

        }
    }
}
