class Solution:
    def scoreOfParentheses(self, s: str) -> int:
        power, res = 1, 0
        last = ')'
        for l in s:
            if l == '(':
                power = power * 2
            else:
                power = power // 2
                if last == ')':
                    continue
                res = res + power
            last = l
        return res
