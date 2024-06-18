CREATE PROCEDURE [dbo].[Program_Insert]
(
	@Id int OUTPUT,
	@Title nvarchar(MAX),
	@Description nvarchar(MAX),
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

INSERT INTO Program 
(
	Title,
	Description,
	Status,
	CreatedOn,
	CreatedBy,
	ModifiedOn,
	ModifiedBy
)
VALUES
(
	@Title,
	@Description,
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

