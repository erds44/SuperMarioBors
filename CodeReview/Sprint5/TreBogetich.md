Author of the review: Tre  
Date of the review: 9 July 2019  
Sprint Number: 5  

##Quality review  
Class Name: HeadsUp.cs  
Author of the code: Zhijian Yao  

Comments:  
This code is overall easy to understand, and is very well structured. There are quite a few magic numbers, but they are all compartmentalized into this single class. The magic numbers are all used to represent where the words appear on the screen. This fix will be easy and would just require reading in those magic numbers, along with the words to appear with them, from a file to be data driven. Other than knowing those, the class has low coupling and is not very complex.  

##Readability review  
Class Name: Camera.cs  
Author of the code: Yangjiayi Mu and Zhijian Yao  
Time for the review: 10 minutes  

Comments:  
The code for the camera class is written in seven clean and concise methods. The fields are descriptive of what is happening in the code, and for the most part the methods have less than six lines if code. The two’s in the update method seem like magic numbers and just need to be commented on where they came from.