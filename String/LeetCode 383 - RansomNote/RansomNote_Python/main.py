class Solution:
    def canConstruct(self, ransomNote: str, magazine: str) -> bool:
        letters = [0] * 26
        for (i, l) in enumerate(ransomNote):
            letters[ord(l) - ord('a')] += 1
        for (i, l) in enumerate(magazine):
            letters[ord(l) - ord('a')] -= 1
        return all(x <= 0 for x in letters)
