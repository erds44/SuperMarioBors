using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Loading
{
    public class ObjectLoader
    {
        public MarioGame Game { get; }
        public List<IStatic> Statics { get; private set; }
        public List<IDynamic> Dynamics { get; private set; }
        public List<IObject> NonCollidables { get; private set; }
        public IMario Mario { get; private set; }

        private List<ObjectsNode> staticList;
        private List<ObjectsNode> dynamicList;
        private List<ObjectsNode> nonCollidableList;

        public ObjectLoader()
        {
            Statics = new List<IStatic>();
            Dynamics = new List<IDynamic>();
            NonCollidables = new List<IObject>();
            Mario = new Mario(Locations.MarioInitialLocation);
            LoadDynamics();
            LoadStatics();
            LoadNonCollidables();
        }

        private void LoadNonCollidables()
        {
            nonCollidableList = XMLUtility.XMLReader<ObjectsNode>(Strings.NoncollidablesFile);
            foreach (ObjectsNode node in nonCollidableList)
            {
                Type t = Type.GetType(node.ObjectType);
                Vector2 position;
                position.X = node.Position.X;
                position.Y = node.Position.Y;
                var obj = Activator.CreateInstance(t, position);
                NonCollidables.Add((IObject)obj);
            }
        }



        private void LoadStatics()
        {
            staticList = XMLUtility.XMLReader<ObjectsNode>(Strings.StaticsFile);
            foreach (ObjectsNode node in staticList)
            {
                switch (node.Shape)
                {
                    case Utilities.HorizontalLine:
                        HorizontalLine(node);
                        break;
                    case Utilities.RightTriangle:
                        RightTriangle(node);
                        break;
                    case Utilities.LeftTriangle:
                        LeftTriangle(node);
                        break;
                    case Utilities.VerticalLine:
                        VerticalLine(node);
                        break;

                }
            }
  

        }

        private void HorizontalLine(ObjectsNode node)
        {
            Type t = Type.GetType(node.ObjectType);
            Vector2 position;
            position.X = node.Position.X;
            position.Y = node.Position.Y;
            for (int i = 0; i < node.Size; i++)
            {
                Statics.Add(CreateInstance(t, position, node));
                position.X += node.Width;
            }

        }

        private void VerticalLine(ObjectsNode node)
        {
            Type t = Type.GetType(node.ObjectType);
            Vector2 position;
            position.X = node.Position.X;
            position.Y = node.Position.Y;
            for (int i = 0; i < node.Size; i++)
            {
                Statics.Add(CreateInstance(t, position, node));
                position.Y -= node.Width;
            }
        }

        private void RightTriangle(ObjectsNode node)
        {
            Type t = Type.GetType(node.ObjectType);
            Vector2 position;
            position.X = node.Position.X;
            position.Y = node.Position.Y;
            for (int i = 0; i < node.Size; i++)
            {
                for (int j = 0; j < node.Size - i; j++)
                {
                    position.X = node.Position.X + i * node.Width;
                    position.Y = node.Position.Y - j * node.Width;
                    Statics.Add(CreateInstance(t, position, node));
                    position.Y -= node.Width;
                }
            }
        }

        private void LeftTriangle(ObjectsNode node)
        {
            Type t = Type.GetType(node.ObjectType);
            Vector2 position;
            position.X = node.Position.X;
            position.Y = node.Position.Y;
            for (int i = 0; i < node.Size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    position.X = node.Position.X + i * node.Width;
                    position.Y = node.Position.Y - j * node.Width;
                    Statics.Add(CreateInstance(t, position, node));
                    position.Y -= node.Width;
                }
            }
        }

        private static IStatic CreateInstance(Type t, Vector2 position, ObjectsNode node)
        {
            if(node.Direction != Direction.none)
            {
               if(node.Direction == Direction.bottom)
                    return (IStatic)(Activator.CreateInstance(t, position,node.PipeType));
               else
                    return (IStatic)(Activator.CreateInstance(t, position,node.TransferedLocation,node.PipeType,node.Direction));
            }
            if (node.ItemCount == Utilities.DefaultItemContained)
            {
                if (node.ItemType.Equals(Strings.NoItemContained))
                {
                    return (IStatic)(Activator.CreateInstance(t, position));
                }
                else
                {
                    return (IStatic)(Activator.CreateInstance(t, position, Type.GetType(node.ItemType)));
                }

            }
            else if (node.ItemType.Equals(Strings.NoItemContained))
            {
                return (IStatic)(Activator.CreateInstance(t, position, node.ItemCount));
            }
            else
            {

                return (IStatic)(Activator.CreateInstance(t, position, Type.GetType(node.ItemType), node.ItemCount));
            }

        }

        private void LoadDynamics()
        {
            dynamicList = XMLUtility.XMLReader<ObjectsNode>(Strings.DynamicsFile);
            foreach (ObjectsNode node in dynamicList)
            {
                Type t = Type.GetType(node.ObjectType);
                Vector2 position;
                position.X = node.Position.X;
                position.Y = node.Position.Y;
                var obj = Activator.CreateInstance(t, position);
                Dynamics.Add((IDynamic)obj);
            }
        }
    }
}
