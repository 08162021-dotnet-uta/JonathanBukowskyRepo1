
USE Demo_08162021batch;

INSERT INTO dbo.Products (ProductName, ProductDescription, ProductPrice)
VALUES ('SANGARIA Royal Milk Tea', 'Sangaria royal milk tea made with premium leaf and real milk (Pack of 24)', 42.90);

INSERT INTO dbo.Customers (FirstName, LastName)
VALUES ('Yami', 'Sukehiro');

/*
INSERT INTO dbo.ItemizedOrders (CustomerId, ProductId, OrderDate, totalAmount)
VALUES (0, 0, DATEFROMPARTS(2020, 11, 29), 0.00),
		(0, 0, DATEFROMPARTS(2020, 11, 29), 0.00),
		(0, 0, DATEFROMPARTS(2020, 11, 29), 0.00);
*/

INSERT INTO dbo.ItemizedOrders (OrderID, CustomerID, ProductId, OrderDate, totalAmount)
SELECT
	N"f9b889d7-5912-4b38-8c6a-a46db40d1c14" AS OrderID,
	8 AS CustomerID,
	ProductID,
	DATEFROMPARTS(2020, 11, 29) AS OrderDate,
	(SELECT SUM(ProductPrice) FROM Products WHERE ProductID IN (7,25,20)) AS totalAmount
FROM Products
WHERE ProductID IN (7,25,20);


INSERT INTO dbo.ItemizedOrders (OrderID, CustomerID, ProductId, OrderDate)
SELECT
	N'f9b889d7-5912-4b38-8c6a-a46db40d1c14' AS OrderID,
	8 AS CustomerID,
	ProductID,
	DATEFROMPARTS(2020, 11, 29) AS OrderDate
FROM Products
WHERE ProductID IN (7,25,20);

INSERT INTO ItemizedOrders (OrderID, CustomerID, ProductId, OrderDate)
VALUES
(N'f9b889d7-5912-4b38-8c6a-a46db40d1c14', 8, 7, DATEFROMPARTS(2020, 11, 29)),
(N'f9b889d7-5912-4b38-8c6a-a46db40d1c14', 8, 25, DATEFROMPARTS(2020, 11, 29)),
(N'f9b889d7-5912-4b38-8c6a-a46db40d1c14', 8, 20, DATEFROMPARTS(2020, 11, 29));

SELECT * FROM dbo.Products;
SELECT * FROM dbo.Customers;
SELECT * FROM dbo.ItemizedOrders;

UPDATE Products
SET ProductPrice=