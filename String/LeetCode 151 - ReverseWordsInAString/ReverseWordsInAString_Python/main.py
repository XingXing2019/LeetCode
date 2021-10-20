class Solution:
    def reverseWords(self, s: str) -> str:
        words = s.split(" ")
        res = ""
        for i in range(len(words) - 1, -1, -1):
            if not words[i]:
                continue
            res += words[i] + " "
        return res.strip()


s = "the sky    is    blue    "
sol = Solution()
print(sol.reverseWords(s))