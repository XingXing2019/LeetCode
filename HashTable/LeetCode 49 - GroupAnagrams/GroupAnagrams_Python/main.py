from typing import List


class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        map = {}
        for word in strs:
            code = self.encode(word)
            if code not in map:
                map[code] = []
            map[code].append(word)
        res = []
        for words in map.values():
            res.append(words)
        return res

    def encode(self, word: str) -> str:
        letters = [0] * 26
        for l in word:
            letters[ord(l) - ord('a')] += 1
        res = ""
        for i in range(26):
            res += chr(i + ord('a')) + str(letters[i])
        return res
