/**
 * @param {character[][]} board
 * @param {string[]} words
 * @return {string[]}
 */
var findWords = function(board, words) {
    var set = new Set()
    var res = new Set()
    var maxLen = 0;
    for (let i = 0; i < words.length; i++) {
        set.add(words[i])
        maxLen = Math.max(maxLen, words[i])
    }
    for (let x = 0; x < board.length; x++) {
        for (let y = 0; y < board[0].length; y++) {
            var visited = []
            for (let i = 0; i < board.length; i++)
                visited.push(new Array(board[0].length).fill(false))
            if (visited[x][y]) continue
            dfs(board, set, visited, x, y, '', res, maxLen)            
        }        
    }
    return [...res]    
}

var dfs = function (board, words, visited, x, y, cur, res, maxLen) {
    if (x < 0 || x >= board.length || y < 0 || y >= board[0].length || visited[x][y] || cur.length >= maxLen)
        return
    cur += board[x][y]
    if (words.has(cur))
        res.add(cur)
    visited[x][y] = true
    dfs(board, words, visited, x + 1, y, cur, res, maxLen)
    dfs(board, words, visited, x - 1, y, cur, res, maxLen)
    dfs(board, words, visited, x, y + 1, cur, res, maxLen)
    dfs(board, words, visited, x, y - 1, cur, res, maxLen)
    visited[x][y] = false
}