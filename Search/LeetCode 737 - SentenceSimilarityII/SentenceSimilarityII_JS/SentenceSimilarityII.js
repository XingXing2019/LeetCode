/**
 * @param {string[]} sentence1
 * @param {string[]} sentence2
 * @param {string[][]} similarPairs
 * @return {boolean}
 */
var areSentencesSimilarTwo = function (sentence1, sentence2, similarPairs) {
    if (sentence1.length != sentence2.length) return false
    var graph = new Map()
    similarPairs.forEach(pair => {
        if (!graph.has(pair[0]))
            graph.set(pair[0], [])
        graph.get(pair[0]).push(pair[1])
        if (!graph.has(pair[1]))
            graph.set(pair[1], [])
        graph.get(pair[1]).push(pair[0])
    })
    for (let i = 0; i < sentence1.length; i++) {
        if (sentence1[i] == sentence2[i]) continue
        var visited = new Set()
        visited.add(sentence1[i])
        if (!dfs(graph, sentence1[i], sentence2[i], visited))
            return false
    }
    return true
}

var dfs = function (graph, cur, target, visited) {
    if (cur == target) return true
    if (!graph.has(cur)) return false
    for (const next of graph.get(cur)) {
        if (visited.has(next))
            continue
        visited.add(next)
        if (dfs(graph, next, target, visited))
            return true
        visited.delete(next)
    }
    return false
}