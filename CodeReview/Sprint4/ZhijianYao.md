## Sprint: 4
## Readability Review 
Date: 21 June, 2019  
Name of .cs file: DynamicLoading.cs  
Author of .cs file: Yangjiayyi Mu  
Number of minutes taken to complete the review: 20 minutes  
1. Instance variables in the class are easy to read.   
2. In the Initlialize method, clear is used for Dead Mario  
rest purpose, which is very clean.  
3. In Load Method, it keeps checking if objects are in the  
cemera boundary. If so, add them to the corresponding list,  
which is good. 
4. What is not easy to read is that there are too many info  
in the Initlialize mehtod, try to break them down into peices.  

## Quality Review
Date: 28 June, 2019  
Name of .cs file: XMLProcessor  
Author of .cs file: Keyu Bao  
Number of minutes taken to complete the review: 15 minutes  

The XMLProcessor is used to generate some xml files and   
read thoes xml files translating into lists of obejects.  
However, for each object node, it is tedious to enter them  
line by line even with copying and pasting. Ideally, a decent  
XMLProcessor should simplify the setting nodes process. For  
example, if we want to set up some goomba objects into the xml  
file. Fist cerate a list of all the goombas, with their positions.  
Then call a mehtod by passing the list and the method will generate  
the corresponding objects nodes such that it saves a lot of time.  
In additon, try to think about how to implemente a builder class,  
espcially for the floor portion of the Mario Game. When givng the  
stating positon, height and width, the class might use some loops  
to auto generate these obejects.  
PS: the XMLProcessor class should be objectloading now  