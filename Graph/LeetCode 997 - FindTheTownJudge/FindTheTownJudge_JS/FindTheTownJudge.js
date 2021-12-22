/**
 * @param {number} n
 * @param {number[][]} trust
 * @return {number}
 */
var findJudge = function (n, trust) {
    var inDegree = [], outDegree = [];
    for (let i = 0; i < n; i++) {
        inDegree[i] = 0;
        outDegree[i] = 0;   
    }
    trust.forEach(x => {
        outDegree[x[0] - 1]++;
        inDegree[x[1] - 1]++;
    });
    for (let i = 0; i < n; i++) {
        if (inDegree[i] === n - 1 && outDegree[i] === 0)
            return i + 1;
    }
    return -1;
};