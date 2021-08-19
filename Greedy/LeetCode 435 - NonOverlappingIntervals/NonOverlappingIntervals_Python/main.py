class Solution:
    def eraseOverlapIntervals(self, intervals: List[List[int]]) -> int:
        intervals.sort(key=lambda x: (x[0], x[1]))
        hi, res = intervals[0][1], 0
        for i in range(1, len(intervals)):
            if intervals[i][0] < hi <= intervals[i][1]:
                res += 1
            elif hi >= intervals[i][1]:
                res += 1
                hi = intervals[i][1]
            elif hi <= intervals[i][0]:
                hi = intervals[i][1]
        return res
