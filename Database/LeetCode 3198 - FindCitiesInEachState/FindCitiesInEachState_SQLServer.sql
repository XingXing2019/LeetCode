SELECT state, STRING_AGG(city, ', ') WITHIN GROUP(ORDER BY city) AS cities
FROM Cities
GROUP BY state
ORDER BY state