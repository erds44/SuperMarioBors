Author of the review: Tre
Date of the review: 21 June 2019
Sprint Number: 4

##Quality Review
Class Name: MarioPhysics.cs and other corresponding Mario classes
Author of the code: Zhijian Yao  
Time for the review: 20 min

Comments:
Needs Fixing:  
- When Mario jumps his x velocity is reduced when it should remain constant. 
- During Mario's growth phase, Mario is not allowed to move but the enemies are.
- Mario sometimes does not reach his invulnerability state after being collided with because the timer has not been reset to accomodate. This results in a near instant death.
- When Mario is in the invulnerability state and is still flashing, Mario is not able to go through all of his sprites for an animation, but rather gets stuck on two.

Class Name: DynamicAndStaticObjectsHandler.cs  
Author of the code: Yangjiayi Mu  
Time for the review: 10 min  

Comments:
Readability:   
- In this collision handler, it is specifically dynamic and static objects that are being dealt with. In the code though, these objects are only referenced as obj1 and obj2. This can be improved to something along the lines of dynObj and statObj or something of the sort.  
- MoveDynamic() and direction could be defined better. In this implementation, direction is the side of the second object that is being collided with. This could be more explicitly stated.  
- Other than this the code is very readable and it is easy to see what collisions led to what responses.

