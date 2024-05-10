/** 
 * @param {number} target
 * @return {number}
 */
Array.prototype.upperBound = function(target) {
    var li = 0, hi = this.length - 1
    while (li <= hi) {
        var mid = li + Math.floor((hi - li) / 2)
        if (this[mid] <= target)
            li = mid + 1
        else
            hi = mid - 1
    }
    return hi >= 0 && this[hi] == target ? hi : -1
};