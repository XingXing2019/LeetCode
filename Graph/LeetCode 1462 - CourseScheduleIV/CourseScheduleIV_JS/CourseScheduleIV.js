/**
 * @param {number} numCourses
 * @param {number[][]} prerequisites
 * @param {number[][]} queries
 * @return {boolean[]}
 */
var checkIfPrerequisite = function (numCourses, prerequisites, queries) {
    var graph = [], res = [], dependencies = {};
    for (let i = 0; i < numCourses; i++)
        graph[i] = [];
    for (const p of prerequisites) 
        graph[p[0]].push(p[1]);
    for (let i = 0; i < numCourses; i++) {
        dependencies[i] = new Set()
        var queue = [i];
        while (queue.length != 0) {
            var cur = queue.shift();
            dependencies[i].add(cur);
            for (const next of graph[cur]) {
                if (dependencies[i].has(next)) continue;
                dependencies[i].add(next);
                queue.push(next);
            }
        }
    }    
    for (const q of queries)
        res.push(dependencies[q[0]].has(q[1]));
    return res;
};