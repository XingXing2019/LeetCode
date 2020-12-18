with accepted as (select count(distinct concat(requester_id, accepter_id)) as accepted from RequestAccepted),
sent as (select count(distinct concat(sender_id, send_to_id)) as sent from FriendRequest)

select case when sent = 0 then 0 
    else round(convert(float, accepted) / sent, 2) end as accept_rate
from sent, accepted;