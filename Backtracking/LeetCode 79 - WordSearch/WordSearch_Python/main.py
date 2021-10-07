from typing import List


class Solution:
    def exist(self, board: List[List[str]], word: str) -> bool:
        for x in range(len(board)):
            for y in range(len(board[0])):
                if board[x][y] != word[0]:
                    continue
                visited = [[False for i in range(len(board[0]))] for j in range(len(board))]
                if self.dfs(board, word, visited, x, y, 0, ""):
                    return True
        return False

    def dfs(self, board, word, visited, x, y, index, path) -> bool:
        if path == word:
            return True
        if x < 0 or x >= len(board) or y < 0 or y >= len(board[0]) or visited[x][y] or board[x][y] != word[index]:
            return False
        visited[x][y] = True
        res = False
        res = res or self.dfs(board, word, visited, x + 1, y, index + 1, path + board[x][y])
        res = res or self.dfs(board, word, visited, x - 1, y, index + 1, path + board[x][y])
        res = res or self.dfs(board, word, visited, x, y + 1, index + 1, path + board[x][y])
        res = res or self.dfs(board, word, visited, x, y - 1, index + 1, path + board[x][y])
        visited[x][y] = False
        return res


board = [["A", "B", "C", "E"], ["S", "F", "E", "S"], ["A", "D", "E", "E"]]
word = "ABCESEEEFS"
sol = Solution()
print(sol.exist(board, word))
