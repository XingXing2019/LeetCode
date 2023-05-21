/**
 * @param {number[]} nums
 */
 var ArrayWrapper = function(nums) {
    this.arr = nums
};

ArrayWrapper.prototype.valueOf = function() {
    return this.arr.reduce((acc,curr) => acc+curr, 0)
}

ArrayWrapper.prototype.toString = function() {
    return `[${this.arr}]`
}
