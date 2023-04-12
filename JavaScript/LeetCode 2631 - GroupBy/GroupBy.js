/**
 * @param {Function} fn
 * @return {Array}
 */
Array.prototype.groupBy = function(fn) {
    var map = {}
    for (let i = 0; i < this.length; i++) {
        var key = fn(this[i])
        if (!map[key])
            map[key] = []
        map[key].push(this[i])
    }
    return map
}
