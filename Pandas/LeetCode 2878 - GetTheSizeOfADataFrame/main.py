import pandas as pd


def getDataframeSize(players: pd.DataFrame) -> List[int]:
    return [len(players), len(players.columns)]
