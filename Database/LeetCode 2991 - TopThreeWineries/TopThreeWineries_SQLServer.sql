WITH WineryRank AS (
	SELECT country, winery, points, RANK() OVER(PARTITION BY country ORDER BY points DESC, winery) AS winery_rank
	FROM (
		SELECT country, winery, SUM(points) AS points
		FROM Wineries GROUP BY country, winery
	) AS t
)

SELECT 
	w1.country, 
	w1.winery + ' (' + CONVERT(VARCHAR, w1.points) + ')' AS top_winery, 
	ISNULL(w2.winery + ' (' + CONVERT(VARCHAR, w2.points) + ')', 'No second winery') AS second_winery,
	ISNULL(w3.winery + ' (' + CONVERT(VARCHAR, w3.points) + ')', 'No third winery') AS third_winery
FROM WineryRank w1
LEFT JOIN WineryRank w2 ON w1.country = w2.country AND w1.winery_rank + 1 = w2.winery_rank
LEFT JOIN WineryRank w3 ON w2.country = w3.country AND w2.winery_rank + 1 = w3.winery_rank
WHERE w1.winery_rank = 1
ORDER BY country