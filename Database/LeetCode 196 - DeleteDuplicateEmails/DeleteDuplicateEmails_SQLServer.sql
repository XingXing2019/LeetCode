delete from person where id not in (select min(id) from person group by email);
