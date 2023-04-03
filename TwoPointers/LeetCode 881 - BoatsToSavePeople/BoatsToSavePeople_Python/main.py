class Solution:
    def numRescueBoats(self, people: List[int], limit: int) -> int:
        people.sort()
        li, hi, res = 0, len(people) - 1, 0
        while li < hi:
            if people[li] + people[hi] <= limit:
                li += 1
                hi -= 1
            else:
                hi -= 1
            res += 1
        return res + 1 if li == hi else res
