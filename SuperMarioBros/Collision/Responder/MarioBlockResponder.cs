using SuperMarioBros.Blocks;
using SuperMarioBros.GameStates;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class MarioBlockResponder : MarioBlockCollisionHandler, ICollisionResponder
    {
        private delegate void MarioBlockHandler(IMario mario, IBlock block, Direction direction);

        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            IMario mario = (IMario)mover;
            IBlock block = (IBlock)target;
            var key = (mario.HealthState.GetType(), block.GetType());
            if (marioBlockResponder[direction].ContainsKey(key))
                marioBlockResponder[direction][key](mario, block, direction);
        }

        private Dictionary<Direction, Dictionary<(Type, Type), MarioBlockHandler>> marioBlockResponder = new Dictionary<Direction, Dictionary<(Type, Type), MarioBlockHandler>>
        {
            { Direction.top, marioBlockTopSideResponder},
            { Direction.left,marioBlockLeftOrRightSideResonder},
            { Direction.right,marioBlockLeftOrRightSideResonder},
            { Direction.bottom,marioBlockbottomSideResonder},
        };

        private static Dictionary<(Type, Type), MarioBlockHandler> marioBlockTopSideResponder = new Dictionary<(Type, Type), MarioBlockHandler>
        {
            { (typeof(SmallMario), typeof(BlueBrickBlock)), MarioOnGround},
            { (typeof(BigMario), typeof(BlueBrickBlock)), MarioOnGround},
            { (typeof(FireMario), typeof(BlueBrickBlock)), MarioOnGround},

            { (typeof(SmallMario), typeof(BlueRockBlock)), MarioOnGround},
            { (typeof(BigMario), typeof(BlueRockBlock)), MarioOnGround},
            { (typeof(FireMario), typeof(BlueRockBlock)), MarioOnGround},

            { (typeof(SmallMario), typeof(BrickBlock)), MarioOnGround},
            { (typeof(BigMario), typeof(BrickBlock)), MarioOnGround},
            { (typeof(FireMario), typeof(BrickBlock)), MarioOnGround},

            { (typeof(SmallMario), typeof(ConcreteBlock)), MarioOnGround},
            { (typeof(BigMario), typeof(ConcreteBlock)), MarioOnGround},
            { (typeof(FireMario), typeof(ConcreteBlock)), MarioOnGround},

            { (typeof(SmallMario), typeof(QuestionBlock)), MarioOnGround},
            { (typeof(BigMario), typeof(QuestionBlock)), MarioOnGround},
            { (typeof(FireMario), typeof(QuestionBlock)), MarioOnGround},

            { (typeof(SmallMario), typeof(RockBlock)), MarioOnGroundOrMoveRight},
            { (typeof(BigMario), typeof(RockBlock)), MarioOnGroundOrMoveRight},
            { (typeof(FireMario), typeof(RockBlock)), MarioOnGroundOrMoveRight},

            { (typeof(SmallMario), typeof(UsedBlock)), MarioOnGround},
            { (typeof(BigMario), typeof(UsedBlock)), MarioOnGround},
            { (typeof(FireMario), typeof(UsedBlock)), MarioOnGround},

            { (typeof(SmallMario), typeof(ItemBrickBlock)), MarioOnGround},
            { (typeof(BigMario), typeof(ItemBrickBlock)), MarioOnGround},
            { (typeof(FireMario), typeof(ItemBrickBlock)), MarioOnGround},
        };
        private static Dictionary<(Type, Type), MarioBlockHandler> marioBlockLeftOrRightSideResonder = new Dictionary<(Type, Type), MarioBlockHandler>
        {

            { (typeof(SmallMario), typeof(BlueBrickBlock)), MoverHorizontallyBlock},
            { (typeof(BigMario), typeof(BlueBrickBlock)), MoverHorizontallyBlock},
            { (typeof(FireMario), typeof(BlueBrickBlock)), MoverHorizontallyBlock},

            { (typeof(SmallMario), typeof(BlueRockBlock)), MoverHorizontallyBlock},
            { (typeof(BigMario), typeof(BlueRockBlock)), MoverHorizontallyBlock},
            { (typeof(FireMario), typeof(BlueRockBlock)), MoverHorizontallyBlock},

            { (typeof(SmallMario), typeof(BrickBlock)), MoverHorizontallyBlock},
            { (typeof(BigMario), typeof(BrickBlock)), MoverHorizontallyBlock},
            { (typeof(FireMario), typeof(BrickBlock)), MoverHorizontallyBlock},

            { (typeof(SmallMario), typeof(ConcreteBlock)), MoverHorizontallyBlock},
            { (typeof(BigMario), typeof(ConcreteBlock)), MoverHorizontallyBlock},
            { (typeof(FireMario), typeof(ConcreteBlock)), MoverHorizontallyBlock},

            { (typeof(SmallMario), typeof(QuestionBlock)), MoverHorizontallyBlock},
            { (typeof(BigMario), typeof(QuestionBlock)), MoverHorizontallyBlock},
            { (typeof(FireMario), typeof(QuestionBlock)), MoverHorizontallyBlock},

            { (typeof(SmallMario), typeof(RockBlock)), MoverHorizontallyBlock},
            { (typeof(BigMario), typeof(RockBlock)), MoverHorizontallyBlock},
            { (typeof(FireMario), typeof(RockBlock)), MoverHorizontallyBlock},

            { (typeof(SmallMario), typeof(UsedBlock)), MoverHorizontallyBlock},
            { (typeof(BigMario), typeof(UsedBlock)), MoverHorizontallyBlock},
            { (typeof(FireMario), typeof(UsedBlock)), MoverHorizontallyBlock},

            { (typeof(SmallMario), typeof(ItemBrickBlock)), MoverHorizontallyBlock},
            { (typeof(BigMario), typeof(ItemBrickBlock)), MoverHorizontallyBlock},
            { (typeof(FireMario), typeof(ItemBrickBlock)), MoverHorizontallyBlock},
        };
        private static Dictionary<(Type, Type), MarioBlockHandler> marioBlockbottomSideResonder = new Dictionary<(Type, Type), MarioBlockHandler>
        {
            { (typeof(SmallMario), typeof(HiddenBlock)), SmallMarioVsHidden},
            { (typeof(BigMario), typeof(HiddenBlock)), BigOrFireMarioVsHidden},
            { (typeof(FireMario), typeof(HiddenBlock)), BigOrFireMarioVsHidden},

            { (typeof(SmallMario), typeof(BlueBrickBlock)), SmallMarioVsBrickBlock},  
            { (typeof(BigMario), typeof(BlueBrickBlock)), BigOrFireMarioVsBrickBlock}, //Color to do
            { (typeof(FireMario), typeof(BlueBrickBlock)), BigOrFireMarioVsBrickBlock},
           
            { (typeof(SmallMario), typeof(BlueRockBlock)), MoverVerticallyBounce},
            { (typeof(BigMario), typeof(BlueRockBlock)), MoverVerticallyBounce},
            { (typeof(FireMario), typeof(BlueRockBlock)), MoverVerticallyBounce},

            { (typeof(SmallMario), typeof(BrickBlock)), SmallMarioVsBrickBlock},
            { (typeof(BigMario), typeof(BrickBlock)), BigOrFireMarioVsBrickBlock},
            { (typeof(FireMario), typeof(BrickBlock)), BigOrFireMarioVsBrickBlock},

            { (typeof(SmallMario), typeof(ConcreteBlock)), MoverVerticallyBounce},
            { (typeof(BigMario), typeof(ConcreteBlock)), MoverVerticallyBounce},
            { (typeof(FireMario), typeof(ConcreteBlock)), MoverVerticallyBounce},
 
            { (typeof(SmallMario), typeof(QuestionBlock)), SmallMarioVsQuestionOrItemBrickBlock},
            { (typeof(BigMario), typeof(QuestionBlock)), BigOrFireMarioVsQuestionOrItemBrickBlock},
            { (typeof(FireMario), typeof(QuestionBlock)), BigOrFireMarioVsQuestionOrItemBrickBlock},

            { (typeof(SmallMario), typeof(RockBlock)), MoverVerticallyBounce},
            { (typeof(BigMario), typeof(RockBlock)), MoverVerticallyBounce},
            { (typeof(FireMario), typeof(RockBlock)), MoverVerticallyBounce},

            { (typeof(SmallMario), typeof(UsedBlock)), MarioVsUsedBlock},
            { (typeof(BigMario), typeof(UsedBlock)), MarioVsUsedBlock},
            { (typeof(FireMario), typeof(UsedBlock)), MarioVsUsedBlock},

            { (typeof(SmallMario), typeof(ItemBrickBlock)), SmallMarioVsQuestionOrItemBrickBlock},
            { (typeof(BigMario), typeof(ItemBrickBlock)), BigOrFireMarioVsQuestionOrItemBrickBlock},
            { (typeof(FireMario), typeof(ItemBrickBlock)), BigOrFireMarioVsQuestionOrItemBrickBlock},
        };
    }
}
