/**
 * @param {Function} fn
 * @return {Function}
 */
var curry = function(fn) {
    return function curried(...args) {
        if (args.length == fn.length)
            return fn(...args)
        return function (...otherArgs) {
            return curried(...args, ...otherArgs)
        }
    };
};
