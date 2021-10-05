from typing import List


class Solution:
    def generate(self, numRows: int) -> List[List[int]]:
        res = [[1]]
        for i in range(1, numRows, 1):
            row = res[-1]
            newRow = [0] * (i + 1)
            for j in range(len(newRow)):
                newRow[j] = 1 if j == 0 or j == i else row[j - 1] + row[j]
            res.append(newRow)
        return res
