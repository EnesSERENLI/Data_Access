# CodeFirst
We are creating our own database in C#. We will do everything manually ourselves. The classes we create will represent our tables. We will give the relations of these tables with each other under Mapping. Then we will create a class that represents the database and convert these classes into tables here.

-In order to do this, it must be in our entityframework project. In this way, we can convert classes into tables on the database with ORM.

-After preparing everything, the last steps required to create the database are as follows;

Tools => Nuget Package Manager => Package Manager Console </br> </br>
After you open the console, type "enable-migrations" here. </br> </br>
Finally type "update-database".

## OnModelCreating Method

We can make the arrangements in the database in the onmodelcreating method.

## Seed Method

If there is fake data that we want to add while creating the database, we can do this in the seed method.

## Lazy Loading

Lazy loading moves the data to the heap part of the RAM. According to the need, the data is pulled from there. Entities related to each other with Lazy loading are drawn as needed. This may benefit us in terms of performance according to the case we are in.
