SELECT candidate_id
FROM (
	SELECT * FROM Candidates 
	WHERE years_of_exp >= 2
) AS c
JOIN Rounds r
ON c.interview_id = r.interview_id
GROUP BY candidate_id
HAVING SUM(score) >= 16
