CREATE PROCEDURE [dbo].[GetAllCustomer_1.0.0]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT CustomerId, Email, Phone, Address
	FROM dbo.Customer WITH(NOLOCK)
	
END
