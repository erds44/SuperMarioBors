Author of the review: Tre  
Date of the review: 6 June 2019  
Sprint Number: 3  

## Quality Review  
Class Name: MarioBlockCollisionHandler.cs  
Author of the code: Yangjiayi Mu  
Time for the review: 10 min  
  
Comments:  
    Broken:  
        - The dictionary or the actions need to be updated. When the hidden block is approached from above and the mario gets to the point where the detection is sensed as a collision from the bottom of the block, the block appears and Mario gets trapped inside. Direction of collision cannot be the only check for hiddent blocks.  
        - Comments on quality: Code is written neat and efficiently, but the above item needs to be fixed.  
        - Changes: Mario's velocity could be sent in to check whether Mario is moving up or down.  
  
Class Name: Mario.cs and implementations of IMarioState.cs
Author of the code: Zhijian Yao 
Time for the review: 10 min  
  
Comments:  
    Improvement Needed:  
        - When Mario takes damage from an enemy, collision is instantly checked again. This means that in an instant Mario can go from the fire Mario state to the dead Mario state.  
        - Comments on quality: Code is easily readable  
        - Changes: There should maybe be an invulnerability state that Mario is sent to after taking damage. It should be sent in with the time delay for taking damage, and this can be used for the star Mario as well.    



        
  
## Readability Review  
  
Class Name: CollisionManager.cs  
Author of the code: Zhijian Yao  
Time for the review: 10 min   
  
Comments:  
    Clear and Concise:  
        - The code is easily readable and only has two methods. The problem with this class is that this collision manager knows that it is dealing with mario and another object. This does not account for when enemies or items collide with blocks. This needs to be changed, but the code is suitable for testing purposes and is very clear on how it works.    





