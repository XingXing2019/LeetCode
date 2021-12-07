/**
 * @param {number[]} score
 * @return {string[]}
 */
var findRelativeRanks = function (score) {
    var record = [];
    for (let i = 0; i < score.length; i++) {
        record.push([score[i], i]);
    }
    record.sort((a, b) => {return b[0] - a[0]});
    var res = [];
    var index = 1;
    record.forEach(x => {
        if (index === 1)
            res[x[1]] = 'Gold Medal';
        else if (index === 2)
            res[x[1]] = 'Silver Medal';
        else if (index === 3)
            res[x[1]] = 'Bronze Medal';
        else
            res[x[1]] = index.toString();
        index++;
    });
    return res;
};