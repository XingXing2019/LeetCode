WITH PeakCalls AS (
	SELECT city, DATEPART(HOUR, call_time) AS peak_calling_hour, COUNT(*) AS number_of_calls 
	FROM Calls GROUP BY city, DATEPART(HOUR, call_time)
) 

SELECT city, peak_calling_hour, number_of_calls FROM (
	SELECT city, peak_calling_hour, number_of_calls, RANK() OVER(PARTITION BY city ORDER BY number_of_calls DESC) AS call_rank
	FROM PeakCalls
) AS t
WHERE call_rank = 1
ORDER BY peak_calling_hour desc, city desc