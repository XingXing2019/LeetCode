class Solution:
    def trap(self, height: List[int]) -> int:
        left, right = [0] * len(height), [0] * len(height)
        leftMax, rightMax, res = 0, 0, 0
        for i in range(len(height)):
            left[i] = leftMax
            leftMax = max(leftMax, height[i])
            right[-(i + 1)] = rightMax
            rightMax = max(rightMax, height[-(i + 1)])
        for i in range(len(left)):
            res += max(0, min(left[i], right[i]) - height[i])
        return res
