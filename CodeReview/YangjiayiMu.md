Author of code review: Yangjiayi Mu  
Sprint number: 2  

# Readability Review  
Date of the code review: 5/28/2019  
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

# Maintainability Review  
Date of the code review: 5/31/2019  
Name of the .cs file being reviewed: UniversalSprite.cs  
Author of the .cs file being reviewed: Zhijian Yao    
* Good Maintainability
	1. Provided universal interface.  
	2. Clear variable and function name.  
	3. Good encapsulation. 
* Drawbacks
	1. Some fields should be readonly.
	2. Pixel is the unit of drawing. We don't really need to use vectors. Using points will be better.
	3. Forces each sprite changes at the same rate.
* Future change
	Change the type of size field, and add some readonly modifier to fields. Add a change rate parameter.

Date of the code review: 5/31/2019  
Name of the .cs file being reviewed: MushroomObject.cs  
Author of the .cs file being reviewed: Keyu Bao  
* Good Maintainability
	1. Using edge parameters, allows flexible construction
	2. Using velocity parameter, for better customization.
	3. clear code and name.
* Drawbacks
	1. I don't think we really need to use {get; set;} for sprite fields.
	2. No comment in unimplemented methods.
	3. Some members of the class is public. Bad encapsulation.
	4. Use new interface for MushroomObject and other items. They may have same methods(collide with Mario).
* Future change
	Change the visibility of fields. Implement BeKicked() method. Trim some unused method.  


