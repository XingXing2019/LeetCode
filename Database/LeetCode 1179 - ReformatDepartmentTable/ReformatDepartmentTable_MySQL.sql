SELECT id, 
MIN(CASE WHEN MONTH = 'Jan' THEN revenue END) AS Jan_Revenue,
MIN(CASE WHEN MONTH = 'Feb' THEN revenue END) AS Feb_Revenue,
MIN(CASE WHEN MONTH = 'Mar' THEN revenue END) AS Mar_Revenue,
MIN(CASE WHEN MONTH = 'Apr' THEN revenue END) AS Apr_Revenue,
MIN(CASE WHEN MONTH = 'May' THEN revenue END) AS May_Revenue,
MIN(CASE WHEN MONTH = 'Jun' THEN revenue END) AS Jun_Revenue,
MIN(CASE WHEN MONTH = 'Jul' THEN revenue END) AS Jul_Revenue,
MIN(CASE WHEN MONTH = 'Aug' THEN revenue END) AS Aug_Revenue,
MIN(CASE WHEN MONTH = 'Sep' THEN revenue END) AS Sep_Revenue,
MIN(CASE WHEN MONTH = 'Oct' THEN revenue END) AS Oct_Revenue,
MIN(CASE WHEN MONTH = 'Nov' THEN revenue END) AS Nov_Revenue,
MIN(CASE WHEN MONTH = 'Dec' THEN revenue END) AS Dec_Revenue
FROM Department
GROUP BY id;