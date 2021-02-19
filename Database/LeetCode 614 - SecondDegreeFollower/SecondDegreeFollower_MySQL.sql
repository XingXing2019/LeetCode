select followee as follower, count(distinct follower) as num from follow group by followee
having follower in (select distinct follower from follow)
order by follower