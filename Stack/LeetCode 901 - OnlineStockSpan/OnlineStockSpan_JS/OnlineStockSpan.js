
var StockSpanner = function() {
    StockSpanner.prototype.stack = []
    StockSpanner.prototype.prices = []
    StockSpanner.prototype.index = 0
};

/** 
 * @param {number} price
 * @return {number}
 */
StockSpanner.prototype.next = function (price) {    
    this.prices.push(price)
    while (this.stack.length != 0 && this.prices[this.stack[this.stack.length - 1]] <= price)
        this.stack.pop()    
    var res = this.stack.length == 0 ? this.index + 1 : this.index - this.stack[this.stack.length - 1]
    this.stack.push(this.index)
    this.index++
    return res
};
