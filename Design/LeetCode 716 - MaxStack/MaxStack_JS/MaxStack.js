var MaxStack = function() {
    MaxStack.prototype.stack = []
    MaxStack.prototype.maxStack = []
};

/** 
 * @param {number} x
 * @return {void}
 */
MaxStack.prototype.push = function(x) {
    this.stack.push(x)
    var len = this.maxStack.length
    var max = len == 0 ? x : Math.max(x, this.maxStack[len - 1])
    this.maxStack.push(max)
};

/**
 * @return {number}
 */
MaxStack.prototype.pop = function() {
    this.maxStack.pop()
    return this.stack.pop()
};

/**
 * @return {number}
 */
MaxStack.prototype.top = function() {
    return this.stack[this.stack.length - 1]
};

/**
 * @return {number}
 */
MaxStack.prototype.peekMax = function() {
    return this.maxStack[this.maxStack.length - 1]
};

/**
 * @return {number}
 */
MaxStack.prototype.popMax = function() {
    var max = this.peekMax()
    var temp = []
    while (this.top() != max)
        temp.push(this.pop())
    this.pop()
    while (temp.length != 0)
        this.push(temp.pop())
    return max
};
