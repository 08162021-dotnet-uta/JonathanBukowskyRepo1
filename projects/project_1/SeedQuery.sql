/*
create table Customer.Customer
(
	CustomerID INTEGER NOT NULL IDENTITY(1,1) CONSTRAINT PK_Customer PRIMARY KEY (CustomerID),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	DefaultStore INTEGER,
	--Active BIT NOT NULL DEFAULT 1 -- I'm going to set the default in an alter command below to give example of that
	Active BIT NOT NULL CONSTRAINT DF_Customer_Active DEFAULT 1
);
*/

use StoreApplicationDB2;
go

INSERT INTO Customer.Customer (FirstName, LastName, DefaultStore)
VALUES ('Johnny', 'Bravo', NULL),
	('Bob', 'Dylan', NULL),
	('Freddie', 'Mercury', NULL);
go