/**
 * @param {number[]} bits
 * @return {boolean}
 */
var isOneBitCharacter = function (bits) {
    var index = 0
    while (index < bits.length - 1)
        index += bits[index] == 1 ? 2 : 1
    return index == bits.length - 1
}
