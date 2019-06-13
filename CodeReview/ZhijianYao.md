Author: Zhijian Yao  
Date:  28 May, 2019  
Sprint: 2  

## Readability Review  

Name of .cs file: BrickBlockState.cs  
Author of .cs file: Yangjiayi Mu  
Number of minutes taken to complete the review: 10 minutes  
1. Instance variables in the class are easy to read 
2. Mehtod Type is not explained what it can help to implement the block object
3. Directives that are not used should be deleted

Name of .cs file: UsedBlockState.cs  
Author of .cs file: Yangjiayi Mu  
Number of minutes taken to complete the review: 10 minutes  
1. Each Mehtod has a clear name that defines what it does  
2. The Construcotr has a formal parameter block, which is not used anywhere  

Name of .cs file: KoopaObject.cs  
Author of .cs file: Bogetich Tre  
Number of minutes taken to complete the review: 10 minutes  
1.	Magic number is not explained by its purpose  
2.  Move Method deos not have comment on how it actually works  
3.  Each Mehtod has a clear name that defines what it does  

## Quality Review  

Name of .cs file: DeadMarioState.cs    
Author of .cs file: Yangjiayi Mu  
Number of minutes taken to complete the review: 20 minutes  

Each Method is clear and it serves what it does. I would suggest  
make dead Mario as a concrete class implements IMario instead of   
treating as a state, since in each state, the method Die is the  
same in every state class. Eventually, there will be FireMario,  
SuperMario,  SmallMario, and DeadMario, which implement  IMario  
interface. There are many transitions between these mario classes,   
like small Mario eating fire flower becoming  fire Mario, fire Mario   
taking damage becomes super Mario etc. These relations form another   
state pattern, which makes state as a class memeber.


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
