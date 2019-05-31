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

