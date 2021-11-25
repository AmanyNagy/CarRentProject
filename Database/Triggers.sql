
-- Trigger to Update History after each order 

CREATE TRIGGER Tr_UpdateHistory
ON Orders
AFTER INSERT
AS
BEGIN

DECLARE @FromDate DATE
DECLARE @ToDate DATE
DECLARE @CarId INT
DECLARE @Kilo int
Select @FromDate = FromDate , @ToDate =ToDate , @CarId  = CarId  from inserted
SELECT @Kilo = DistanceTraveledInKilo from History WHERE CarUniqeId = @CarId
if @Kilo IS NULL
   set @Kilo = 0
INSERT INTO History (StartDate,FinshDate,CarUniqeId, DistanceTraveledInKilo)
VALUES (@FromDate , @ToDate ,@CarId , @Kilo+100)

END

-- Trigger to Update Availability on invetory table after each order 

CREATE TRIGGER Tr_UpdateAvailability
ON Orders
AFTER  INSERT
AS
BEGIN
  DECLARE @CarId int
  DECLARE @ToDate DATE
  Select @CarId = CarId , @ToDate =ToDate
  from inserted
  UPDATE Inventory  
  SET Availability = 0 , Inventory.AvalibleDate =@ToDate
  where @CarId= Inventory.CarId
END