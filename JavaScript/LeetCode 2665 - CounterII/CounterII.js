/**
 * @param {integer} init
 * @return { increment: Function, decrement: Function, reset: Function }
 */
var createCounter = function(init) {
    let count = init
    return {
        increment: () => ++count,
        decrement: () => --count,
        reset: () => count = init
    }
};
