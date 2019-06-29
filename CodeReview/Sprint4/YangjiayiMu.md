#Author of code review: Yangjiayi Mu  
#Sprint number: 4  

##Readability Review
Date of the code review: 6/21/2019  
Name of the .cs file being reviewed: XMLProcessor.cs, ObjectNode.cs  
Author of the .cs file being reviewed: Keyu Bao  
Number of minutes taken to complete the review: 10  
Specific comments on what is readable and what is not:   
* Readable
	1. Good variable name and nested, good encapsulation.
	2. Put comment for each block of lists, so it's easy to find which part belongs to.
	3. Using many methods to break long code into small parts, easy to read.
	4. Using Polymorphism for constructing ObjectNode.

* Unreadable
	1. Unused name spaces.
	2. Using full name for all types of objects. Consider using a dictionary for saving space.

##Maintainability Review  
Date of the code review: 6/28/2019
Name of the .cs file being reviewed: KeyboardController.cs, ControllerMessager.cs, Physics.cs
Author of the .cs file being reviewed: Zhijian Yao
Number of minutes taken to complete the review: 10
Specific comments on Maintainability:
* Maintainable
	1. Assigned variable names for each "magical number", make it easy to understand.
	2. Most methods are within 10 lines, so easy to understand.
	3. Use forEach loop to detect key up event.
* Drawbacks
	1. The ControllerMessager class has a binary flag variable, and it becomes very long, make it harder to add new operations (What if mario needs more actions?)
	2. ControllerMessager still using Command pattern. Why not use delegate to reduce the classes it uses?
* Solution
	1. Use an array, or list, whatever collection class to contain the action flags.
	2. Use delegate as an alternative to Command pattern.
