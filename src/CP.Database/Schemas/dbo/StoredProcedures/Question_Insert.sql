CREATE PROCEDURE [dbo].[Question_Insert]
(
	@Question nvarchar(MAX),
	@Data nvarchar(MAX),
	@ProgramId int,
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

INSERT INTO Question 
(
	Question,
	Data,
	ProgramId,
	Status,
	CreatedOn,
	CreatedBy,
	ModifiedOn,
	ModifiedBy
)
VALUES
(
	@Question,
	@Data,
	@ProgramId,
	@Status,
	GETUTCDATE(),
	@CreatedBy,
	GETUTCDATE(),
	@CreatedBy
)

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
