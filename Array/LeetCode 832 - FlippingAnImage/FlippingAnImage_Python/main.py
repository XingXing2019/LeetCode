class Solution:
    def flipAndInvertImage(self, image: List[List[int]]) -> List[List[int]]:
        for row in image:
            li, hi = 0, len(row) - 1
            while li < hi:
                row[li] ^= 1
                row[hi] ^= 1
                row[li], row[hi] = row[hi], row[li]
                li += 1
                hi -= 1
            if li == hi:
                row[li] ^= 1
        return image
