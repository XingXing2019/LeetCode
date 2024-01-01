select distinct l1.user_id
from Loans l1
join Loans l2 on l1.user_id = l2.user_id
where l1.loan_type = 'Mortgage' and l2.loan_type = 'Refinance'
order by l1.user_id