class Solution:
    def numDecodings(self, s: str) -> int:
        if s[0] == '0':
            return 0
        dp = [0] * len(s)
        dp[0] = 1
        for i in range(1, len(dp)):
            num = int(s[i - 1: i + 1])
            if s[i] == '0':
                if num == 0 or num > 26:
                    return 0
                dp[i] = 1 if i == 1 else dp[i - 2]
            elif num < 10 or num > 26:
                dp[i] = dp[i - 1]
            else:
                dp[i] = dp[i - 1] + 1 if i == 1 else dp[i - 2] + dp[i - 1]
        return dp[-1]


s = "12"
sol = Solution()
print(sol.numDecodings(s))
