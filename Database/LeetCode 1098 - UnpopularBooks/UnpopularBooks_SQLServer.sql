select book_id, name 
from books where available_from < DATEADD(month, -1, '2019-06-22') and book_id not in
(select book_id
from orders where dispatch_date > DATEADD(year, -1, '2019-06-22')
group by book_id
having sum(quantity) >= 10)