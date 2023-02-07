class Solution:
    def totalFruit(self, fruits: List[int]) -> int:
        li, hi, res = 0, 0, 0
        collected = {}
        while hi < len(fruits):
            if fruits[hi] not in collected:
                collected[fruits[hi]] = 0
            collected[fruits[hi]] += 1
            while li < hi and len(collected) > 2:
                collected[fruits[li]] -= 1
                if collected[fruits[li]] == 0:
                    collected.pop(fruits[li])
                li += 1
            res = max(res, hi - li + 1)
            hi += 1
        return res
