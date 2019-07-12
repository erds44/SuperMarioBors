﻿using SuperMarioBros.Utility;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using static SuperMarioBros.Utility.XMLUtility;

namespace SuperMarioBros.Loading
{
    public class SpritesLoader
    {
        private readonly List<SpritesNode> spritesCollection = new List<SpritesNode>
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
             new SpritesNode("BlueBrickBlock","BlueBrickBlock",35,35),
             new SpritesNode("BlueRockBlock","BlueRockBlock",35,35),
             new SpritesNode("ItemBrickBlock","BrickBlock",35,35),

             //special item
             new SpritesNode("BrickDebris","BrickDebris"),
             new SpritesNode("Coin","Coin",14,26,5,3),
             new SpritesNode("BigCoin","BigCoin",25,30,3,10),
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
             new SpritesNode("Flower","Flower",32,32,5,15),
             new SpritesNode("GoombaLeftMovingState","Goomba",30,30,2,15),
             new SpritesNode("GoombaRightMovingState","Goomba",30,30,2,15),
             new SpritesNode("GoombaStompedState","StompedGoomba",32,16),
             new SpritesNode("FlippedGoombaIdleState","Goomba",30,30),
             new SpritesNode("StompedKoopaRightMoving","KoopaStomped",32,28),
             new SpritesNode("StompedKoopaLeftMoving","KoopaStomped",32,28),
             new SpritesNode("GreenMushroom","GreenMushroom",29,29),
             new SpritesNode("HiddenBlock","HiddenBlock",35,35),
             new SpritesNode("KoopaNormalStateKoopaLeftMovingState","KoopaMovingLeft",30,45,5,15),
             new SpritesNode("KoopaNormalStateKoopaRightMovingState","KoopaMovingRight",30,45,5,15),
             new SpritesNode( "KoopaShelledStateKoopaIdleState","KoopaStomped",32,28),
             new SpritesNode("KoopaShelledStateKoopaLeftMovingState","KoopaStomped",32,28),
             new SpritesNode("KoopaShelledStateKoopaRightMovingState","KoopaStomped",32,28),
             //new SpritesNode("Pipe","Pipe",72,74),
             //new SpritesNode("MiddlePipe","MiddlePipe",74,122),
             //new SpritesNode("HighPipe","HighPipe",72,170),
             //new SpritesNode("HugePipeV","HugePipeV",46,350),
             //new SpritesNode("HugePipeH","HugePipeH",54,87),
             new SpritesNode("QuestionBlock","QuestionBlock",35,35,5,15),
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
             new SpritesNode("FlagPole","FlagPole",16,600), //304
             new SpritesNode("Castle","Castle",32,62),

            new SpritesNode("SmallMarioLeftSliding","SmallMarioLeftSliding",26,30),
            new SpritesNode("SmallMarioRightSliding","SmallMarioRightSliding",26,30),
            new SpritesNode("BigMarioLeftSliding","BigMarioLeftSliding",28,60),
            new SpritesNode("BigMarioRightSliding","BigMarioRightSliding",28,60),
            new SpritesNode("FireMarioLeftSliding","FireMarioLeftSliding",28,60),
            new SpritesNode("FireMarioRightSliding","FireMarioRightSliding",28,60),

            new SpritesNode("WinFlag","WinFlag",0,0),
            new SpritesNode("Flag","Flag",32,32),
            new SpritesNode("TeleportPipe","HighPipe",72,170),
            new SpritesNode("TeleportHugePipeH","HugePipeH",54,87),
            new SpritesNode("LeftTopBrickDebris","LeftTopDerbis",0,0,1,1),
            new SpritesNode("RightTopBrickDebris","RightTopDerbis",0,0,1,1),
            new SpritesNode("LeftBottomBrickDebris","LeftBottomDerbis",0,0,1,1),
            new SpritesNode("RightBottomBrickDebris","RightBottomDerbis",0,0,1,1),
            new SpritesNode("LeftBottomBlueBrickDebris","BlueLeftBottomDebris",0,0,1,1),
            new SpritesNode("LeftTopBlueBrickDebris","BlueLeftTopDebris",0,0,1,1),
            new SpritesNode("RightBottomBlueBrickDebris","BlueRightBottomDebris",0,0,1,1),
            new SpritesNode("RightTopBlueBrickDebris","BlueRightTopDebris",0,0,1,1),

            /* new Pipe name and sprite */
             new SpritesNode("SmallPipe","Pipe",72,74),
             new SpritesNode("TeleporVerticalSmallPipe","Pipe",72,74),
             new SpritesNode("MiddlePipe","MiddlePipe",74,122),
             new SpritesNode("LargePipe","HighPipe",72,170),
             new SpritesNode("TeleportVerticalLargePipe","HighPipe",72,170),
             new SpritesNode("HighPipe","HugePipeV",46,350),
             new SpritesNode("TeleportHorizontalSmallPipe","HugePipeH",54,87),
             new SpritesNode("SmallMarioLeftCrouching","SmallMarioLeftIdle",34,32),
             new SpritesNode("SmallMarioRightCrouching","SmallMarioRightIdle",34,32),
        };

        private List<SpritesNode> spritesList;

        public SpritesLoader() { }

        public Dictionary<string, SpritesNode> SpritesInfo()
        {
            Dictionary<string, SpritesNode> spritesInfo = new Dictionary<string, SpritesNode>();
            XMLUtility.XMLWriter(Strings.SpritesFile, spritesCollection);
            spritesList = XMLReader<SpritesNode>(Strings.SpritesFile);
            foreach (SpritesNode node in this.spritesList)
            {
                spritesInfo.Add(node.ObjectName, node);
            }
            return spritesInfo;
        }
    }
}
