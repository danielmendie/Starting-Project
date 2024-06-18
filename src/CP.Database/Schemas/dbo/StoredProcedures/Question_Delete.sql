CREATE PROCEDURE dbo.Question_Delete
(
	@Id int
)
WITH ENCRYPTION
AS
SET NOCOUNT ON
/* Declare local variables */
DECLARE
	@error int

/* Beginning of procedure */
BEGIN TRANSACTION

DELETE Question
WHERE
	Id = @Id

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
