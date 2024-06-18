CREATE PROCEDURE [dbo].[Program_Update]
(
	@Id int,
	@Title nvarchar(MAX),
	@Description nvarchar(MAX),
	@Status int,
	@ModifiedBy nvarchar(255)
)
WITH ENCRYPTION
AS
SET NOCOUNT ON
/* Declare local variables */
DECLARE
	@error int


BEGIN TRANSACTION

UPDATE Program SET
	Title = @Title,
	Description = @Description,
	Status = @Status,
	ModifiedOn = GETUTCDATE(),
	ModifiedBy = @ModifiedBy
WHERE 
	Id = @Id;

/* error-handling */
SELECT @error = @@error
IF (@error <> 0) GOTO ERROR

COMMIT TRANSACTION
RETURN 0

/* error-handling */
ERROR:
	IF (@@trancount > 0) ROLLBACK TRANSACTION
	RETURN @error

/* End of procedure*/

