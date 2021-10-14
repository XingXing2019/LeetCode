class Solution:
    def numSquares(self, n: int) -> int:
        dp = [0] * (n + 1)
        num = 1
        while num * num < len(dp):
            dp[num * num] = 1
            num += 1
        for i in range(len(dp)):
            if dp[i] == 1:
                continue
            num, mini = 1, i
            while num * num < i:
                mini = min(mini, 1 + dp[i - num * num])
                num += 1
            dp[i] = mini
        return dp[-1]


n = 12
sol = Solution()
print(sol.numSquares(n))
