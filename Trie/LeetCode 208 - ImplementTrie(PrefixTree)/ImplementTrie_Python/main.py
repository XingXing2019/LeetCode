class Node:
    def __init__(self):
        self.children = {}
        self.isWord = False


class Trie:

    def __init__(self):
        self.head = Node()

    def insert(self, word: str) -> None:
        point = self.head
        for c in word:
            if c not in point.children:
                point.children[c] = Node()
            point = point.children[c]
        point.isWord = True

    def search(self, word: str) -> bool:
        point = self.head
        for c in word:
            if c not in point.children:
                return False
            point = point.children[c]
        return point.isWord

    def startsWith(self, prefix: str) -> bool:
        point = self.head
        for c in prefix:
            if c not in point.children:
                return False
            point = point.children[c]
        return True
