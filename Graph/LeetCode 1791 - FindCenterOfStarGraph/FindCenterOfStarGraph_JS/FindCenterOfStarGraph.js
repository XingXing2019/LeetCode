/**
 * @param {number[][]} edges
 * @return {number}
 */
var findCenter = function (edges) {
    var degree = []
    edges.forEach(e => {
        if (degree[e[0]] == undefined)
            degree[e[0]] = 0
        degree[e[0]]++
        if (degree[e[1]] == undefined)
            degree[e[1]] = 0
        degree[e[1]]++
    })
    for (let i = 0; i < degree.length; i++) {
        if (degree[i] == edges.length)
            return i
    }
}
