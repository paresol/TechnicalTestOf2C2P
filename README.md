# TechnicalTestOf2C2P set up step
1. install the dotnet-ef tool globally if you haven't already:

dotnet tool install --global dotnet-ef

2. Run script sql for create database:

- 01_CreateDatabase.sql

3.Then, create a migration and update the database:

cd TechnicalTestOf2C2P 
dotnet ef migrations add InitialCreateTable
dotnet ef database update

4. Run script sql for insert master data:

- 02_InsertCurrencyMaster.sql
- 03_InsertStatusMaster.sql