/**
 * @param {number} n
 * @yields {number}
 */
 function* factorial(n) {
    if (n == 0)    
        yield 1
    else {
        var res = 1
        for (let i = 1; i <= n; i++) {
            res *= i
            yield res
        }
    }
};