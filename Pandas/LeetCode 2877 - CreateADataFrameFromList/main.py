import pandas as pd


def createDataframe(student_data: List[List[int]]) -> pd.DataFrame:
    res = pd.DataFrame(student_data)
    res.columns = ['student_id', 'age']
    return res
