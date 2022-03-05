class Solution:
    def numSubseq(self, nums: List[int], target: int) -> int:
        nums.sort()
        pow = [0] * len(nums)
        mod = 1_000_000_000 + 7
        for i in range(len(nums)):
            pow[i] = 1 if i == 0 else pow[i - 1] * 2 % mod
        li, hi, res = 0, len(nums) - 1, 0
        while li <= hi:
            if nums[li] + nums[hi] > target:
                hi -= 1
            else:
                res = (res + pow[hi - li]) % mod
                li += 1
        return res
