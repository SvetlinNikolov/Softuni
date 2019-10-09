--11
CREATE FUNCTION ufn_CalculateFutureValue (@Sum MONEY, @Rate FLOAT , @Years INT)
RETURNS MONEY AS
BEGIN
 RETURN @Sum * POWER(1+@Rate,@Years)
END

--12
GO
CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @rate DECIMAL (15, 4))
AS 
BEGIN
	SELECT a.Id AS [Account Id], ah.FirstName AS [First Name],
	ah.LastName AS [Last Name],
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @rate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a
	ON ah.Id = a.Id
	WHERE ah.Id = @accountId
END
