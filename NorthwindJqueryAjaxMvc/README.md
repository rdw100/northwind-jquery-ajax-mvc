# NorthwindJqueryAjaxMvc
This JQuery AJAX MVC demonstration project was created using Visual Studio 2019 16.6.5, .NET Core 3.3.302, EF Core 3.1.6, Bootstrap 4.3.1, jQuery JavaScript Library 3.5.1, & SQL Server 13.0.4001.  The objective is to demonstrate CRUD operations with a modal popup dialog using the Northwind database.

## Setup
Instructions to setup this demo are as follows:
1. Open Project
   Download NorthwindJqueryAjaxMvc project and open it in Visual Studio 2019.

2. Create Database
   Follow run and execute Northwind script instructions from the [NorthWind-Pubs Repo](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs).  This project created a Northwind database in the default local database server instance mssqllocaldb.

3. Verify Connection 
   Verify the connection string in AppSettings.json in Visual Studio and make sure that it is pointing to your local database server.  For example, this project uses the following: 

     ``` "ConnectionStrings": {
    "DevConnection": "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true"
    } ```

** Demonstration **
Create, Read, Update, and Delete operations are performed in the animated GIF below:
![Recordit GIF](https://github.com/rdw100/NorthwindJqueryAjaxMvc/blob/master/NorthwindJqueryAjaxMvc/img/KuFnlNRSM3.gif?raw=true)