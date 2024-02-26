with FraudRank as (
	select *, rank() over(partition by state order by fraud_score desc) as fraud_rank from Fraud
),

StateCount as (
	select state, if(count(*) * 0.05 < 1, 1, count(*) * 0.05) as state_count from Fraud group by state
)

select policy_id, f.state, fraud_score
from FraudRank f
join StateCount c on f.state = c.state
where fraud_rank <= state_count
order by f.state, fraud_score desc, policy_id
