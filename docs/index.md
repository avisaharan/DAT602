## Week 1

This week we discussed the course outline and started learning SQL. We overviewed the project requirements, timeline of project and set up the environment to start working on our project. We set up the working environment by installing Vistual Studio and MySQL Community server and changing the toolbar content in Visual Studio to include MySQL buttons (for creating MySQL script with new connection or using already created script). 
Finally I checked the working of MySQL with Visual studio by writing the sample script 'Show tables' and clicking on Run SQL in the SQL Server window in Visual Studio. 
I also installed SQL Workbench with MySQL server for easy navigabitity and editing of database. 

I also learned about SQL procedures- they look similar to functions in C# or Java but have much limited usage. SQL procedures requires changing the delimiter so that multiple statements can be executed, and they are stored in the server and can be called using - call <ProcedureName()>. Parameters of three kinds (IN, OUT and INOUT) can be passed to procedures. 

## Week 2

This week I practised MySQL using this tutorial- https://www.mysqltutorial.org/mysql-stored-procedure-tutorial.aspx. Learned more about the usage of parameters (IN, OUT and INOUT), conditons (IF, IF ELSE, CASE), loops (WHILE, REPEAT and LEAVE) and CURSOR to iterate through a result set. 

Then we had a learned how to create CRUD tables- the fields to choose and how to arrange them along with the actions required. I created the CRUD for my Snake and Ladder game after mutiple iterations in fields and tables, but still I guess that a lot of changes would be required as I create my game in SQL. 

After creating the CRUD table, I created the ERD (Crow's foot notation) diagram for my game (which turned out to be very different from the fields in CRUD table and lead me to change the CRUD table again), in which it was hard to avoid using the same fields in different tables, and instead linking the tables by foreign keys. I would be making many changes in the ERD as I create the game (as I already have after creating the storyboards and game scenarios.) I actually should have created the ERD after finishing the storyboards. 

## Week 3

This week I worked practised MySQL for the game: 
I created the DDL and DML procedures for my game- which can found in my github repository for this game: https://github.com/avisaharan/DAT602
The DDL and DML fields are created based on the ERD diagram and are currently just a sample for the game and many more fields, functions and procedures will be added. 

This week in class we practised DELETE, UPDATE and DELETE ON CASCADE. 
I found DELTETE ON CASCADE really useful. I've added it with with all my foreign keys that relates to the other tables by one-to-any relation. This helps keep the data relevant and organised. 



