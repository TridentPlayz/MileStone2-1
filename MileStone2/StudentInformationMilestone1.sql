CREATE DATABASE StudentInfo
ON PRIMARY 
(NAME=StudentDataFile1,
FILENAME='C:\SQLData\StudentDataFile1.mdf',
SIZE=10MB,
MAXSIZE=10GB,
FILEGROWTH=1MB
)
LOG ON 
(NAME=StudentLogFile1,
FILENAME='C:\SQLData\StudentLogFile1.ldf',
SIZE=10MB,
MAXSIZE=10GB,
FILEGROWTH=1MB
);

GO

USE StudentInfo

GO

CREATE TABLE StudentInformation(
"StudentNumber" "int" IDENTITY (1, 1) NOT NULL PRIMARY KEY,
"StudentName" nvarchar (20) NOT NULL ,
"StudentSurname" nvarchar (10) NOT NULL ,
"StudentImage" "image" NULL ,
"DateOfBirth" "datetime" NULL ,
"Gender" nvarchar (10) NOT NULL ,
"Phone" nvarchar (24) NULL ,
"Address" nvarchar (24) NULL ,
"ModuleCode" "int" NULL FOREIGN KEY REFERENCES  ModuleInformation(ModuleCode),
)

CREATE TABLE ModuleInformation(
"ModuleCode" "int" IDENTITY (1, 1) NOT NULL PRIMARY KEY,
"ModuleName" nvarchar (20) NOT NULL ,
"ModuleDescription" nvarchar (40) NOT NULL ,
"LinksForResources" nvarchar (40) NOT NULL ,
)