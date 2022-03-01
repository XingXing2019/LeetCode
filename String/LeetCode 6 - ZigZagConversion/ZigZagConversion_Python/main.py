def convert(self, s: str, numRows: int) -> str:
    if numRows == 1:
        return s
    record = []
    for i in range(numRows):
        record.append([])
    moveDown = True
    index = 0
    for l in s:
        record[index].append(l)
        if index == 0:
            moveDown = True
        elif index == numRows - 1:
            moveDown = False
        index += 1 if moveDown else -1
    res = ''
    for row in record:
        res += ''.join(row)
    return res

