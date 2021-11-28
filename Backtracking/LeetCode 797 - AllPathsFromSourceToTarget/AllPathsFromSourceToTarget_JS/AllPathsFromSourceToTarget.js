/**
 * @param {number[][]} graph
 * @return {number[][]}
 */
var allPathsSourceTarget = function (graph) {
    var dfs = function (cur, target, path, res) {
        if (cur == target) {
            res.push(path.slice());
            return;
        }
        graph[cur].forEach(next => {
            path.push(next);
            dfs(next, target, path, res);
            path.pop();
        });
    }
    var res = [];
    dfs(0, graph.length - 1, [0], res);
    return res;
};