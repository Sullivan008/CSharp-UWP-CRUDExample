# C# - CRUD Operations in UWP with WCF Web Service [Year of Development: 2017 and 2020]

About the application technologies and operation:

### Technologies:
- Programming Language: C#
- FrontEnd Side: Universal Windows (Target Framework: Windows 10, version 1809 (10.0; Build 17763)) - .NET Core 2.1
- BackEnd Side: Windows Communication Foundation (WCF) - .NET Framework 4.7.2
- Database: SQL Server (Native SQL)
- Other used modul: System.Data.SqlClient (.NET Data Provider for SQL Server)

### Application solution structure:
- **CRUDOperationsClient**: Includes the FrontEnd Side of the application.
- **CRUDOperationsServer**: Includes the BackEnd Side of the application.
- **CRUDOperationsCommon**: Includes the Common Classes, Interfaces, Modules, etc. for the **CRUDOperationsClient** and **CRUDOperationsServer**

### Installation/ Configuration:

1. Restore necessary Packages on the selected project, run the following command in **PM Console**

   ```
   Update-Package -reinstall
   ```
   
2. Connect to **MSSQLLocalDb Instance** with **Windows Authentication**

   ```
   (LocalDB)\MSSQLLocalDb
   ```
   
3. **CREATE** necessary **DATABASE** with the following **SCRIPT**

   ```SQL
   CREATE DATABASE ServiceDB;
   ```
   
5. **CREATE** necessary **TABLES** with the following **SCRIPT** (The scripts can be found in the following folder: **DB TABLES**)

   ```SQL
   USE ServiceDB;

   CREATE TABLE [dbo].[Employee] (
    [ID]    INT             IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (255)   NULL,
    [Age]   INT             NOT NULL,
    [Email] VARCHAR (255)   NOT NULL
    PRIMARY KEY CLUSTERED ([ID] ASC));
  
### About the application:

In this application, you will learn how to create a **WCF Web Service** with a BackEnd **SQL Server Database** that performs database operations, and connect a **Universal Windows Application** to the Web Service as **Service Reference** and perform **CRUD** operations with Windows Application (**Create**, **Read**, **Update** and **Delete**).

#### The application shows the following:
- How to implement **Data Binding** in **UWP**.
- How to use **Modal-View-ViewModel (MVVM)** in **UWP**.
- How to implement **INotifyPropertyChanged** in **UWP**.
- How to implement **Command Binding** in **UWP** with **ICommand** interface.
- How to implement **Value Converters** in **UWP** with **IValueConverter** interface (**NullConverter**).
- How to implement **log4net Package** in **WCF**.
- How to create separate **WCF services**.
- How to implement **Native SQL CRUD Operations** with **System.Data.SqlClient** **(.NET Data Provider for SQL Server)**.
- How to implement **WCF Web Service** in a **Universal Windows Application** as **Service Reference**.
- How to implement **IDisposable Interface** in a **Service Reference**.
