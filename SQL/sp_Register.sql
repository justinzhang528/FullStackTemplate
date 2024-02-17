CREATE PROCEDURE [dbo].[Register_1.0.0]
	@email nvarchar(50),
	@password nvarchar(50),
	@phone varchar(20),
	@address nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @errorCode int;
	DECLARE @errorMessage nvarchar(50);

	IF EXISTS (SELECT TOP 1 1 FROM dbo.Customer WHERE Email = @email)
	BEGIN 
		SET @errorCode = -1
		SET @errorMessage = 'User Already Exist'
	END
	ELSE 
	BEGIN 
		BEGIN TRY
			BEGIN TRANSACTION;
		
			INSERT INTO dbo.Customer
			VALUES (@email, @password, @phone, @address)
		
			COMMIT TRANSACTION
			SET @errorCode = 0
			SET @errorMessage = 'Success'
		END TRY
		
		BEGIN CATCH
			SET @errorCode = -2
			SET @errorMessage = 'Add New User Failed'
			ROLLBACK TRANSACTION
		END CATCH
	END
	
	SELECT
		@errorCode as ErrorCode,
		@errorMessage as ErrorMessage
	
END
