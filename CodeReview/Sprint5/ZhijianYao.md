## Sprint: 5
## Readability Review 
Date: 10 July, 2019  
Name of .cs file: SpriteLoader.cs  
Author of .cs file: Keyu Bao  
Number of minutes taken to complete the review: 10 minutes  
1. the list variable spriteCollection has naming issue, since  
the data type is list not collection. In addition, what if the  
data type gets changed later on and the naming also needs   
to be changed. Therefore, name this variable as spriteNodes  
would be better.  
2. the spriteCollection list also takes up the entire screen,  
consider put the variable to the last such that people can  
read the constructor and any other information directly.  
 
Name of .cs file: AudioLoader.cs  
Author of .cs file: Yangjiayi Mu
Number of minutes taken to complete the review: 10 minutes 
1. In constructor AudioLoader, there are many repeated codes,  
where adds nodes from a xmlReader and consider writing a seperate  
method such that it is easier to read. 


