import pandas as pd


def findHeavyAnimals(animals: pd.DataFrame) -> pd.DataFrame:
    filtered_animal = animals[animals['weight'] > 100]
    sorted_animal = filtered_animal.sort_values(by='weight', ascending=False)
    return sorted_animal[['name']]
