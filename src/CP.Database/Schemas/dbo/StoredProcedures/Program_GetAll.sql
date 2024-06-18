CREATE PROCEDURE [dbo].[Program_GetAll]

WITH ENCRYPTION
AS
SET NOCOUNT ON
/* Declare local variables */
DECLARE
	@error int

/* Beginning of procedure */


SELECT
	p.Id,
	p.Title,
	p.Description,
	p.Status,
	p.CreatedOn,
	p.CreatedBy,
	p.ModifiedOn,
	p.ModifiedBy
FROM 
	Program p
ORDER BY
    p.Title

/* error-handling */
SELECT @error = @@error 
IF (@error <> 0) GOTO ERROR


RETURN 0

/* error-handling */
ERROR:
	RETURN @error

/* End of procedure*/
