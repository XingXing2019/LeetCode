/**
 * @param {Function[]} functions
 * @return {Function}
 */
var compose = function (functions) {    
    return function (x) {
        var init = x
        for (let i = functions.length - 1; i >= 0; i--)
            init = functions[i](init)
        return init    
    }
}