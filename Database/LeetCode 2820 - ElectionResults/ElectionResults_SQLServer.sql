WITH ValidVotes AS (
	SELECT * FROM Votes WHERE candidate IS NOT NULL
),

Votes AS (
	SELECT candidate, SUM(weight) AS votes
	FROM ValidVotes v
	JOIN (
		SELECT voter, 1 / CONVERT(FLOAT, COUNT(*)) AS Weight
		FROM ValidVotes
		GROUP BY voter
	) AS w
	ON v.voter = w.voter
	GROUP BY candidate
)

SELECT candidate FROM Votes
WHERE votes = (SELECT MAX(votes) FROM Votes)
ORDER BY candidate