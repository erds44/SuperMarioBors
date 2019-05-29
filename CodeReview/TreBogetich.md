Author of the review: Tre  
Date of the review: 28 May 2019  
Sprint Number: 2  

Class Name: MarioObject.cs  
Author of the code: Yangjiayi Mu and Zhijian Yao  
Time for the review: 20 min  

Comments:  
    Needs Improvement:  
        The code here does a few things incorrectly such as the left and right edge boundaries.  
        Currently a lot of objects are hard coded into the program.  
        A time delay needs to be added so that the draw and update functions work better.  

Class Name: KoopaObject.cs and GoombaObject.cs  
Author of the code: Tre Bogetich  
Time for the review: 5 min  

Comments:  
    Repetitive:   
        The classes here can be simplified primarily to objects that inherit from an IEnemy interface.  
        The code for each of these works fine, but can be simplified.  

Class Name: RightCrouchingMarioState.cs  
Author of the code: Yangjiayi Mu and Zhijian Yao   
Time for the review: 5 min  

Comments:  
    Broken:   
        This code makes it so that after a crouch is initiated that left and right movement can't work anymore. Much of the Mario motion and keys need to be fixed, but are overall effective for a proof of concept.  

