from typing import List


class Solution:
    def jump(self, nums: List[int]) -> int:
        cur, reach, res = 0, 0, 0
        while reach < len(nums) - 1:
            reach = nums[cur] + cur
            maxReach = jumpTo = reach
            for i in range(cur + 1, min(len(nums), reach + 1), 1):
                if nums[i] + i > maxReach:
                    maxReach = nums[i] + i
                    jumpTo = i
            res += 1
            cur = jumpTo
        return res


sol = Solution()
nums = [1, 2, 3, 4, 5]
print(sol.jump(nums))
