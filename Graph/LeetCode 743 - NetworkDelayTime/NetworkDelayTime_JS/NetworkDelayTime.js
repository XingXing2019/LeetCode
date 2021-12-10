/**
 * @param {number[][]} times
 * @param {number} n
 * @param {number} k
 * @return {number}
 */
var networkDelayTime = function (times, n, k) {
    var graph = [], dp = [], queue = [];
    for (let i = 0; i < n + 1; i++) {
        graph.push([]);
        dp.push(Number.MAX_VALUE);
    }
    times.forEach(x => {
        graph[x[0]].push([x[1], x[2]]);
    });
    queue.push([k, 0]);
    dp[0] = dp[k] = 0;
    while (queue.length != 0) {
        var cur = queue.shift();
        var curNode = cur[0], time = cur[1];
        graph[curNode].forEach(next => {
            var nextNode = next[0], cost = next[1];
            if (time + cost < dp[nextNode]) {
                dp[nextNode] = time + cost;
                queue.push([nextNode, time + cost]);
            } 
        });
    }
    var max = Math.max(...dp);
    return max === Number.MAX_VALUE ? -1 : max;
};