WITH CandidateSkills AS (
	SELECT * FROM Candidates 
	WHERE skill IN ('Python', 'Tableau', 'PostgreSQL')
)

SELECT candidate_id FROM CandidateSkills
GROUP BY candidate_id
HAVING COUNT(DISTINCT skill) = 3
ORDER BY candidate_id