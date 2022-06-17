WITH GenderRank AS (
	SELECT *, 
	CASE
		WHEN gender = 'female' THEN 1
		WHEN gender = 'other' THEN 2
		ELSE 3
	END AS gender_rank,
	RANK() OVER(PARTITION BY gender ORDER BY user_id) AS id_rank 
	FROM Genders
)

SELECT user_id, gender
FROM GenderRank
ORDER BY id_rank, gender_rank