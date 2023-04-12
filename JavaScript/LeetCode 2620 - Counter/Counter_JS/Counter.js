/**
 * @param {number} n
 * @return {Function} counter
 */
var createCounter = function (n) {
    var start = n
    return function() {
        return start++        
    }
};