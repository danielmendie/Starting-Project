CREATE PROCEDURE [dbo].[Profile_GetById]
(
	@ProfileId int
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
	q.FirstName,
	q.LastName,
	q.Gender,
	q.Address,
	q.Email,
	q.Nationality,
	q.Phone,
	q.DateOfBirth,
	q.Data,
	q.Status,
	q.CreatedBy,
	q.CreatedOn,
	q.ModifiedBy,
	q.ModifiedOn
FROM 
	Profile q
WHERE
	q.Id = @ProfileId AND
	Status > 0


/* error-handling */
SELECT @error = @@error 
IF (@error <> 0) GOTO ERROR


RETURN 0

/* error-handling */
ERROR:
	RETURN @error

/* End of procedure*/
