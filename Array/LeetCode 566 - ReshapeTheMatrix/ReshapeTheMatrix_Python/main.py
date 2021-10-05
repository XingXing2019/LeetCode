from typing import List


class Solution:
    def matrixReshape(self, mat: List[List[int]], r: int, c: int) -> List[List[int]]:
        if len(mat) * len(mat[0]) != r * c:
            return mat
        res = [[0 for i in range(c)] for j in range(r)]
        nums = []
        for i in range(len(mat)):
            for j in range(len(mat[0])):
                nums.append(mat[i][j])
        index = 0
        for i in range(r):
            for j in range(c):
                res[i][j] = nums[index]
                index += 1
        return res


mat = [[1, 2], [3, 4]]
r, c = 1, 4
sol = Solution()
print(sol.matrixReshape(mat, r, c))
