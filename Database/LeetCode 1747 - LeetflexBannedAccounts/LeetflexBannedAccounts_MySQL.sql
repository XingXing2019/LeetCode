select distinct i1.account_id
from loginfo i1 join loginfo i2 
on i1.login >= i2.login and i1.login <= i2.logout
and i1.ip_address <> i2.ip_address and i1.account_id = i2.account_id
