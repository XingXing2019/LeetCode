select d.date_id, d.make_name, count(distinct d.lead_id) as unique_leads, count(distinct d.partner_id) as unique_partners 
from DailySales d
group by d.date_id, d.make_name