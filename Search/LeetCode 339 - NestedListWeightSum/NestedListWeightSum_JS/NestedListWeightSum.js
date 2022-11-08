/**
 * @param {NestedInteger[]} nestedList
 * @return {number}
 */
var depthSum = function(nestedList) {
    var res = 0;
    nestedList.forEach(nestedInteger => {
        res += dfs(nestedInteger, 1)
    })
    return res
};

var dfs = function (nestedInteger, level) {
    if (nestedInteger.isInteger())
        return nestedInteger.getInteger() * level
    var res = 0;
    nestedInteger.getList().forEach(x => {
        res += dfs(x, level + 1)
    })
    return res
}