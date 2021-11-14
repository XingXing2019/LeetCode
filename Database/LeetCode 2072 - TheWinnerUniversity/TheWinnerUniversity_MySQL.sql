select (
	case 
		when (select count(*) from NewYork where score >= 90) > (select count(*) from California where score >= 90) then 'New York University'
        when (select count(*) from NewYork where score >= 90) < (select count(*) from California where score >= 90) then 'California University'
        else 'No Winner' 
	end
) as winner