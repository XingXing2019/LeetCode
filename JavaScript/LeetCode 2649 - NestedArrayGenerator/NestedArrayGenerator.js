/**
 * @param {Array} arr
 * @return {Generator}
 */
var inorderTraversal = function*(arr) {
    for (const element of arr) {
        if (Array.isArray(element))
            yield* inorderTraversal(element)
        else
            yield element
    }
}
