/**
 * @param {number} n
 * @return {string}
 */
var countAndSay = function(n) {
    var convert = function (num) {
        var digit = num[0], count = 0, res = ''
        for (let i = 0; i < num.length; i++) {
            if (num[i] == digit)
                count++
            else {
                res += `${count}${digit}`
                digit = num[i]
                count = 1
            }            
        }
        return `${res}${count}${digit}`
    }
    var num = '1'
    for (let i = 1; i < n; i++)
        num = convert(num)
    return num
};