/**
 * @param {string} word
 * @return {number}
 */
var numDifferentIntegers = function(word) {
    var set = new Set()
    var num = ''
    var hasNum = false
    for (let i = 0; i < word.length; i++) {
        if (isNaN(word.charAt(i))) {
            if (hasNum)
                set.add(num)
            hasNum = false
            num = ''
        } else {
            hasNum = true
            if (word.charAt(i) != '0' || num.length != 0)
                num += word.charAt(i)
        }
    }
    if (hasNum)
        set.add(num)
    return set.size
};