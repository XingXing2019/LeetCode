/**
 * @param {character[][]} board
 * @return {void} Do not return anything, modify board in-place instead.
 */
var solveSudoku = function (board) {
    var row = [], col = [], grid = [];
    for (let i = 0; i < 9; i++) {
        row.push(new Array(9));
        col.push(new Array(9));
        grid.push(new Array(9));
    }
    for (let r = 0; r < board.length; r++) {
        for (let c = 0; c < board[0].length; c++) {
            var num = parseInt(board[r][c]) - 1;
            var index = ~~(r / 3) * 3 + ~~(c / 3);
            row[r][num] = true;
            col[c][num] = true;
            grid[index][num] = true;
        }
    }
    dfs(board, row, col, grid);
};

var dfs = function (board, row, col, grid) {
    for (let r = 0; r < board.length; r++) {
        for (let c = 0; c < board[0].length; c++) {
            if (board[r][c] != '.') continue;
            var index = ~~(r / 3) * 3 + ~~(c / 3);
            for (let i = 1; i <= 9; i++) {
                var num = i - 1;
                if (row[r][num] || col[c][num] || grid[index][num]) continue;
                row[r][num] = true;
                col[c][num] = true;
                grid[index][num] = true;
                board[r][c] = i.toString();
                if (dfs(board, row, col, grid))
                    return true;
                row[r][num] = false;
                col[c][num] = false;
                grid[index][num] = false;
                board[r][c] = '.';
            }
            return false;
        }
    }
    return true;
};