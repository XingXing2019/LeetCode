from typing import List


class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        if target < matrix[0][0]:
            return False
        li, hi = 0, len(matrix) - 1
        while li <= hi:
            mid = li + (hi - li) // 2
            if matrix[mid][0] == target:
                return True
            if matrix[mid][0] > target:
                hi = mid - 1
            else:
                li = mid + 1
        row = matrix[hi]
        li, hi = 0, len(row) - 1
        while li <= hi:
            mid = li + (hi - li) // 2
            if row[mid] == target:
                return True
            if row[mid] > target:
                hi = mid - 1
            else:
                li = mid + 1
        return False
