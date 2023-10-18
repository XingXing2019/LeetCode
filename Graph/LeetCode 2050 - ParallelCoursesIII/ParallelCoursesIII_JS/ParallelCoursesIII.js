/**
 * @param {number} n
 * @param {number[][]} relations
 * @param {number[]} time
 * @return {number}
 */
var minimumTime = function(n, relations, time) {
    var indegree = new Array(n + 1).fill(0)
    var months = new Array(n + 1)
    var graph = new Array(n + 1)
    for (let i = 0; i < n + 1; i++) {
        months[i] = i == 0 ? 0 : time[i - 1]
        graph[i] = []
    }
    relations.forEach(x => {
        graph[x[0]].push(x[1])
        indegree[x[1]]++
    });
    var queue = []
    for (let i = 1; i < n + 1; i++) {
        if (indegree[i] != 0) continue
        queue.push(i)
    }
    while (queue.length != 0) {
        var cur = queue.shift()
        for (let i = 0; i < graph[cur].length; i++) {
            var next = graph[cur][i]            
            indegree[next]--
            if (indegree[next] == 0)
                queue.push(next)            
            months[next] = Math.max(months[next], months[cur] + time[next - 1])            
        }
    }
    return Math.max(...months)
};