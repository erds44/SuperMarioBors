Author of the review: Keyu Bao  
Date of the review: 7 June 2019  
Sprint Number: 3
## Readability Review
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

