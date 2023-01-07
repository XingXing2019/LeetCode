class Solution:
    def canCompleteCircuit(self, gas: List[int], cost: List[int]) -> int:
        net, tank, res = 0, 0, 0
        left = [0] * len(gas)
        for i in range(len(gas)):
            net += gas[i] - cost[i]
            left[i] = gas[i] - cost[i]
        if net < 0:
            return -1
        for i in range(len(left)):
            tank += left[i]
            if tank < 0:
                tank = 0
                res = i + 1
        return res

