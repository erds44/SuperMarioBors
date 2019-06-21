#Author of code review: Yangjiayi Mu  
#Sprint number: 4  

##Readability Review
Date of the code review: 6/7/2019  
Name of the .cs file being reviewed: MarioEnemyCollisionHandler.cs  
Author of the .cs file being reviewed: Zhijian Yao  
Number of minutes taken to complete the review: 10  
Specific comments on what is readable and what is not:   
* Readable
	1. Clear variable and function name.
	2. Only a few parameters, easy to understand what are supposing to use in method.
    3. Using typeof() operation to avoid string use.
	4. No long method.
* Unreadable
	1. Dictionary is very long, hard to find if anything wrong.
	2. No comment in the method HandleCollision, so hard to figure out how it works.

Name of the .cs file being reviewed: CollisionDetection.cs  
Author of the .cs file being reviewed: Zhijian Yao  
Number of minutes taken to complete the review: 10  
Specific comments on what is readable and what is not:   
* Readable
	1. Clear variable and function name.
	2. Using enum to avoid string use.
* Unreadable
	1. Very big, nested if-else clause.
	2. No comment in the method Detect, so hard to figure out how it works.

##Maintainability Review  
Due next week.  