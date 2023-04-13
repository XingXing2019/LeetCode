/**
 * @param {any} o1
 * @param {any} o2
 * @return {boolean}
 */
var areDeeplyEqual = function (o1, o2) {
    if (o1 === o2)
        return true
    if (Array.isArray(o1) !== Array.isArray(o2))
        return false
    if (typeof o1 === "object" && typeof o2 === 'object') {
        const keys1 = Object.keys(o1)
        const keys2 = Object.keys(o2)
        if (keys1.length != keys2.length)
            return false
        return keys1.every(x => areDeeplyEqual(o1[x], o2[x]))
    }
    return false
}