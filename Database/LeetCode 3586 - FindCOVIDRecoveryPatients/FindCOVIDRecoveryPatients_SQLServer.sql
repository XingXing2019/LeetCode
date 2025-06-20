WITH first_positive AS (
	SELECT patient_id, MIN(test_date) AS test_date FROM covid_tests
	WHERE result = 'Positive'
	GROUP BY patient_id
),

first_negative AS (
	SELECT c.patient_id, MIN(c.test_date) AS test_date 
	FROM covid_tests c
	JOIN first_positive f ON f.patient_id = c.patient_id
	WHERE result = 'Negative'
	AND f.test_date < c.test_date
	GROUP BY c.patient_id
)

SELECT p.patient_id, patient_name, age, recovery_time 
FROM (
	SELECT f1.patient_id, DATEDIFF(DAY, f1.test_date, f2.test_date) AS recovery_time
	FROM first_positive f1
	JOIN first_negative f2 ON f2.patient_id = f1.patient_id
	AND f1.test_date < f2.test_date
) AS t
JOIN patients p ON p.patient_id = t.patient_id
ORDER BY recovery_time, patient_name