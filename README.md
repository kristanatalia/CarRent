# DDTECH Car Rental Application

**author: Krista Natalia**

Minimum requirement to run this application are as follow:

* Visual Studio 2017
* Microsoft SQL Server 2012
* Browser (Chrome / Firefox)

#### Database

Execute DB.sql in Microsoft SQL Server Management Studio.
This action will create a new CarRent database.


#### Config

Change ConnectionString in CarRent/Web.Config and CarRent.UnitTest/App.Config to match Database login configuration.
```
<connectionStrings>
	<add name="ConnStr_CarRental" connectionString="Server=localhost;Database=CarRent;User ID=sa;Password=password123" />
</connectionStrings>
```

