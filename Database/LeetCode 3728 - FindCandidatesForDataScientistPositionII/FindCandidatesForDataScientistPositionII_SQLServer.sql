WITH ProjectCandidates AS (
	SELECT t1.project_Id, t1.candidate_id FROM (
		SELECT p.project_id, c.candidate_id, COUNT(c.skill) AS skill_count
		FROM Projects p
		JOIN Candidates c ON p.skill = c.skill
		GROUP BY p.project_id, c.candidate_id
	) AS t1
	LEFT JOIN (
		SELECT project_id, COUNT(skill) AS skill_count FROM Projects
		GROUP BY project_id
	) AS t2
	ON t1.project_id = t2.project_id AND t1.skill_count = t2.skill_count
	WHERE t2.skill_count IS NOT NULL
),

CandidateScore AS (
	SELECT project_id, candidate_id, SUM(score) + 100 AS score FROM (
		SELECT 
			p.project_id, 
			c.candidate_id,
			CASE
				WHEN c.proficiency > p.importance THEN 10
				WHEN c.proficiency < p.importance THEN -5
				ELSE 0
			END AS score
		FROM Projects p
		JOIN Candidates c ON p.skill = c.skill
		JOIN ProjectCandidates pc ON p.project_id = pc.project_id AND c.candidate_id = pc.candidate_id
	) AS t
	GROUP BY project_id, candidate_id
)

SELECT project_id, candidate_id, score FROM (
	SELECT *, RANK() OVER(PARTITION BY project_id ORDER BY score DESC, candidate_id) AS rank
	FROM CandidateScore
) AS t
WHERE rank = 1
ORDER BY project_id