/**
 * @param {Function} fn
 * @param {Array} args
 * @return {Function}
 */
var partial = function(fn, args) {    
    return function(...restArgs) {
        var index = 0
        for (let i = 0; i < args.length; i++) {
            if (args[i] !== '_') continue
            args[i] = restArgs[index++]
        }
        while (index != restArgs.length)
            args.push(restArgs[index++])
        return fn(...args)
    }
};