CREATE PROCEDURE dbo.Question_GetByProgram
(
	@ProgramId int
)
WITH ENCRYPTION
AS
SET NOCOUNT ON
/* Declare local variables */
DECLARE
	@error int

/* Beginning of procedure */


SELECT
	q.Id,
	q.ProgramId,
	q.Question,
	q.Data,
	q.Status,
	q.CreatedBy,
	q.CreatedOn,
	q.ModifiedBy,
	q.ModifiedOn
FROM 
	Question q
WHERE
	q.ProgramId = @ProgramId AND
	Status > 0


/* error-handling */
SELECT @error = @@error 
IF (@error <> 0) GOTO ERROR


RETURN 0

/* error-handling */
ERROR:
	RETURN @error

/* End of procedure*/
