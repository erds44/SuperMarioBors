using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SuperMarioBros.Loading
{
    public class SpritesLoading
    {
        private List<SpritesNode> spritesCollection = new List<SpritesNode>
        {
             new SpritesNode("BigMarioLeftCrouching","BigMarioLeftCrouching",32,44),
             new SpritesNode("BigMarioLeftIdle","BigMarioLeftIdle",32,64),
             new SpritesNode("BigMarioLeftJumping","BigMarioLeftJumping",32,65),
             new SpritesNode("BigMarioLeftMoving","BigMarioLeftMoving",32,64,4),
             new SpritesNode("BigMarioRightCrouching","BigMarioRightCrouching",32,44),
             new SpritesNode("BigMarioRightIdle","BigMarioRightIdle",32,64),
             new SpritesNode("BigMarioRightJumping","BigMarioRightJumping",32,65),
             new SpritesNode("BigMarioRightMoving","BigMarioRightMoving",32,64,4),
             new SpritesNode("BrickBlock","BrickBlock",35,35),
             new SpritesNode("ItemBrickBlock","BrickBlock",35,35),
             //special item
             new SpritesNode("BrickDebris","BrickDebris"),
             new SpritesNode("Coin","Coin",14,26,5),
             new SpritesNode("ConcreteBlock","ConcreteBlock",35,35),
             new SpritesNode("UsedBlock","UsedBlock",35,35),
             new SpritesNode("FireMarioLeftCrouching","FireMarioLeftCrouching",32,44),
             new SpritesNode("FireMarioLeftIdle","FireMarioLeftIdle",32,64),
             new SpritesNode("FireMarioLeftJumping","FireMarioLeftJumping",32,65),
             new SpritesNode("FireMarioLeftMoving","FireMarioLeftMoving",32,64,5),
             new SpritesNode("FireMarioRightCrouching","FireMarioRightCrouching",32,44),
             new SpritesNode("FireMarioRightIdle","FireMarioRightIdle",32,64),
             new SpritesNode("FireMarioRightJumping","FireMarioRightJumping",32,65),
             new SpritesNode("FireMarioRightMoving","FireMarioRightMoving",32,64,5),
             new SpritesNode("Flower","Flower",32,32,5),
             new SpritesNode("GoombaLeftMovingState","Goomba",30,30,2),
             new SpritesNode("GoombaRightMovingState","Goomba",30,30,2),
             new SpritesNode("GoombaStompedState","StompedGoomba",32,16),
             new SpritesNode("FlippedGoombaIdleState","Goomba",30,30),
             new SpritesNode("StompedKoopaRightMoving","KoopaStomped",32,28),
             new SpritesNode("StompedKoopaLeftMoving","KoopaStomped",32,28),
             new SpritesNode("GreenMushroom","GreenMushroom",29,29),
             new SpritesNode("HiddenBlock","HiddenBlock",35,35),
             new SpritesNode("KoopaNormalStateKoopaLeftMovingState","KoopaMovingLeft",30,45,5),
             new SpritesNode("KoopaNormalStateKoopaRightMovingState","KoopaMovingRight",30,45,5),
             new SpritesNode( "KoopaShelledStateKoopaIdleState","KoopaStomped",32,28),
             new SpritesNode("KoopaShelledStateKoopaLeftMovingState","KoopaStomped",32,28),
             new SpritesNode("KoopaShelledStateKoopaRightMovingState","KoopaStomped",32,28),
             new SpritesNode("Pipe","Pipe",72,74),
             new SpritesNode("MiddlePipe","MiddlePipe",74,122),
             new SpritesNode("HighPipe","HighPipe",72,170),
             new SpritesNode("QuestionBlock","QuestionBlock",35,35,5),
             new SpritesNode("RedMushroom","RedMushroom",28,28),
             new SpritesNode("RockBlock","RockBlock",35,35),
             new SpritesNode("DeadMario","DeadMario"),
             new SpritesNode("SmallMarioLeftIdle","SmallMarioLeftIdle",34,32),
             new SpritesNode("SmallMarioLeftJumping","SmallMarioLeftJumping",34,31),
             new SpritesNode("SmallMarioLeftMoving","SmallMarioLeftMoving",34,32,4),
             new SpritesNode("SmallMarioRightIdle","SmallMarioRightIdle",34,32),
             new SpritesNode("SmallMarioRightJumping","SmallMarioRightJumping",34,31),
             new SpritesNode("SmallMarioRightMoving","SmallMarioRightMoving",34,32,4),
             new SpritesNode("SmallMarioLeftBreaking","SmallMarioLeftBreaking",34,32),
             new SpritesNode("SmallMarioRightBreaking","SmallMarioRightBreaking",34,32),
             new SpritesNode("BigMarioRightBreaking","BigMarioRightBreaking",32,64),
             new SpritesNode("BigMarioLeftBreaking","BigMarioLeftBreaking",32,64),
             new SpritesNode("FireMarioRightBreaking","FireMarioRightBreaking",32,64),
             new SpritesNode("FireMarioLeftBreaking","FireMarioLeftBreaking",32,64),
             new SpritesNode("Star","Star",35,40,4),
             new SpritesNode("BigHill","BigHill"),
             new SpritesNode("BigBush","BigBush"),
             new SpritesNode("SmallBush","SmallBush"),
             new SpritesNode("MiddleCloud","MiddleCloud"),
             new SpritesNode("SmallHill","SmallHill"),
             new SpritesNode("BigCloud","BigCloud"),
             new SpritesNode("SmallCloud","SmallCloud"),
             new SpritesNode("FireBall","FireBall"),
             new SpritesNode("FireExplosion","FireExplosion",0,0,3),
        };

        private List<SpritesNode> spritesList;

        public SpritesLoading()
        {
            spritesList = new List<SpritesNode>();
            XMLWriter("Sprites.xml", spritesCollection);
        }

        public Dictionary<string, SpritesNode> SpritesInfo()
        {
            Dictionary<string, SpritesNode> spritesInfo = new Dictionary<string, SpritesNode>();
            XMLReader("Sprites.xml");
            foreach (SpritesNode node in this.spritesList)
            {
                spritesInfo.Add(node.ObjectName, node);
            }
            return spritesInfo;
        }


        private void XMLReader(string path)
        {
            spritesList = new List<SpritesNode>();
            using (var reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                var serializer = new XmlSerializer(typeof(List<SpritesNode>));
                spritesList = (List<SpritesNode>)serializer.Deserialize(reader);
            }
        }

        private static void XMLWriter(string path, List<SpritesNode> list)
        {
            using (var writer = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<SpritesNode>));
                serializer.Serialize(writer, list);
            }
        }


    }
}
