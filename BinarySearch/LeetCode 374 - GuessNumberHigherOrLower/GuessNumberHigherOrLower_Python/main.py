# The guess API is already defined for you.
# @param num, your guess
# @return -1 if my number is lower, 1 if my number is higher, otherwise return 0
def guess(num: int) -> int:


class Solution:
    def guessNumber(self, n: int) -> int:
        li, hi = 1, n
        while li <= hi:
            mid = li + (hi - li) // 2
            if guess(mid) == 0:
                return mid
            if guess(mid) < 0:
                hi = mid - 1
            else:
                li = mid + 1
