SELECT t1.bin AS BIN, COUNT(t2.bin) AS TOTAL
FROM 
(SELECT '[0-5>' AS bin UNION SELECT '[5-10>' AS bin UNION SELECT '[10-15>' AS bin UNION SELECT '15 or more' AS bin) AS t1
LEFT JOIN (
	SELECT case when duration / 60 < 5 then '[0-5>'
	when duration / 60 < 10 then '[5-10>'
   when duration / 60 < 15 then '[10-15>'
   ELSE '15 or more' END AS bin
	FROM sessions 
) AS t2
ON t1.bin = t2.bin
GROUP BY t1.bin;