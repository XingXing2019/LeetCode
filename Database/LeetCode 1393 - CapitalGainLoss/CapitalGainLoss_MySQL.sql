SELECT stock_name, SUM(CASE WHEN operation = 'Buy' THEN -price WHEN operation = 'Sell' THEN price END) capital_gain_loss
FROM stocks
GROUP BY stock_name;