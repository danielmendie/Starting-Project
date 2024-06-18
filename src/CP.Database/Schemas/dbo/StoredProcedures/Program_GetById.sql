CREATE PROCEDURE [dbo].[Program_GetById]
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
	q.Title,
	q.Description,
	q.Status,
	q.CreatedBy,
	q.CreatedOn,
	q.ModifiedBy,
	q.ModifiedOn
FROM 
	Program q
WHERE
	q.Id = @ProgramId AND
	Status > 0


/* error-handling */
SELECT @error = @@error 
IF (@error <> 0) GOTO ERROR


RETURN 0

/* error-handling */
ERROR:
	RETURN @error

/* End of procedure*/
