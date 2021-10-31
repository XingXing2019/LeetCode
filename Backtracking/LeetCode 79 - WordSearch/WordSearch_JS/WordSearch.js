/**
 * @param {character[][]} board
 * @param {string} word
 * @return {boolean}
 */
var exist = function (board, word) {
    for (let x = 0; x < board.length; x++) {
        for (let y = 0; y < board[0].length; y++) {
            if (board[x][y] != word[0]) continue;
            let visited = Array(board.length);
            for (let i = 0; i < visited.length; i++)
                visited[i] = [];
            if (dfs(board, word, visited, x, y, 0))
                return true;
        }
    }
    return false;
};

var dfs = function (board, word, visited, x, y, index) {
    if (index == word.length)
        return true;
    if (x < 0 || x >= board.length || y < 0 || y >= board[0].length || visited[x][y] || board[x][y] != word[index])
        return false;
    visited[x][y] = true;
    var res = false;
    res = res || dfs(board, word, visited, x + 1, y, index + 1);
    res = res || dfs(board, word, visited, x - 1, y, index + 1);
    res = res || dfs(board, word, visited, x, y + 1, index + 1);
    res = res || dfs(board, word, visited, x, y - 1, index + 1);
    visited[x][y] = false;
    return res;
}