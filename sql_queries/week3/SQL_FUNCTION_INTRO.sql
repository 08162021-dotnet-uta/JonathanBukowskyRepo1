
CREATE FUNCTION GetMaxValue(@num1 INT, @num2 INT)
RETURNS INT
AS
BEGIN
	RETURN (SELECT Max(v) FROM (VALUES (@num1), (@num2)) as value(v));
END;

go

SELECT dbo.GetMaxValue(12, 100);

go

CREATE FUNCTION AllOrders()
RETURNS TABLE
AS
	RETURN (Select * FROM Store."Order");

go

CREATE FUNCTION AllOrdersBefore(@max DATETIME)
RETURNS TABLE
AS
	RETURN (SELECT * FROM Store."Order" WHERE Store."Order".OrderDate < @max);

GO

SELECT * FROM dbo.AllOrders() as AllTheOrders;
SELECT * FROM dbo.AllOrdersBefore(DATETIMEFROMPARTS(2021, 08, 30, 21, 26, 42, 0));

DROP FUNCTION dbo.GetMaxValue;
DROP FUNCTION dbo.AllOrders;
DROP FUNCTION dbo.AllOrdersBefore;