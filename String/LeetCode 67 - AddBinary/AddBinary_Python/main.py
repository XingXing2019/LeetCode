class Solution:
    def addBinary(self, a: str, b: str) -> str:
        a = '0' * max(0, len(b) - len(a)) + a
        b = '0' * max(0, len(a) - len(b)) + b
        res = ""
        car, cur, zero = 0, 0, ord('0')
        p1, p2 = len(a) - 1, len(b) - 1
        while p1 >= 0 and p2 >= 0:
            cur = (ord(a[p1]) - zero + ord(b[p2]) - zero + car) % 2
            car = (ord(a[p1]) - zero + ord(b[p2]) - zero + car) // 2
            res = str(cur) + res
            p1 -= 1
            p2 -= 1
        if car != 0:
            res = str(car) + res
        return res