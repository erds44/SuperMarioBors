using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Loading
{
    public class ObjectLoader
    {
        public MarioGame Game { get; }
        public List<IStatic> Statics { get; private set; }
        public List<IDynamic> Dynamics { get; private set; }
        public List<IObject> NonCollidables { get; private set; }
        public IMario Mario { get; private set; }
        private readonly List<ObjectNode> staticList = new List<ObjectNode>
            { 

                //test
                (new ObjectNode("SuperMarioBros.Blocks.ItemBrickBlock",new Vector2(0,288),1,1,35,"SuperMarioBros.Items.Coin",4)),
                (new ObjectNode("SuperMarioBros.Blocks.ItemBrickBlock",new Vector2(100,288),1,1,35,"SuperMarioBros.Items.Star",1)),
                (new ObjectNode("SuperMarioBros.Blocks.HiddenBlock",new Vector2(50,119),1,1,35,"null")),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(200,288),1,1,35,"SuperMarioBros.Items.Coin")),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(235,288),1,1,35,"null")),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(270,288),1,2,35,"SuperMarioBros.Items.Coin")),
                (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(400,410),1,2,340)),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(545,248),1,1,35,"SuperMarioBros.Items.Coin")),
                (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(510,248),1,1,35,"null")),
                (new ObjectNode("SuperMarioBros.Blocks.HiddenBlock",new Vector2(580,248),1,1,35,"SuperMarioBros.Items.GreenMushroom")),
                (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(495,100),1,6,35)),
                (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(460,65),1,2,245)),

                //base1
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(0,445),1,84,35)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(0,480),1,84,35)),

              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(870,288),1,1,35,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(1035,288),1,1,35,"null")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(1000,288),1,1,35)),

              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(1070,288),1,1,35)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(1105,288),1,1,35,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(1140,288),1,1,35)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(1070,119),1,1,35,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Backgrounds.BigCloud",new Vector2(100,170),1,12,700)),
              (new ObjectNode("SuperMarioBros.Backgrounds.SmallCloud",new Vector2(300,70),1,12,700)),
              (new ObjectNode("SuperMarioBros.Backgrounds.MiddleCloud",new Vector2(400,120),1,12,700)),


              (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(1290,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Items.MiddlePipe",new Vector2(1629,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Items.HighPipe",new Vector2(1961,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Items.HighPipe",new Vector2(2429,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Blocks.HiddenBlock",new Vector2(2640,288),1,1,35,"SuperMarioBros.Items.GreenMushroom")),
              //base2
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3029,445),1,18,35)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3029,480),1,18,35)),

              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3405,119),1,8,35)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3370,288),1,1,35)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(3335,288),1,1,35,"null")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3300,288),1,1,35)),

             
              //base3
               (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3795,445),1,77,35)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(3795,480),1,77,35)),


              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(4263,288),1,1,35)),
              (new ObjectNode("SuperMarioBros.Blocks.ItemBrickBlock",new Vector2(4298,288),1,1,35,"SuperMarioBros.Items.Star",1)),
              (new ObjectNode("SuperMarioBros.Blocks.ItemBrickBlock",new Vector2(3989,288),1,1,35,"null",5)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(3884,119),1,3,35)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(3989,119),1,1,35,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4775,288),1,1,35,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4649,119),1,1,35,"null")),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4649,288),1,1,35,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(4522,288),1,1,35,"SuperMarioBros.Items.Coin")),

              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5032,288),1,1,35)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5161,119),1,3,35)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(5501,119),1,1,35,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5466,119),1,1,35)),
             (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(5536,119),1,1,35,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5571,119),1,1,35)),



              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(5504,288),1,2,35)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(5710,410),3,4,35)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(5967,410),2,4,35)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(6315,410),3,4,35)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(6455,410),4,4,35)),
               //base4
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(6607,445),1,85,35)),
              (new ObjectNode("SuperMarioBros.Blocks.RockBlock",new Vector2(6607,480),1,85,35)),

              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(6607,410),2,4,35)),
              (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(6958,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(7164,288),1,2,35)),
              (new ObjectNode("SuperMarioBros.Blocks.QuestionBlock",new Vector2(7229,288),1,1,35,"SuperMarioBros.Items.Coin")),
              (new ObjectNode("SuperMarioBros.Blocks.BrickBlock",new Vector2(7264,288),1,1,35)),
              (new ObjectNode("SuperMarioBros.Items.Pipe",new Vector2(7647,410),1,1,72)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(7719,410),3,8,35)),
              (new ObjectNode("SuperMarioBros.Blocks.ConcreteBlock",new Vector2(7999,410),4,8,35)),


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


        public ObjectLoader(MarioGame game)
        {
            this.Game = game;
            this.Statics = new List<IStatic>();
            this.Dynamics = new List<IDynamic>();
            this.NonCollidables = new List<IObject>();
        }

        public void LevelLoading()
        {
            Mario = new Mario(new Vector2(0, 410));
            LoadDynamics();
            LoadStatics();
            LoadNonCollidables();
        }

        private void LoadNonCollidables()
        {
            foreach (ObjectNode node in nonCollidableList)
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
            foreach (ObjectNode node in staticList)
            {
                switch (node.Shape)
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
            Type t = Type.GetType(node.ObjectType);
            Vector2 position;
            position.X = node.Position.X;
            position.Y = node.Position.Y;
            for (int i = 0; i < node.Size; i++)
            {
                Statics.Add(CreateInstance(t, position, node.ItemType, node.ItemCount));
                position.X += node.Width;
            }

        }

        private void VerticalLine(ObjectNode node)
        {
            Type t = Type.GetType(node.ObjectType);
            Vector2 position;
            position.X = node.Position.X;
            position.Y = node.Position.Y;
            for (int i = 0; i < node.Size; i++)
            {
                Statics.Add(CreateInstance(t, position, node.ItemType, node.ItemCount));
                position.Y -= node.Width;
            }
        }

        private void RightTriangle(ObjectNode node)
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
                    Statics.Add(CreateInstance(t, position, node.ItemType, node.ItemCount));
                    position.Y -= node.Width;
                }
            }
        }

        private void LeftTriangle(ObjectNode node)
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
                    Statics.Add(CreateInstance(t, position, node.ItemType, node.ItemCount));
                    position.Y -= node.Width;
                }
            }
        }

        private static IStatic CreateInstance(Type t, Vector2 position, string itemType, int itemCount)
        {
            if (itemCount == 0)
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
                return (IStatic)(Activator.CreateInstance(t, position, itemCount));
            }
            else
            {

                return (IStatic)(Activator.CreateInstance(t, position, Type.GetType(itemType), itemCount));
            }

        }

        private void LoadDynamics()
        {
            foreach (ObjectNode node in dynamicList)
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
