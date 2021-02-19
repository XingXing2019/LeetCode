SELECT followee AS follower, COUNT(DISTINCT follower) AS num FROM follow GROUP BY followee
HAVING followee IN (SELECT DISTINCT follower FROM follow)
ORDER BY follower