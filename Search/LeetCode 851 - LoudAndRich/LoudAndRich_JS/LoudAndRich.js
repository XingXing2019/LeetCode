/**
 * @param {number[][]} richer
 * @param {number[]} quiet
 * @return {number[]}
 */
var loudAndRich = function (richer, quiet) {
    var res = [], graph = [];
    for (let i = 0; i < quiet.length; i++){
        res.push(i);
        graph.push([]);
    }
    richer.forEach(x => {
        graph[x[1]].push(x[0])
    });
    var dfs = function(person, cur, visited) {
        if (visited.has(cur))
            return;
        visited.add(cur);
        if (quiet[cur] < quiet[res[person]])
            res[person] = cur;
        graph[cur].forEach(next => {
            dfs(person, next, visited);
        });
    }   
    for (let i = 0; i < quiet.length; i++) {     
        var visited = new Set();   
        dfs(i, i, visited);
    }
    return res;
};