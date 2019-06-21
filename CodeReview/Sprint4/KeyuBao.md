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
