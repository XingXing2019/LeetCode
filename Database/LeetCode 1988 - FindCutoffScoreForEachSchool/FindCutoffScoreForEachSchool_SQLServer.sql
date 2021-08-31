WITH scores AS (
	SELECT * 
	FROM schools s JOIN Exam e 
	ON s.capacity >= e.student_count
),

Rank AS (
	SELECT school_id, score, 
	RANK() OVER(PARTITION BY school_id ORDER BY student_count DESC, score) AS rank 
	FROM scores
)

SELECT s.school_id, IIF(rank IS NULL, -1, score) AS score 
FROM schools s LEFT JOIN Rank r
ON s.school_id = r.school_id
WHERE rank = 1 OR rank IS NULL