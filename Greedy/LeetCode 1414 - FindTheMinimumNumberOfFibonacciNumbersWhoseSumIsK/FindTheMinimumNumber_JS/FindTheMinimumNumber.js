/**
 * @param {number} k
 * @return {number}
 */
var findMinFibonacciNumbers = function (k) {
    var num1 = 1, num2 = 1
    var fib = [num1, num2]
    while (num2 < k) {
        var num3 = num1 + num2;
        fib.push(num3)
        num1 = num2
        num2 = num3
    }
    var index = fib.length - 1, res = 0
    while (k != 0) {
        if (k >= fib[index]) {
            k -= fib[index]
            res++
        }
        index--
    }
    return res
}
