from typing import List


def maxScore(self, cardPoints: List[int], k: int) -> int:
    total, window = sum(cardPoints), sum(cardPoints[0:len(cardPoints) - k])
    li, hi, remove = 0, len(cardPoints) - k - 1, window
    while hi < len(cardPoints) - 1:
        window -= cardPoints[li]
        li += 1
        hi += 1
        window += cardPoints[hi]
        remove = min(remove, window)
    return total - min(remove, window)
