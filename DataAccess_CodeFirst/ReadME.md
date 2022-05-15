# CodeFirst
We are creating our own database in C#. We will do everything manually ourselves. The classes we create will represent our tables. We will give the relations of these tables with each other under Mapping. Then we will create a class that represents the database and convert these classes into tables here.

-In order to do this, it must be in our entityframework project. In this way, we can convert classes into tables on the database with ORM.

-After preparing everything, the last steps required to create the database are as follows;

Tools => Nuget Package Manager => Package Manager Console </br> </br>
After you open the console, type "enable-migrations" here. </br> </br>
Finally type "update-database".
