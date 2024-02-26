WITH FraudRank AS (
	SELECT *, RANK() OVER(PARTITION BY state ORDER BY fraud_score DESC) AS rank
	FROM Fraud
),

StateCount AS (
	SELECT state, IIF(COUNT(*) * 0.05 < 1, 1, COUNT(*) * 0.05) AS count
	FROM Fraud
	GROUP BY state
)

SELECT policy_id, f.state, f.fraud_score
FROM FraudRank f
JOIN StateCount s ON f.state = s.state
WHERE f.rank <= s.count
ORDER BY f.state, f.fraud_score DESC, policy_id 