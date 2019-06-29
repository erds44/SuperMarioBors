#Author of code review: Keyu Bao
#Sprint number: 4  

##Readability Review
Date of the code review: 6/21/2019  
Name of the .cs file being reviewed: DynamicAndDynamicObjectsHandler.cs, DynamicAndStaticObjectsHandler.cs  
Author of the .cs file being reviewed: Zhijian Yao, Keyu And Tre 
Number of minutes taken to complete the review: 10 each  
Specific comments on what is readable and what is not:   
* Readable
	1. Good, meaningful names.
	2. Leave empty lines between groups of entries, so it's easy to find which part belongs to.
	3. Methods are short; no long branches or methods

* Unreadable
	1. The entries of dictionary are poorly ordered.
	2. The order of methods do not match that of entries. Make it harder to debug and to make changes.
    Suggestion: Reorganize the order of methods and entries.

## Code Quality Review
Class Name: ObjectsLoading.cs  
Author of the code: Zhijian Yao nad Keyu Bao  
Time fo the review: 20 min  

There are many class members and many of them have similiar names,  
which might cause troubles for reading and changings. In the method  
LoadStatics, the condition in the switch statement is represented by  
integer; this is not a good practice. Using strings might be better.   
There are also some similar methods(like the one loading dynamics  
and the one loading nonColliables). I suggest to refractor these  
methods later.  

Another problem exits in the closely related class, ObjectNode.  
The super long constructor is very confusing and the function of some  
members are not very clear, like the size and the width.

This design is not very flexible to changes. Since the constructor of  
ObjectNode tries to support every type of the constructor in the project,  
every change in the constructor will lead to many changes in this class.
