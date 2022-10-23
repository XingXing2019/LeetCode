/**
 * @param {number} num
 * @return {string}
*/
var intToRoman = function (num) {
    var digits = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1]
    var romans = ['M', 'CM', 'D', 'CD', 'C', 'XC', 'L', 'XL', 'X', 'IX', 'V', 'IV', 'I']
    var res = ''
    for (let i = 0; i < digits.length; i++) {
        var temp = ~~(num / digits[i])
        if (temp == 0) continue
        for (let j = 0; j < temp; j++)
            res += romans[i]      
        num %= digits[i]
    }
    return res
}