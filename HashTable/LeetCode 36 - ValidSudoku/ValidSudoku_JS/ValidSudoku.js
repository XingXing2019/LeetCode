/**
 * @param {character[][]} board
 * @return {boolean}
 */
var isValidSudoku = function (board) {
    var row = [], col = [], grid = [];
    for (let i = 0; i < board.length; i++) {
        row.push(new Array(9));
        col.push(new Array(9));
        grid.push(new Array(9));
    }
    for (let i = 0; i < board.length; i++) {
        for (let j = 0; j < board[0].length; j++) {
            if (board[i][j] == '.') continue;
            var num = parseInt(board[i][j]) - 1;
            var index = ~~(i / 3) * 3 + ~~(j / 3);
            if (row[i][num]) return false;
            row[i][num] = true;
            if (col[j][num]) return false;
            col[j][num] = true;
            if (grid[index][num]) return false;
            grid[index][num] = true;
        }
    }
    return true;
};