WITH Domains AS (
	SELECT SUBSTRING(email, CHARINDEX('@', email) + 1, LEN(email)) as email_domain
	FROM Emails
	WHERE RIGHT(email, 3) = 'com'
)

SELECT email_domain, COUNT(*) AS count FROM Domains
GROUP BY email_domain
ORDER BY email_domain