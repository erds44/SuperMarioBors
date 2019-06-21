using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioBros.Koopas;
using SuperMarioBros.Objects;
using SuperMarioBros.Managers;

namespace SuperMarioBros.LoadingTest
{
    public class XMLProcessor
    {
        
            
        public static void LoadObjects()
        {

            List<ObjectNode> list = new List<ObjectNode>
            { 
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(100,200),1,100,39)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(0,300),2,3,39)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(100,400),3,3,39)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(500,500),4,6,39)),
            };

            XMLWriter(@"level.xml", list);
            XMLReader(@"level.xml", list);
            ListProcessor(list);
        }

        public static void ListProcessor(List<ObjectNode> list)
        {
            foreach(ObjectNode node in list)
            {
                switch(node.shape)
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

        public static void HorizontalLine(ObjectNode node)
        {
            Type t = Type.GetType(node.objectType);

            Vector2 position;
            position.X = node.position.X;
            position.Y = node.position.Y;
            for(int i = 0; i < node.size; i++)
            {
                var obj = Activator.CreateInstance(t, position);
                ObjectsManager.Instance.staticObjects.Add((IStatic)obj);
                position.X += node.width;
            }

        }

        public static void VerticalLine(ObjectNode node)
        {
            Type t = Type.GetType(node.objectType);
            Vector2 position;
            position.X = node.position.X;
            position.Y = node.position.Y;
            for (int i = 0; i < node.size; i++)
            {
                var obj = Activator.CreateInstance(t, position);
                ObjectsManager.Instance.staticObjects.Add((IStatic)obj);
                position.Y -= node.width;
            }
        }

        public static void RightTriangle(ObjectNode node)
        {
            Type t = Type.GetType(node.objectType);
            Vector2 position;
            position.X = node.position.X;
            position.Y = node.position.Y;
            for (int i = 0; i < node.size; i++)
            {
                for (int j = 0; j < node.size - i; j++)
                {
                    position.X = node.position.X+i*node.width;
                    position.Y = node.position.Y-j*node.width;
                    var obj = Activator.CreateInstance(t, position);
                    ObjectsManager.Instance.staticObjects.Add((IStatic)obj);
                    position.Y -= node.width;
                }
            }
        }

       public static void LeftTriangle(ObjectNode node)
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
                    ObjectsManager.Instance.staticObjects.Add((IStatic)obj);
                    position.Y -= node.width;
                }
            }
        }


        public static void XMLReader(String path, List<ObjectNode> list)
        {
            list = new List<ObjectNode>();
            using (var reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                var serializer = new XmlSerializer(typeof(List<ObjectNode>));
                list = (List<ObjectNode>)serializer.Deserialize(reader);
            }
        }

        public static void XMLWriter(String path, List<ObjectNode> list)
        {
            using (var writer = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ObjectNode>));
                serializer.Serialize(writer,list);
            }
        }

        
    }
}
