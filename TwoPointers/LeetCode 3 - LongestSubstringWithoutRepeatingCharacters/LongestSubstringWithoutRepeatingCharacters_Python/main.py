def lengthOfLongestSubstring(self, s: str) -> int:
    li, hi, res = 0, 0, 0
    letters = [0] * 128
    while hi < len(s):
        letters[ord(s[hi])] += 1
        while li < hi and letters[ord(s[hi])] != 1:
            letters[ord(s[li])] -= 1
            li += 1
        res = max(res, hi - li + 1)
        hi += 1
    return res
