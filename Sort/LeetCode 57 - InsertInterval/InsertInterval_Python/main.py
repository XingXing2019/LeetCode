class Solution:
    def insert(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        li, hi, inserted = newInterval[0], newInterval[1], False
        res = []
        for i in intervals:
            if not inserted and hi < i[0]:
                res.append([li, hi])
                res.append(i)
                inserted = True
            elif i[0] <= li <= i[1] or i[0] <= hi <= i[1]:
                li = min(li, i[0])
                hi = max(hi, i[1])
            elif i[1] < li or i[0] > hi:
                res.append(i)
        if not inserted:
            res.append([li, hi])
        return res
