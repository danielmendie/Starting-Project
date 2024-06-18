CREATE PROCEDURE [dbo].[Question_Update]
(
	@Id int,
	@Question nvarchar(max),
	@Data nvarchar(max),
	@Status int,
	@ModifiedBy nvarchar(255)
)
WITH ENCRYPTION
AS
SET NOCOUNT ON
/* Declare local variables */
DECLARE
	@error int

/* Beginning of procedure */
BEGIN TRANSACTION

UPDATE Question SET
	Data = @Data,
	Question = @Question,
	Status = @Status,
	ModifiedOn = GETUTCDATE(),
	ModifiedBy = @ModifiedBy
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
