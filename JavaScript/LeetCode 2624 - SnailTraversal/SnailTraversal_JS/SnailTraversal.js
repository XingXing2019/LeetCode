/**
 * @param {number} rowsCount
 * @param {number} colsCount
 * @return {Array<Array<number>>}
 */
Array.prototype.snail = function(rowsCount, colsCount) {
    var res = []
    if (rowsCount * colsCount != this.length)
        return res
    for (let i = 0; i < rowsCount; i++)
        res.push([])
    var x = 0, y = 0
    var moveDown = true
    for (let i = 0; i < this.length; i++) {
        res[x][y] = this[i]
        x += moveDown ? 1 : -1 
        if (x == rowsCount) {
            moveDown = false
            x = rowsCount - 1
            y++
        } else if (x == -1) {
            moveDown = true
            x = 0
            y++
        }
    }
    return res
}