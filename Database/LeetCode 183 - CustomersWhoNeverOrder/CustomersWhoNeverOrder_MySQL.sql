SELECT c.Name AS customers
FROM Customers c LEFT JOIN Orders o
ON c.Id = o.CustomerId 
WHERE o.CustomerId IS NULL;