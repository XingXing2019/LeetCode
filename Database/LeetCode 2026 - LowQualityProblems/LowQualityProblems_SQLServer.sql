SELECT problem_id
FROM problems
WHERE CONVERT(FLOAT, likes) / (likes + dislikes) < 0.6
ORDER BY problem_id