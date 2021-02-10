select country from(
select co.name as country, duration from Calls c, Person p, Country co
where c.caller_id = p.id and substring(p.phone_number,1,3) = co.country_code
union all
select co.name as country, duration from Calls c, Person p, Country co
where c.callee_id = p.id and substring(p.phone_number,1,3) = co.country_code
) a group by a.country having sum(duration)/count(*) > (

select sum(duration)/count(*) from(
select co.name as country, duration from Calls c, Person p, Country co
where c.caller_id = p.id and substring(p.phone_number,1,3) = co.country_code
union all
select co.name as country, duration from Calls c, Person p, Country co
where c.callee_id = p.id and substring(p.phone_number,1,3) = co.country_code
) a)