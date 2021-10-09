class Solution:
    def isValid(self, s: str) -> bool:
        map = {')': '(', ']': '[', '}': '{'}
        stack = []
        for c in s:
            if len(stack) != 0 and c in map and map[c] == stack[-1]:
                stack.pop()
            else:
                stack.append(c)
        return len(stack) == 0
