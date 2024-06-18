CREATE PROCEDURE [dbo].[QuestionType_GetByType]
(
	@Type nvarchar(50)
)
WITH ENCRYPTION
AS
SET NOCOUNT ON
/* Declare local variables */
DECLARE
	@error int

/* Beginning of procedure */


SELECT

	p.Id,
	p.Type,
	p.Data,
	p.Status,
	p.CreatedOn,
	p.CreatedBy,
	p.ModifiedOn,
	p.ModifiedBy
FROM 
	QuestionType p
WHERE 
    p.Type = @Type

/* error-handling */
SELECT @error = @@error 
IF (@error <> 0) GOTO ERROR


RETURN 0

/* error-handling */
ERROR:
	RETURN @error

/* End of procedure*/