/**
 * @param {number} n
 * @param {number[][]} edges
 * @return {number[]}
 */
var findMinHeightTrees = function (n, edges) {
    if (n === 1) return [0];
    var graph = [], inDegree = [], res = [];
    for (let i = 0; i < n; i++) {
        inDegree[i] = 0;
        graph.push([]);
    }
    edges.forEach(x => {
        graph[x[0]].push(x[1]);
        graph[x[1]].push(x[0]);
        inDegree[x[0]]++;
        inDegree[x[1]]++;
    });
    var queue = [];
    for (let i = 0; i < inDegree.length; i++) {
        if (inDegree[i] === 1) {
            queue.push(i);    
            inDegree[i]--;
        }    
    }
    while (queue.length != 0) {
        var count = queue.length;
        res = [];
        for (let i = 0; i < count; i++) {
            var cur = queue.shift();
            res.push(cur);
            graph[cur].forEach(next => {
                inDegree[next]--;
                if (inDegree[next] === 1) {
                    inDegree[next]--;                    
                    queue.push(next);
                }
            });
        }
    }
    return res;
};