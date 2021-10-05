from typing import List


class Solution:
    def isValidSudoku(self, board: List[List[str]]) -> bool:
        rowCheck = [[False for i in range(9)] for j in range(9)]
        colCheck = [[False for i in range(9)] for j in range(9)]
        gridCheck = [[False for i in range(9)] for j in range(9)]
        for i in range(9):
            for j in range(9):
                if board[i][j] == ".":
                    continue
                num = int(board[i][j]) - 1
                index = i // 3 * 3 + j // 3
                if rowCheck[i][num]:
                    return False
                rowCheck[i][num] = True
                if colCheck[j][num]:
                    return False
                colCheck[j][num] = True
                if gridCheck[index][num]:
                    return False
                gridCheck[index][num] = True
        return True


board = [["5", "3", ".", ".", "7", ".", ".", ".", "."], ["6", ".", ".", "1", "9", "5", ".", ".", "."],
         [".", "9", "8", ".", ".", ".", ".", "6", "."], ["8", ".", ".", ".", "6", ".", ".", ".", "3"],
         ["4", ".", ".", "8", ".", "3", ".", ".", "1"], ["7", ".", ".", ".", "2", ".", ".", ".", "6"],
         [".", "6", ".", ".", ".", ".", "2", "8", "."], [".", ".", ".", "4", "1", "9", ".", ".", "5"],
         [".", ".", ".", ".", "8", ".", ".", "7", "9"]]

sol = Solution()
print(sol.isValidSudoku(board))
