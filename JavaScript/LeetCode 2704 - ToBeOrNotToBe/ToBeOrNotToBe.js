/**
 * @param {string} val
 * @return {Object}
 */
var expect = function(val) {
    return {
        toBe: (otherVal) => {
            if (otherVal === val)
                return true
            throw new Error('Not Equal')
        },
        notToBe: (otherVal) => {
            if (otherVal !== val)
                return true
            throw new Error('Equal')
        }
    }
}