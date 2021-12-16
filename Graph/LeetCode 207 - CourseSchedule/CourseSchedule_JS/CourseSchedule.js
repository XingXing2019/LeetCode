/**
 * @param {number} numCourses
 * @param {number[][]} prerequisites
 * @return {boolean}
 */
var canFinish = function (numCourses, prerequisites) {
    var graph = [], inDegree = [], queue = [];
    for (let i = 0; i < numCourses; i++) {
        inDegree[i] = 0;
        graph[i] = [];
    }
    prerequisites.forEach(x => {
        graph[x[1]].push(x[0]);
        inDegree[x[0]]++;
    });
    for (let i = 0; i < inDegree.length; i++) {
        if (inDegree[i] !== 0) continue;
        queue.push(i);        
    }
    while (queue.length != 0) {
        var cur = queue.shift();
        graph[cur].forEach(next => {
            inDegree[next]--;
            if (inDegree[next] === 0)
                queue.push(next);
        });
    }
    return !inDegree.some(x => x != 0);
};