# Readability Review  
Author of code review: Yangjiayi Mu  
Date of the code review: 5/28/2019  
Sprint number: 2  
Name of the .cs file being reviewed: GoombaObject.cs, RightMovingGoombaState.cs, LeftMovingGoombaState.cs  
Author of the .cs file being reviewed: Zhijian Yao  
Number of minutes taken to complete the review: 30  
Specific comments on what is readable and what is not:   

* Readable
	1. Clear variable and function name.
	2. High correspondence with interface.
	3. Comments on where not that direct.
	4. Only a few, simple parameters for each method, makes it easy to understand.
    5. Using good namespace to separate different modules of code.
	6. No long method.
* Unreadable
	1. Magic numbers in Move and CheckEdge methods with no comment.
	2. Contains unused namespaces.
    3. May throw NotImplementedException in state classes.