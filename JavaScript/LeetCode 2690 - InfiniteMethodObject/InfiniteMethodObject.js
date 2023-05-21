/**
 * @return {Object}
 */
var createInfiniteObject = function() {
    return new Proxy({}, {
        get (target, prop) {
            return () => prop
        }
    })
};