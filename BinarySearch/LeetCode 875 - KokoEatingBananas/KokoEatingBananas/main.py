from math import ceil


class Solution:
    def minEatingSpeed(self, piles: List[int], h: int) -> int:
        li, hi = 1, max(piles)
        while li <= hi:
            mid = li + (hi - li) // 2
            time = 0
            for p in piles:
                time += ceil(p / mid)
            if time > h:
                li = mid + 1
            else:
                hi = mid - 1
        return li
