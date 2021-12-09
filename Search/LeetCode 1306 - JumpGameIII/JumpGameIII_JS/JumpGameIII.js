/**
 * @param {number[]} arr
 * @param {number} start
 * @return {boolean}
 */
var canReach = function (arr, start) {
    if (start < 0 || start >= arr.length || arr[start] < 0)
        return false;
    if (arr[start] == 0)
        return true;
    arr[start] *= -1;
    return canReach(arr, start + arr[start]) || canReach(arr, start - arr[start]);
};

var canReach = function (arr, start) {
    var dfs = function (arr, cur, visited) {
        if (cur < 0 || cur >= arr.length || visited[cur])
            return false;
        if (arr[cur] == 0)
            return true;
        visited[cur] = true;
        return dfs(arr, cur + arr[cur], visited) || dfs(arr, cur - arr[cur], visited);
    }
    return dfs(arr, start, []);
};