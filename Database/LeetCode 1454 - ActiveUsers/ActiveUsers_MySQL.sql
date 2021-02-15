select a.id, a.name from (
select distinct l1.id from 
logins l1 left join logins l2 on l1.id = l2.id
left join logins l3 on l1.id = l3.id
left join logins l4 on l1.id = l4.id
left join logins l5 on l1.id = l5.id
where datediff(l1.login_date, l2.login_date) = 1
and datediff(l2.login_date, l3.login_date) = 1
and datediff(l3.login_date, l4.login_date) = 1
and datediff(l4.login_date, l5.login_date) = 1) as t
left join accounts a on t.id = a.id
order by a.id