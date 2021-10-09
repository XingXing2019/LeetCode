class MyQueue:

    def __init__(self):
        self.stack = []

    def push(self, x: int) -> None:
        temp = []
        while len(self.stack) != 0:
            temp.append(self.stack.pop())
        temp.append(x)
        while len(temp) != 0:
            self.stack.append(temp.pop())

    def pop(self) -> int:
        return self.stack.pop()

    def peek(self) -> int:
        return self.stack[-1]

    def empty(self) -> bool:
        return len(self.stack) == 0


queue = MyQueue()
queue.push(1)
queue.push(2)
print(queue.peek())
print(queue.pop())
print(queue.empty())