CREATE PROCEDURE [dbo].[Login_1.0.0]
	@email nvarchar(50),
	@password nvarchar(50)
AS
BEGIN
   SET NOCOUNT ON;
	DECLARE @customerId int = 0;
	DECLARE @password_db nvarchar(50);
	DECLARE @errorCode int;
	DECLARE @errorMessage nvarchar(50);

	SELECT @customerId = CustomerId, @password_db = Password
	FROM dbo.Customer WITH(NOLOCK)
	WHERE Email = @email
	
	IF @customerId = 0
	BEGIN
		SET @errorCode = -1
		SET @errorMessage = 'User Not Found'
	END
	ELSE
   BEGIN
		IF @password = @password_db
		BEGIN
			SET @errorCode = 0
			SET @errorMessage = 'Success'
		END
		ELSE
      	BEGIN
			SET @errorCode = -2
			SET @errorMessage = 'Wrong Password'
		END
	END
	
	
	SELECT
		@errorCode as ErrorCode,
		@errorMessage as ErrorMessage
	
END


