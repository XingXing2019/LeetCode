class Solution:
    def tribonacci(self, n: int) -> int:
        if n == 0:
            return 0
        if n < 3:
            return 1
        num0, num1, num2 = 0, 1, 1
        for i in range(3, n + 1):
            temp = num0 + num1 + num2
            num0 = num1
            num1 = num2
            num2 = temp
        return num2
