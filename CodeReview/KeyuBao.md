Author of the review: Keyu Bao  
Date of the review: 28 May 2019  
Sprint Number: 2  

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
Readable:  
* Every method does one job and is easy to read.
* No long method.


Class Name: MarioObject.cs  
Author of the code: Yangjiayi Mu and Zhijian Yao  
Time fo the review: 20 min  
Unreadable:  
* The code does not check the right and left edges corectly.
* Some unnecessary directives

Readable:  
* Every method does one job and is easy to read.
* No long method.
* Some meaningful comments


