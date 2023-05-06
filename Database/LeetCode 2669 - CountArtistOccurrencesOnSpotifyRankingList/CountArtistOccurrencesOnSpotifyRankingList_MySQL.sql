select artist, count(*) as occurrences
from Spotify
group by artist
order by count(*) desc, artist