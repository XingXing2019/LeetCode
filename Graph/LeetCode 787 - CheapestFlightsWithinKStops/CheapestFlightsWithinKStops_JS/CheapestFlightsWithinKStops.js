/**
 * @param {number} n
 * @param {number[][]} flights
 * @param {number} src
 * @param {number} dst
 * @param {number} k
 * @return {number}
 */
var findCheapestPrice = function(n, flights, src, dst, k) {
    var dp = new Array(n), graph = new Array(n)
    for (let i = 0; i < n; i++) {
        dp[i] = new Array(n).fill(Number.MAX_VALUE)
        graph[i] = []
    }
    flights.forEach(x => {
        graph[x[0]].push([x[1], x[2]])  
    })
    var queue = []
    var res = Number.MAX_VALUE
    queue.push([src, 0, k])
    while (queue.length != 0) {
        var cur = queue.shift()
        var curCity = cur[0], curCost = cur[1], curStop = cur[2]
        if (curCity == dst)
            res = Math.min(res, curCost)
        for (let i = 0; i < graph[curCity].length; i++) {
            var nextCity = graph[curCity][i][0], nextCost = graph[curCity][i][1]
            if (dp[curCity][nextCity] <= curCost + nextCost || curStop < 0)
                continue
            dp[curCity][nextCity] = curCost + nextCost
            queue.push([nextCity, curCost + nextCost, curStop - 1])
        }
    }
    return res == Number.MAX_VALUE ? -1 : res
};