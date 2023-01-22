class Solution:
    def partition(self, s: str) -> List[List[str]]:
        res = []
        self.dfs(s, [], res)
        return res

    def dfs(self, s, cur, res):
        if s == '':
            res.append(list(cur))
        for i in range(1, len(s) + 1, 1):
            word = s[0:i]
            if not self.isPalindrome(word):
                continue
            cur.append(word)
            self.dfs(s[i:], cur, res)
            cur.pop()

    def isPalindrome(self, s) -> bool:
        li, hi = 0, len(s) - 1
        while li < hi:
            if s[li] != s[hi]:
                return False
            li += 1
            hi -= 1
        return True