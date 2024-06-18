CREATE PROCEDURE [dbo].[Profile_Insert]
(
	@Id int OUTPUT,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Gender nvarchar(10),
	@Email nvarchar(100),
	@Phone nvarchar(100),
	@Nationality nvarchar(100),
	@Address nvarchar(MAX),
	@DateOfBirth datetime,
	@Data nvarchar(MAX),
	@CreatedBy nvarchar(255)
)
WITH ENCRYPTION
AS
SET NOCOUNT ON
/* Declare local variables */
DECLARE
	@error int,
	@Status int = 1 --active


BEGIN TRANSACTION

INSERT INTO Profile 
(
	FirstName,
	LastName,
	Email,
	Address,
	Nationality,
	Phone,
	Gender,
	Data,
	DateOfBirth,
	Status,
	CreatedOn,
	CreatedBy,
	ModifiedOn,
	ModifiedBy
)
VALUES
(
	@FirstName,
	@LastName,
	@Email,
	@Address,
	@Nationality,
	@Phone,
	@Gender,
	@Data,
	@DateOfBirth,
	@Status,
	GETUTCDATE(),
	@CreatedBy,
	GETUTCDATE(),
	@CreatedBy
)

/* error-handling */
SELECT @error = @@error, @Id = @@IDENTITY
IF (@error <> 0) GOTO ERROR

COMMIT TRANSACTION
RETURN 0

/* error-handling */
ERROR:
	IF (@@trancount > 0) ROLLBACK TRANSACTION
	RETURN @error

/* End of procedure*/
