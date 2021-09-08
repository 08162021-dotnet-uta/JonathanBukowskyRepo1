
-- DDL = data definition language
use master; -- this is the place to make new dbs
go

DROP DATABASE IF EXISTS StoreApplicationDB;
go
-- CREATE
CREATE DATABASE StoreApplicationDB;
go

use StoreApplicationDB;
go

DROP SCHEMA IF EXISTS Store;
go

create schema Store;
go

DROP SCHEMA IF EXISTS Customer;
go

create schema Customer;
go

-- Unbuild ?

DROP TABLE IF EXISTS Store.OrderProduct;
DROP TABLE IF EXISTS Store."Order";
DROP TABLE IF EXISTS Store.Product;
DROP TABLE IF EXISTS Store.Store;
DROP TABLE IF EXISTS Customer.Customer;

-- One shot creation, just for fun
/*
create table Customer.Customer
(
	-- tinyint, smallint, int, bigint, money, decimal, numerical
	CustomerID INTEGER NOT NULL CONSTRAINT PK_Customer PRIMARY KEY,
	-- char, nchar, varchar, nvarchar
	Name NVARCHAR(20) NOT NULL
	,Active BIT NOT NULL CONSTRAINT DF_Customer_Active DEFAULT 1
);

create table Store.Store
(
	StoreID INTEGER NOT NULL CONSTRAINT PK_Store PRIMARY KEY,
	Name NVARCHAR(20) NOT NULL
	,Active BIT NOT NULL CONSTRAINT DF_Store_Active DEFAULT 1
);

create table Store.Product
(
	ProductID INTEGER NOT NULL CONSTRAINT PK_Product PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL
	,Active BIT NOT NULL CONSTRAINT DF_Product_Active DEFAULT 1
);

create table Store."Order"
(
	OrderID INTEGER NOT NULL CONSTRAINT PK_Order PRIMARY KEY,
	CustomerID INTEGER NOT NULL CONSTRAINT FK_Order_Customer FOREIGN KEY REFERENCES Customer.Customer,
	StoreID INTEGER NOT NULL CONSTRAINT FK_Order_Store FOREIGN KEY REFERENCES Store.Store
	,Active BIT NOT NULL CONSTRAINT DF_Order_Active DEFAULT 1
);

create table Store.OrderProduct
(
	-- fred likes to put commas at the beginning of the next line. It's kinda neat. I think I'll start doing this.
	OrderProductID INTEGER NOT NULL CONSTRAINT PK_OrderProduct PRIMARY KEY
	,OrderID INTEGER NOT NULL CONSTRAINT FK_OrderProduct_Order FOREIGN KEY REFERENCES Store."Order"
	,ProductID INTEGER NOT NULL CONSTRAINT FK_OrderProduct_Product FOREIGN KEY REFERENCES Store.Product
	,Quantity INTEGER NOT NULL CONSTRAINT DF_OrderProduct_Quantity DEFAULT 1
	,Active BIT NOT NULL CONSTRAINT DF_OrderProduct_Active DEFAULT 1
);
*/

create table Customer.Customer
(
	CustomerID INTEGER NOT NULL IDENTITY(1,1),
	Name NVARCHAR(20) NOT NULL,
	--Active BIT NOT NULL DEFAULT 1 -- I'm going to set the default in an alter command below to give example of that
	Active BIT NOT NULL
);

create table Store.Store
(
	StoreID INTEGER NOT NULL IDENTITY(1,1),
	Name NVARCHAR(20) NOT NULL,
	Active BIT NOT NULL CONSTRAINT DF_Store_Active DEFAULT 1
);

create table Store.Product
(
	ProductID INTEGER NOT NULL IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	Price MONEY NOT NULL,
	Active BIT NOT NULL CONSTRAINT DF_Product_Active DEFAULT 1
);

create table Store."Order"
(
	OrderID INTEGER NOT NULL IDENTITY(1,1),
	CustomerID INTEGER NOT NULL,
	StoreID INTEGER NOT NULL,
	OrderDate DATETIME2(7) NOT NULL,
	Active BIT NOT NULL CONSTRAINT DF_Order_Active DEFAULT 1 -- Fred added this, and I don't know what it's for yet -- it's for monitoring what is active data and what is old (archived) data
);

create table Store.OrderProduct
(
	-- fred likes to put commas at the beginning of the next line. It's kinda neat.
	OrderProductID INTEGER NOT NULL IDENTITY(1,1)
	,OrderID INTEGER NOT NULL
	,ProductID INTEGER NOT NULL
	,Quantity INTEGER NOT NULL DEFAULT 1
	,Active BIT NOT NULL CONSTRAINT DF_OrderProduct_Active DEFAULT 1
);

-- ALTER

-- NOTE: I put these in above, but fred did the pkey constraints here (mine won't have an explicit name?)
ALTER TABLE Customer.Customer
	ADD CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerID);

ALTER TABLE Customer.Customer
	ADD CONSTRAINT DF_Customer_Active DEFAULT 1 FOR Active;
	
ALTER TABLE Store.Store
	ADD CONSTRAINT PK_StoreID PRIMARY KEY (StoreID);
	
ALTER TABLE Store.Product
	ADD CONSTRAINT PK_ProductID PRIMARY KEY (ProductID);

ALTER TABLE Store."Order"
	ADD CONSTRAINT PK_OrderID PRIMARY KEY (OrderID);

-- CHECK CONSTRAINT to make sure order date is not in the future
ALTER TABLE Store."Order"
	ADD CONSTRAINT CK_Order CHECK (OrderDate <= GETDATE());

ALTER TABLE Store.OrderProduct
	ADD CONSTRAINT PK_OrderProduct PRIMARY KEY (OrderProductID);


ALTER TABLE Store."Order"
	ADD CONSTRAINT FK_Order_Customer FOREIGN KEY (CustomerID) REFERENCES Customer.Customer;
ALTER TABLE Store."Order"
	ADD CONSTRAINT FK_Order_Store FOREIGN KEY (StoreID) REFERENCES Store.Store;

ALTER TABLE Store.OrderProduct
	ADD CONSTRAINT FK_OrderProduct_Product FOREIGN KEY (ProductID) REFERENCES Store.Product;
ALTER TABLE Store.OrderProduct
	ADD CONSTRAINT FK_OrderProduct_Order FOREIGN KEY (OrderID) REFERENCES Store."Order";

go

/*
-- EXAMPLES:
-- DROP

DROP DATABASE StoreApplicationDB;
DROP SCHEMA Customer;
DROP TABLE Customer.Customer;

-- TRUNCATE
TRUNCATE TABLE Customer.Customer
*/

-- STORED PROCEDURE
CREATE PROCEDURE SP_AddCustomer(@name nvarchar(100))
AS
BEGIN
	DECLARE @result nvarchar(100);

	SELECT @result = [Name]
	FROM Customer.Customer
	WHERE Name = @name;
	IF (@result IS NULL)
	BEGIN
		INSERT INTO Customer.Customer([Name])
		VALUES (@name)
	END
END
go

EXECUTE dbo.SP_AddCustomer 'fred';

SELECT * FROM Customer.Customer;