with CombinationSize as (
	select item_type, max(combination) as combination_size, count(combination) as count
	from (
		select item_type, sum(square_footage) over(partition by item_type order by square_footage) as combination
		from Inventory
	) as t
	group by item_type
),

PrimeSize as (
	select floor(500000 / combination_size) * combination_size as prime_size from CombinationSize where item_type = 'prime_eligible'
)

select * from (
	select item_type, floor((500000 - prime_size) / combination_size) * count as item_count
	from CombinationSize
	cross join PrimeSize
	where item_type = 'not_prime'
	union
	select item_type, floor(500000 / combination_size) * count as item_count
	from CombinationSize
	cross join PrimeSize
	where item_type = 'prime_eligible'
) as t
order by item_count desc