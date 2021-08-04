from typing import List


class Solution:
    def triangleNumber(self, nums: List[int]) -> int:
        nums.sort()
        res = 0
        for i in range(len(nums) - 1, -1, -1):
            li, hi = 0, i - 1
            while li < hi:
                if nums[li] + nums[hi] <= nums[i]:
                    li += 1
                else:
                    res += hi - li
                    hi -= 1
        return res


sol = Solution()
nums = [2, 2, 3, 4]
print(sol.triangleNumber(nums))
