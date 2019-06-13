Author of the review: Keyu Bao  
Date of the review: 28 May 2019  
Sprint Number: 2  
## Readability Review
Class Name: DeadMarioState.cs  
Author of the code: Yangjiayi Mu and Zhijian Yao  
Time fo the review: 5 min  
Unreadable:  
* RightIdle seems unlikely to happen in this class and might be deleted.
* Variable (String type) is unnecessary in current implementation and could be deleted.

Readable:  
* Every method does one job and is easy to read.
* No long method.

Class Name: LeftCrouchingMarioState.cs and other similar MarioState classes  
Author of the code: Yangjiayi Mu and Zhijian Yao  
Time fo the review: 5 min each  
Unreadable:  
* Some unnecessary directives
* Variable (String type) is unnecessary in current implementation and could be deleted.  
* Left/Right states shares many similarities and might be integrated into one class.
* Some magic number in Update()

Readable:  
* Every method does one job and is easy to read.
* No long method.


Class Name: MarioObject.cs  
Author of the code: Yangjiayi Mu and Zhijian Yao  
Time fo the review: 20 min  
Unreadable:  
* The code does not check the right and left edges corectly.
* Some unnecessary directives
* Some magic number in checking edges.

Readable:  
* Every method does one job and is easy to read.
* No long method.
* Some meaningful comments


## Code Quality Review
Class Name: DeadMarioState.cs and other state classes  
Author of the code: Yangjiayi Mu and Zhijian Yao  
Time fo the review: 5 min each  
Comments:  
* RightIdle seems unlikely to happen in this class and might be deleted.
* If kept RightIdle, it might be better to check the argument instead of use if-else,which might cause problems.
* The variable type seems unnecessary so far; I recommend to comment it out or to delete it.
* There are pairs of states classes that contain some duplicated code, like rightMoving and leftMoving. They only differ in the direction. I recommend to re-design these classes into one class if they will only differ in the direction in the future.
 
Possible changes:  
* One possible change to this class is what states the current mario can change to. This class can handle this change by changing the corresponding methods in the class, like ToBig().
* Another possible change is the jumping or moving speed of different Mario might change. Currently, the vector of jumping or moving is hard-coded and is the same for all different states.
It would be very diffcult and error-prone to manually change each velocity. I recommend to re-design this part. One possible solution is to create a vairable for velocity and to pass it to each state class.