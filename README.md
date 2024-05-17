# Set up step for TechnicalTestOf2C2P
## Installation
1. install the dotnet-ef tool globally if you haven't already:
```
dotnet tool install --global dotnet-ef
```
2. Run script sql for create database:
	- Script/01_CreateDatabase.sql
3. Then, create a migration and update the database:
```
cd TechnicalTestOf2C2P 
dotnet ef migrations add InitialCreateTable
dotnet ef database update
```
4. Run script sql for insert master data:
	- Script/02_InsertStatusMaster.sql

## Usage
Possible formats of input files: csv and xml. The template include in path:
- Data/data_test_csv.csv
- Data/data_test_xml.xml
