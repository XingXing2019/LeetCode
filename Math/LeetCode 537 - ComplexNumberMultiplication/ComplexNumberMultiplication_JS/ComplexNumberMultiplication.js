/**
 * @param {string} num1
 * @param {string} num2
 * @return {string}
 */
var complexNumberMultiply = function (num1, num2) { 
    var parts1 = num1.split('+')
    var parts2 = num2.split('+')
    var real1 = parseInt(parts1[0])
    var real2 = parseInt(parts2[0])
    var img1 = parseInt(parts1[1].substring(0, parts1[1].length - 1))
    var img2 = parseInt(parts2[1].substring(0, parts2[1].length - 1))
    var real = real1 * real2 - img1 * img2
    var img = real1 * img2 + real2 * img1
    return `${real}+${img}i`
}