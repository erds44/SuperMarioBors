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
        private readonly List<ObjectNode> staticList = new List<ObjectNode> 
            { 

                //test
                (new ObjectNode("SuperMarioBros.Blocks.ItemBrickBlock",new Vector2(0,288),1,1,40,"SuperMarioBros.Items.Coin",4)),
                (new ObjectNode("SuperMarioBros.Blocks.ItemBrickBlock",new Vector2(100,288),1,1,40,"SuperMarioBros.Items.Star",1)),
                (new ObjectNode("SuperMarioBros.Blocks.HiddenBlock",new Vector2(50,119),1,1,40,"null")),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(200,288),1,1,40,"SuperMarioBros.Items.Coin")),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(240,288),1,1,40,"null")),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(280,288),1,2,40,"SuperMarioBros.Items.Coin")),
                (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(400,410),1,2,340)),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(550,248),1,1,40,"SuperMarioBros.Items.Coin")),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(510,248),1,1,40,"null")),
                (new ObjectNode("SuperMarioBros.Blocks.HiddenBlock",new Vector2(590,248),1,1,40,"SuperMarioBros.Items.GreenMushroom")),
                (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(500,100),1,6,40)),
                (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(460,60),1,2,280)),



                
                


                //base1
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(0,450),1,74,39)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(0,489),1,74,39)),

              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(1038,288),1,1,40,"null")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(998,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(870,288),1,1,40,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(1078,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(1118,288),1,1,40,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(1158,288),1,1,40)),
             (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(1078,119),1,1,40,"SuperMarioBros.Items.Coin")),
               (new ObjectNode("SuperMarioBros.Backgrounds.BigCloud",new Vector2(100,170),1,12,700)),
                (new ObjectNode("SuperMarioBros.Backgrounds.SmallCloud",new Vector2(300,70),1,12,700)),
                 (new ObjectNode("SuperMarioBros.Backgrounds.MiddleCloud",new Vector2(400,120),1,12,700)),


              (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(1290,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Items.MiddlePipe",new Vector2(1629,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Items.HighPipe",new Vector2(1961,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Items.HighPipe",new Vector2(2429,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Blocks.HiddenBlock",new Vector2(2600,288),1,1,40,"SuperMarioBros.Items.GreenMushroom")),
              //base2
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3029,450),1,16,39)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3029,489),1,16,39)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3420,119),1,8,40)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3380,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(3340,288),1,1,40,"null")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3300,288),1,1,40)),

             
              //base3
               (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3795,450),1,69,39)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3795,489),1,69,39)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3884,119),1,3,40)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(4263,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.ItemBrickBlock",new Vector2(4303,288),1,1,40,"SuperMarioBros.Items.Star",1)),
              (new ObjectNode("SuperMarioBros.Blocks.ItemBrickBlock",new Vector2(4004,288),1,1,40,"null",5)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4004,119),1,1,40,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4775,288),1,1,40,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4649,119),1,1,40,"null")),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4649,288),1,1,40,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4522,288),1,1,40,"SuperMarioBros.Items.Coin")),

              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5032,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5161,119),1,3,40)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(5504,119),1,1,40,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5464,119),1,1,40)),
             (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(5544,119),1,1,40,"SuperMarioBros.Items.Coin")),
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
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(7244,288),1,1,40,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(7284,288),1,1,40)),
              (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(7647,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(7719,410),3,8,40)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(8039,410),4,8,40)),

             
            };


        private readonly List<ObjectNode> dynamicList = new List<ObjectNode>
        {
            (new ObjectNode("SuperMarioBros.Items.RedMushroom",new Vector2(80,410),1,1,30)),
            //test
            (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(540,410),1,1,30)),
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Koopa",new Vector2(580,410),1,1,30)),
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(540,60),1,1,30)),
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Koopa",new Vector2(600,60),1,1,30)),

            //base1
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(928,410),1,1,30)),
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(1750,410),1,1,30)),
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(2200,410),1,1,30)),
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(2250,410),1,1,30)),

            //base2
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(3380,200),1,1,30)),
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(3420,200),1,1,30)),

              //base3
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(4004,410),1,1,30)),
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(4054,410),1,1,30)),
            (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(4328,410),1,1,30)),
            (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(4378,410),1,1,30)),
              (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(5174,410),1,1,30)),
              (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(4707,410),1,1,30)),
              (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(4757,410),1,1,30)),
              (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(5224,410),1,1,30)),
              (new ObjectNode("SuperMarioBros.Objects.Enemy.Koopa",new Vector2(4150,410),1,1,30)),
             
            //base4 
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(7200,410),1,1,30)),
             (new ObjectNode("SuperMarioBros.Objects.Enemy.Goomba",new Vector2(7250,410),1,1,30)),
        };

        private readonly List<ObjectNode> nonCollidableList = new List<ObjectNode>
        {
            (new ObjectNode("SuperMarioBros.Backgrounds.BigHill",new Vector2(0,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.BigBush",new Vector2(481,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.SmallHill",new Vector2(681,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.SmallBush",new Vector2(995,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.BigBush",new Vector2(1765,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.BigHill",new Vector2(2044,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.BigBush",new Vector2(2530,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.SmallHill",new Vector2(2720,410),1,1,0)),
             

            (new ObjectNode("SuperMarioBros.Backgrounds.SmallBush",new Vector2(3039,410),1,1,0)),

            (new ObjectNode("SuperMarioBros.Backgrounds.BigBush",new Vector2(3804,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.BigHill",new Vector2(4083,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.BigBush",new Vector2(4570,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.SmallHill",new Vector2(4762,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.SmallBush",new Vector2(5070,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.BigBush",new Vector2(5860,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.BigHill",new Vector2(6118,410),1,1,0)),

            (new ObjectNode("SuperMarioBros.Backgrounds.SmallBush",new Vector2(6722,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.SmallHill",new Vector2(6803,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.SmallBush",new Vector2(7122,410),1,1,0)),
            (new ObjectNode("SuperMarioBros.Backgrounds.BigHill",new Vector2(8150,410),1,1,0)),
        };


       
 

        private readonly List<IStatic> staticObjects;
        private readonly List<IDynamic> dynamicObjects; 
        private readonly List<IObject> nonCollidableObjects;


        public XMLProcessor()
        {
            staticObjects = new List<IStatic>();
            dynamicObjects = new List<IDynamic>();
            nonCollidableObjects = new List<IObject>();
        }

        //return methods
        public List<IStatic> StaticList()
        {
            XMLWriter(@"StaticLevel.xml", staticList);
            XMLReader(@"StaticLevel.xml", staticList);
            StaticListProcessor(staticList);
            return staticObjects;
        }
        
        public List<IDynamic> DynamicList()
        {
            XMLWriter(@"DynamicLevel.xml", dynamicList);
            XMLReader(@"DynamicLevel.xml", dynamicList);
            DynamicListProcessor(dynamicList);
            return dynamicObjects;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<IObject> NonCollidableList()
        {
            XMLWriter(@"NonCollidableLevel.xml", nonCollidableList);
            XMLReader(@"NonCollidableLevel.xml", nonCollidableList);
            NonCollidableListProcessor(nonCollidableList);
            return nonCollidableObjects;
        }

        private void NonCollidableListProcessor(List<ObjectNode> list)
        {
            foreach (ObjectNode node in list)
            {
                Type t = Type.GetType(node.ObjectType);
                Vector2 position;
                position.X = node.Position.X;
                position.Y = node.Position.Y;
                var obj = Activator.CreateInstance(t, position);
                nonCollidableObjects.Add((IObject)obj);
            }
        }
        private void DynamicListProcessor(List<ObjectNode> list)
        {
            foreach (ObjectNode node in list)
            {
                Type t = Type.GetType(node.ObjectType);
                Vector2 position;
                position.X = node.Position.X;
                position.Y = node.Position.Y;
                var obj = Activator.CreateInstance(t, position);
                dynamicObjects.Add((IDynamic)obj);
            }
        }

        private  void StaticListProcessor(List<ObjectNode> list)
        {
            foreach(ObjectNode node in list)
            {
                switch(node.Shape)
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

        private  void HorizontalLine(ObjectNode node)
        {
            Type t = Type.GetType(node.ObjectType);

            Vector2 position;
            position.X = node.Position.X;
            position.Y = node.Position.Y;
            for(int i = 0; i < node.Size; i++)
            {
                staticObjects.Add(CreateInstance(t, position, node.ItemType, node.ItemCount));
                position.X += node.Width;
            }

        }

        private  void VerticalLine(ObjectNode node)
        {
            Type t = Type.GetType(node.ObjectType);
            Vector2 position;
            position.X = node.Position.X;
            position.Y = node.Position.Y;
            for (int i = 0; i < node.Size; i++)
            {
                staticObjects.Add(CreateInstance(t, position, node.ItemType, node.ItemCount));
                position.Y -= node.Width;
            }
        }

        private  void RightTriangle(ObjectNode node)
        {
            Type t = Type.GetType(node.ObjectType);
            Vector2 position;
            position.X = node.Position.X;
            position.Y = node.Position.Y;
            for (int i = 0; i < node.Size; i++)
            {
                for (int j = 0; j < node.Size - i; j++)
                {
                    position.X = node.Position.X+i*node.Width;
                    position.Y = node.Position.Y-j*node.Width;
                    staticObjects.Add(CreateInstance(t, position, node.ItemType, node.ItemCount));
                    position.Y -= node.Width;
                }
            }
        }

       private  void LeftTriangle(ObjectNode node)
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
                     staticObjects.Add(CreateInstance(t, position,node.ItemType,node.ItemCount));
                    position.Y -= node.Width;
                }
            }
        }

        private static IStatic CreateInstance(Type t, Vector2 position, string itemType, int itemCount)
        {
            if(itemCount == 0)
            {
                if (itemType.Equals("noType"))
                {
                    return (IStatic)(Activator.CreateInstance(t, position));
                }
                else
                {
                    return (IStatic)(Activator.CreateInstance(t, position, Type.GetType(itemType)));
                }
               
            }
            else if (itemType.Equals("noType"))
            {
                return (IStatic)(Activator.CreateInstance(t, position,itemCount));
            }
            else {
                
                return (IStatic)(Activator.CreateInstance(t, position, Type.GetType(itemType),itemCount));
            }
            
        }


        private static void XMLReader(string path, List<ObjectNode> list)
        {
            list = new List<ObjectNode>();
            using (var reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                var serializer = new XmlSerializer(typeof(List<ObjectNode>));
                list = (List<ObjectNode>)serializer.Deserialize(reader);
            }
        }

        private static void XMLWriter(string path, List<ObjectNode> list)
        {
            using (var writer = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ObjectNode>));
                serializer.Serialize(writer,list);
            }
        }

       

    }
}
