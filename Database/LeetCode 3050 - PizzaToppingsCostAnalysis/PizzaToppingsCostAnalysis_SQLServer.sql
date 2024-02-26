WITH Pizza AS (
	SELECT t1.topping_name + ',' + t2.topping_name + ',' + t3.topping_name AS pizza, t1.cost + t2.cost + t3.cost AS total_cost
	FROM Toppings t1 
	LEFT JOIN Toppings t2 ON t1.topping_name < t2.topping_name
	LEFT JOIN Toppings t3 ON t1.topping_name < t3.topping_name AND t2.topping_name < t3.topping_name
	WHERE t2.topping_name IS NOT NULL 
	AND t3.topping_name IS NOT NULL
)

SELECT * FROM Pizza
ORDER BY total_cost DESC, pizza