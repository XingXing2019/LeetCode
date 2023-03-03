/**
 * @param {string} haystack
 * @param {string} needle
 * @return {number}
 */
var strStr = function(haystack, needle) {
    if (haystack.length < needle.length)
        return -1
    var word = haystack.substring(0, needle.length)
    for (let i = needle.length; i < haystack.length; i++) {
        if (word == needle)
            return i - needle.length
        word = word.substring(1) + haystack[i]        
    }
    return word == needle ? haystack.length - needle.length : -1
}