WITH FirstScore AS (
	SELECT *, RANK() OVER(PARTITION BY student_id, subject ORDER BY exam_date) AS date_rank
	FROM Scores 
),

LatestScore AS (
	SELECT *, RANK() OVER(PARTITION BY student_id, subject ORDER BY exam_date DESC) AS date_rank
	FROM Scores 
)

SELECT t1.student_id, t1.subject, t1.score AS first_score, t2.score AS latest_score
FROM (
	SELECT *
	FROM FirstScore
	WHERE date_rank = 1
) t1
JOIN (
	SELECT *
	FROM LatestScore
	WHERE date_rank = 1
) t2
ON t1.student_id = t2.student_id
AND t1.subject = t2.subject
WHERE t2.score > t1.score
ORDER BY t1.student_id