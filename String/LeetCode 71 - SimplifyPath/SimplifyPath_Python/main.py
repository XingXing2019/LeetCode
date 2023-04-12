class Solution:
    def simplifyPath(self, path: str) -> str:
        stack = []
        parts = path.split('/')
        for p in parts:
            if p == '' or p == '.':
                continue
            if p == '..' and len(stack) != 0:
                stack.pop()
            elif p != '..':
                stack.append(p)
        return '/' + '/'.join(stack)
