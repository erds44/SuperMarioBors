#Author of code review: Yangjiayi Mu  
#Sprint number: 5

##Readability Review
Date of the code review: 07/09/2019  
Name of the .cs file being reviewed: HeadsUp.cs  
Author of the .cs file being reviewed: Zhijian Yao  
Number of minutes taken to complete the review: 10  
Specific comments on what is readable and what is not:   
* Readable
	1. Assign a readonly variable for most "magical number", so it's easy to understand what the number means.
	2. Good method, event and variable name.
	3. Most methods are short and clear in logic.

* Unreadable
	1. Still has some magical number without any comment.
	2. Why put game logic thing such as death event, timeup event in HeadsUp class? It's supposed to be just a display unit.
	3. Nested if-else clause. I know it's inavoidable, but just hard to read.

Name of the .cs file being reviewed: GameState.cs  
Author of the .cs file being reviewed: Zhijian Yao  
Number of minutes taken to complete the review: 10  
Specific comments on what is readable and what is not:   
* Readable
	1. Class is small, clearly showing what it will do.
	2. No nested if-else clause.
	3. Methods are short, easy to understand.

* Unreadable
	1. Many magical numbers.
	2. No useful comments.

##Maintainability Review  
Due next week.