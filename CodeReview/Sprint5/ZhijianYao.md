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

## Quality Review 
Date: 12 July, 2019  
Name of .cs file: GeneralHandler.cs  
Author of .cs file: ZhijianYao Keyu Bao  
Number of minutes taken to complete the review: 10 minutes  
1. The GeneralHandler class mainly serves the purpose of a  
help method for every other class to deal with collision.  
However, it is not a proper use of abstract calss, since   
this abstract class only saves a space of one or two line  
(most functionality only takes one or two lines) which is  
overbored. One way to deal with it is to write the specific  
mehtod into its subclass.  
2. In the ResolveOverlap and ReverseDirection method, there  
is no need to do the branching hrere, since the dictionary  
already determines the direction. I understand that the method  
wants to be abstract so that it can handle all kinds of cases,  
but it also brings branching as well. One way to solve this is      
reversing the direcion or overlap based on the direcion given  
by the dictionary.

