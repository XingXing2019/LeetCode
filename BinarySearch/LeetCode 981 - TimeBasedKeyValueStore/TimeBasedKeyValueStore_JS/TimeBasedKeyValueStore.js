var TimeMap = function() {
    TimeMap.prototype.store = new Map()
};

/** 
 * @param {string} key 
 * @param {string} value 
 * @param {number} timestamp
 * @return {void}
 */
TimeMap.prototype.set = function(key, value, timestamp) {
    if (!this.store.has(key))
        this.store.set(key, [])
    this.store.get(key).push([value, timestamp])
};

/** 
 * @param {string} key 
 * @param {number} timestamp
 * @return {string}
 */
TimeMap.prototype.get = function(key, timestamp) {
    if (!this.store.has(key))
        return ''
    return this.binarySearch(this.store.get(key), timestamp)
};

TimeMap.prototype.binarySearch = function (items, timestamp) {
    var li = 0, hi = items.length - 1
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        if (items[mid][1] == timestamp)
            return items[mid][0]
        if (items[mid][1] < timestamp)
            li = mid + 1
        else
            hi = mid - 1
    }
    return hi < 0 ? '' : items[hi][0]
}