/**
 * @param {Function} fn
 */
function memoize (fn) {
    const map = {}
    return function(...args) {
        const key = args.join('.')
        if (map[key] === undefined)
            map[key] = fn(...args)
        return map[key]
    }
}
