/**
 * @param {number[]} groupSizes
 * @return {number[][]}
 */
var groupThePeople = function (groupSizes) {
    var groups = new Map();
    for (let i = 0; i < groupSizes.length; i++) {
        if (!groups.has(groupSizes[i]))
            groups.set(groupSizes[i], [])
        groups.get(groupSizes[i]).push(i);
    }
    var res = [];
    groups.forEach((value, key) => {
        var temp = [];
        value.forEach(p => {
            temp.push(p);
            if (temp.length == key) {
                res.push(temp);
                temp = [];
            }
        });
    });
    return res;
}
