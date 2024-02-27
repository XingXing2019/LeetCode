select email_domain, count(*) as count from (
	select substring(email, position('@' in email) + 1, length(email)) as email_domain
	from Emails
	where right(email, 3) = 'com'
) as t
group by email_domain
order by email_domain