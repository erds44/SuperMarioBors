using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;

namespace SuperMarioBros.LoadingTest
{
    public class XMLProcessor
    {
        private List<ObjectNode> staticList = new List<ObjectNode>
            { 

                //test
                (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(100,288),1,1,39)),
                (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(180,288),1,1,40)),
                (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(260,288),1,1,40)),
                (new ObjectNode("SuperMarioBros.Blocks.HiddenBlock",new Vector2(300,288),1,1,40)),
                (new ObjectNode("SuperMarioBros.Blocks.ItemBrickBlock",new Vector2(380,288),1,1,40)),
                (new ObjectNode("SuperMarioBros.Blocks.PowerUpBlock",new Vector2(460,288),1,1,40)),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(500,288),1,1,40)),


                //base1
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(0,450),1,74,39)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(0,489),1,74,39)),

              (new ObjectNode("SuperMarioBros.Blocks.PowerUpBlock",new Vector2(678,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(848,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(888,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(928,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(968,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(1008,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(928,119),1,1,40)),

              (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(1190,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(1629,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(1961,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(2429,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Blocks.HiddenBlock",new Vector2(2800,288),1,1,40)),
              //base2
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3029,450),1,16,39)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3029,489),1,16,39)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3420,119),1,8,40)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3380,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.PowerUpBlock",new Vector2(3340,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3300,288),1,1,40)),
              //base3
               (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3795,450),1,69,39)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3795,489),1,69,39)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3884,119),1,3,40)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(4263,288),1,2,40)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(4004,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4004,119),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4775,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.PowerUpBlock",new Vector2(4649,119),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4649,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4522,288),1,1,40)),

              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5032,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5161,119),1,3,40)),
               (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(5504,119),1,1,40)),
                 (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5464,119),1,1,40)),
               (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(5544,119),1,1,40)),
                 (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5584,119),1,1,40)),

              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5504,288),1,2,40)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(5710,410),3,4,40)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(5967,410),2,4,40)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(6286,410),3,4,40)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(6446,410),4,4,40)),
               //base4
               (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(6607,450),1,74,39)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(6607,489),1,74,39)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(6607,410),2,4,40)),
              (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(6958,410),1,1,72)),
               (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(7164,288),1,2,40)),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(7244,288),1,1,40)),
                 (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(7284,288),1,1,40)),
                (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(7647,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(7719,410),3,8,40)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(8039,410),4,8,40)),


            };

        private List<ObjectNode> dynamicList = new List<ObjectNode>
        {

        };

        private List<ObjectNode> backgroundList = new List<ObjectNode>
        {

        };

        private List<IStatic> staticObjects;
        private List<IStatic> backgroundObjects;
        private List<IDynamic> dynamicObjects;


        public XMLProcessor()
        {
            staticObjects = new List<IStatic>();
            backgroundObjects = new List<IStatic>();
            dynamicObjects = new List<IDynamic>();
        }

        //return methods
        public List<IStatic> StaticList()
        {
            XMLWriter(@"StaticLevel.xml", staticList);
            XMLReader(@"StaticLevel.xml", staticList);
            StaticListProcessor(staticList);
            return staticObjects;
        }
        public List<IStatic> BackgroundObjects()
        {
            XMLWriter(@"BackgroundLevel.xml", staticList);
            XMLReader(@"BackgroundLevel.xml", staticList);
            BackgroundListProcessor(backgroundObjects);
            return backgroundObjects;
        }
        public List<IDynamic> DynamicList()
        {
            XMLWriter(@"DynamicLevel.xml", staticList);
            XMLReader(@"DynamicLevel.xml", staticList);
            DynamicListProcessor(dynamicObjects);
            return dynamicObjects;
        }

        private void BackgroundListProcessor(List<IStatic> list)
        {
            foreach (ObjectNode node in list)
            {
                Type t = Type.GetType(node.objectType);
                Vector2 position;
                position.X = node.position.X;
                position.Y = node.position.Y;
                var obj = Activator.CreateInstance(t, position);
                backgroundObjects.Add((IStatic)obj);
            }
        }

        private void DynamicListProcessor(List<IDynamic> list)
        {
            foreach (ObjectNode node in list)
            {
                Type t = Type.GetType(node.objectType);
                Vector2 position;
                position.X = node.position.X;
                position.Y = node.position.Y;
                var obj = Activator.CreateInstance(t, position);
                dynamicObjects.Add((IDynamic)obj);
            }
        }

        private void StaticListProcessor(List<ObjectNode> list)
        {
            foreach (ObjectNode node in list)
            {
                switch (node.shape)
                {
                    case 1:
                        HorizontalLine(node);
                        break;
                    case 2:
                        RightTriangle(node);
                        break;
                    case 3:
                        LeftTriangle(node);
                        break;
                    case 4:
                        VerticalLine(node);
                        break;

                }
            }
        }

        private void HorizontalLine(ObjectNode node)
        {
            Type t = Type.GetType(node.objectType);

            Vector2 position;
            position.X = node.position.X;
            position.Y = node.position.Y;
            for (int i = 0; i < node.size; i++)
            {
                var obj = Activator.CreateInstance(t, position);
                staticObjects.Add((IStatic)obj);
                position.X += node.width;
            }

        }

        private void VerticalLine(ObjectNode node)
        {
            Type t = Type.GetType(node.objectType);
            Vector2 position;
            position.X = node.position.X;
            position.Y = node.position.Y;
            for (int i = 0; i < node.size; i++)
            {
                var obj = Activator.CreateInstance(t, position);
                staticObjects.Add((IStatic)obj);
                position.Y -= node.width;
            }
        }

        private void RightTriangle(ObjectNode node)
        {
            Type t = Type.GetType(node.objectType);
            Vector2 position;
            position.X = node.position.X;
            position.Y = node.position.Y;
            for (int i = 0; i < node.size; i++)
            {
                for (int j = 0; j < node.size - i; j++)
                {
                    position.X = node.position.X + i * node.width;
                    position.Y = node.position.Y - j * node.width;
                    var obj = Activator.CreateInstance(t, position);
                    staticObjects.Add((IStatic)obj);
                    position.Y -= node.width;
                }
            }
        }

        private void LeftTriangle(ObjectNode node)
        {
            Type t = Type.GetType(node.objectType);
            Vector2 position;
            position.X = node.position.X;
            position.Y = node.position.Y;
            for (int i = 0; i < node.size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    position.X = node.position.X + i * node.width;
                    position.Y = node.position.Y - j * node.width;
                    var obj = Activator.CreateInstance(t, position);
                    staticObjects.Add((IStatic)obj);
                    position.Y -= node.width;
                }
            }
        }


        private static void XMLReader(String path, List<ObjectNode> list)
        {
            list = new List<ObjectNode>();
            using (var reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                var serializer = new XmlSerializer(typeof(List<ObjectNode>));
                list = (List<ObjectNode>)serializer.Deserialize(reader);
            }
        }

        private static void XMLWriter(String path, List<ObjectNode> list)
        {
            using (var writer = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ObjectNode>));
                serializer.Serialize(writer, list);
            }
        }


    }
}
