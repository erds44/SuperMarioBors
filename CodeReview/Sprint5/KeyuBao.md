#Author of code review: Keyu Bao 
#Sprint number: 5

##Readability Review
Date of the code review: 07/10/2019  

Name of the .cs file being reviewed: UniversalSprite.cs  
Author of the .cs file being reviewed: Zhijian Yao  
Number of minutes taken to complete the review: 10  
Specific comments on what is readable and what is not:  
1.Most names are meaningful, like currentFrame and layerDepth; some can be more specific, like dt.
I recommend to use names like passedTime.  
2.Overall the class is well designed and works for all types of sprites. However, there are two methods(overloading) 
contains many duplicated code. I recommend to refractor that part in the future.


Name of the .cs file being reviewed: BlueBrickBlock.cs  
Author of the .cs file being reviewed: Zhijian Yao  
Number of minutes taken to complete the review: 5  
Specific comments on what is readable and what is not:  
This class is very similar to the class BrickBlock; they only differ in the constructor. I wonder if we could put these two class together to avoid duplicate code. One solution might be make one class to extend the other one. 

##Maintainability Review
Date of the code review: 07/12/2019  

Name of the .cs file being reviewed: UniversalSprite.cs  
Author of the .cs file being reviewed: Zhijian Yao  
Number of minutes taken to complete the review: 10   

This class is designed to draw and to update sprites. There are two draw methods. One is only used for special states and most code is the same. I recommend to provide a default color for other normal sprites such that only one method is needed.

Name of the .cs file being reviewed: SpriteFactory.cs  
Author of the .cs file being reviewed: Zhijian Yao  
Number of minutes taken to complete the review: 10 

This class is designed to create and to return the sprite requested by other classes. This class uses a dictionary to wrap up the detail about sprites. However, BrickBlockDebris and BlueBlockDebris are seperated from other sprites. Two special methods are also added to supoort these two types of sprites. This is not efficient. I recommend to refractor this part to integrate debris into regular dictionary. In this way, only one method is needed for creation.