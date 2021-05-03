# rs-backend
## Requirements
* NetCore 3.1 SDK installed in the computer running the service.
* The database connection in `appsettings.json` has to be valid.
* The following script can be used to create the single table where the service is going to operate:
````
CREATE TABLE dbo.Properties (
    Id int NOT NULL,
    Address1 varchar(100) NULL,
    Address2 varchar(100) NULL,
    City varchar(50) NULL,
    State varchar(25) NULL,
    Zip varchar(5) null,
    ZipPlus4 varchar(4) null,
    YearBuilt int null,
    ListPrice decimal(19,4) null,
    MonthlyRent decimal(19,4) null
);
GO

ALTER TABLE dbo.Properties ADD CONSTRAINT PK_Properties PRIMARY KEY (Id);
GO
````
* After cloning this repository, just open the solution in Visual Studio and run it.

## Notes
* The service is configured to run locally in `http://localhost:9001`this can be changed in `appsettings.json` file.