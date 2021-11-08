select account_id, day, sum(
	case type
	when 'Deposit' then amount
	else -amount end
) over (partition by account_id order by day) as balance
from transactions
order by account_id, day