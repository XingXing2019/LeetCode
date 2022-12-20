/**
 * @param {number[][]} rooms
 * @return {boolean}
 */
var canVisitAllRooms = function(rooms) {
    var visited = new Array(rooms.length).fill(false)
    var queue = []
    queue.push(0)
    while (queue.length != 0) {
        var cur = queue.shift()
        visited[cur] = true
        rooms[cur].forEach(next => {
            if (!visited[next]) {
                queue.push(next)
            }
        })
    }
    for (let i = 0; i < visited.length; i++) {
        if (visited[i]) continue
        return false 
    }
    return true
}