/**
 * @param {character[][]} board
 * @return {number}
 */
var countBattleships = function (board) {
    var dfs = function (x, y) {
        if (x < 0 || x >= board.length || y < 0 || y >= board[0].length || board[x][y] != 'X')
            return;
        board[x][y] = '.';
        dfs(x + 1, y);
        dfs(x - 1, y);
        dfs(x, y + 1);
        dfs(x, y - 1);
    }
    var res = 0;
    for (let x = 0; x < board.length; x++) {
        for (let y = 0; y < board[0].length; y++) {
            if (board[x][y] != 'X') continue;
            dfs(x, y);
            res++;
        }        
    }
    return res;
};