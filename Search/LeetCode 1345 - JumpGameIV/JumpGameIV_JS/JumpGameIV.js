/**
 * @param {number[]} arr
 * @return {number}
 */
var minJumps = function (arr) {
    var graph = {}
    for (let i = 0; i < arr.length; i++) {
        if (!graph[arr[i]]) graph[arr[i]] = []
        graph[arr[i]].push(i)        
    }
    var queue = []
    queue.push([0, 0])
    var visited = new Set()
    visited.add(0)
    while (queue.length != 0) {
        var cur = queue.shift()
        if (cur[0] === arr.length - 1) return cur[1]
        graph[arr[cur[0]]].forEach(next => {
            if (!visited.has(next)) {
                visited.add(next)
                queue.push([next, cur[1] + 1])
            }
        })
        graph[cur[0]] = []
        if (cur[0] != 0 && !visited.has(cur[0] - 1)) {
            visited.add(cur[0] - 1)
            queue.push([cur[0] - 1, cur[1] + 1])
        }
        if (cur[0] != arr.length - 1 && !visited.has(cur[0] + 1)) {
            visited.add(cur[0] + 1)
            queue.push([cur[0] + 1, cur[1] + 1])
        }
    }
    return -1
}
