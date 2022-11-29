var RandomizedSet = function() {
    RandomizedSet.prototype.indexMap = new Map()
    RandomizedSet.prototype.nums = []
};

/** 
 * @param {number} val
 * @return {boolean}
 */
RandomizedSet.prototype.insert = function (val) {
    if (this.indexMap.has(val))
        return false
    this.nums.push(val)
    var index = this.nums.length - 1
    this.indexMap.set(val, index)
    return true
};

/** 
 * @param {number} val
 * @return {boolean}
 */
RandomizedSet.prototype.remove = function(val) {
    if (!this.indexMap.has(val))
        return false
    var index = this.indexMap.get(val)
    var temp = this.nums[this.nums.length - 1]
    this.nums[index] = temp
    this.nums.pop()
    this.indexMap.set(temp, index)
    this.indexMap.delete(val)
    return true
};

/**
 * @return {number}
 */
RandomizedSet.prototype.getRandom = function() {
    var index = Math.floor(Math.random() * this.nums.length)
    return this.nums[index]
};