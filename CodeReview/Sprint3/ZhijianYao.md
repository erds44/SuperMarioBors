## Sprint: 3   
## Readability Review 
Date: 7 June, 2019  
Name of .cs file: AbstractBackground.cs  
Author of .cs file: Keyu Bao  
Number of minutes taken to complete the review: 20 minutes  
1. Instance variables in the class are easy to read 
2. In the update method, the actualy backgrond sprite only has one frame  
no sprite update required  
3. Notice that in background object, there is one abstract calss, and  
evey other background objects extend on the abstract class, in fact  
this can be accomplished by making a general class such that all the  
different background objects can be passed by a xml file  
4. In background objetcs, avoid abusing the string, even though string is  
clear, but it is hard to debug once there is something wrong with the string

## Quality Review  

Name of .cs file: AbstractBlock.cs   
Author of .cs file: Yangjiayi Mu    
Number of minutes taken to complete the review: 20 minutes   

The brick, conrete, hidden, and many other block classes extend the abstract  
block class. The only difference is that every block class has a different  
constructor. I would suggest that make abstractblock class as a block class  
such that the block class can have different states, like brick, concrete, etc.  
In order to make creations of a block, a type of block state needed to be passed  
into block's constructor to define what the block actual is. That requires some  
changes on levelloading file and the parser of levelloaidng. Making this change will  
also help to reduce the number of command needed, since the block can change itself  
instaed of creating a new block object each time. For exmalpe, is a block is used, the  
block state can be any, like used, conrete, etc and each state has its own implementation  
of used method.
