## Readability Review

Author of the review: Keyu Bao  
Date of the review: 7 June 2019  
Sprint Number: 3

Class Name: BrickBlock.cs and other Block classes  
Author of the code: Yangjiayi Mu and Zhijian Yao  
Time fo the review: 5 min each  
Unreadable:  
* The author is trying to modify the collision check; the current verision seems complicated and confusing.  
* There is a GetRealType() method, and its function is not obvious to the reader; Adding some comments would be better.

Readable:  
* Every method does one job and is easy to read.
* No long method.
* Create an abstract class for blocks, which is easy to read.
* With abstact class, all concrete classes are very simple,

Class Name: LevelLoading.cs  
Author of the code: Keyu Bao and Zhijian Yao  
Time fo the review: 5 min  
Unreadable:  
* Some varibale names are confusing and need to be changed;
* Loading of mario is kind of hard-coded and need to be modified.

Readable:  
* The class only peroform one job and is clear.
* The method is not long.

## Maintainability Review

Author of the review: Keyu Bao  
Date of the review: 13 June 2019  
Sprint Number: 3

Class Name: ObjectSizeManager.cs and LevelLoading.cs  
Author of the code: Keyu Bao and Zhijian Yao  
Time fo the review: 5 min each
Comments:  
* The structure of the class is very clear, which is divided into two parts;
* Two parts are designed in the same way, which is good for future changes;
* There is a uneasonable default Point for objects. I recommended to replace it with an error message;
* As mentioned below, this class only works for a specific structure; I recommend to do more research and change to other flexible methods.

Possible change:  
* One possible change is that the structure of the XML file is re-designed. This class is hard to respond to this change because this class is designed to read XML files with a specific structure. All methods needed to be changed if XML files changed.

Class Name: CollisionDetection.cs  
Author of the code: Yangjiayi Mu and Zhijian Yao  
Time fo the review: 5 min   
Comments:  
* This class contains a very long method with a branch to detect the collision. I recommend to discuss to find a way to divide this method into smaller methods.

Possible changes:  
* One possible change is that the game change the rule of deciding the direction of the collision; this class is hard to respond to the change. One possible solution is to introduce a coefficient to represent the critical ratio of the width and height.



