/**
 * @param {character[][]} board
 * @return {void} Do not return anything, modify board in-place instead.
 */
var solve = function (board) {
    let visited = [];
    for (let i = 0; i < board.length; i++)
        visited[i] = new Array(board[0].length);
    for (let i = 0; i < board.length; i++) {
        if (!visited[i][0])
            dfs(board, i, 0, visited);
        if (!visited[i][board[0].length - 1])
            dfs(board, i, board[0].length - 1, visited)
    }
    for (let i = 0; i < board[0].length; i++) {
        if (!visited[0][i])
            dfs(board, 0, i, visited);
        if (!visited[board.length - 1][i])
            dfs(board, board.length - 1, i, visited);
    }
    for (let i = 0; i < board.length; i++) {
        for (let j = 0; j < board[0].length; j++) {
            if (board[i][j] == 'O')
                board[i][j] = 'X';
            else if (board[i][j] == '#')
                board[i][j] = 'O';
        }        
    }
};

var dfs = function (board, x, y, visited) {
    if (x < 0 || x >= board.length || y < 0 || y >= board[0].length || visited[x][y] || board[x][y] != 'O')
        return;
    visited[x][y] = true;
    board[x][y] = '#';
    dfs(board, x + 1, y, visited);
    dfs(board, x - 1, y, visited);
    dfs(board, x, y + 1, visited);
    dfs(board, x, y - 1, visited);
}