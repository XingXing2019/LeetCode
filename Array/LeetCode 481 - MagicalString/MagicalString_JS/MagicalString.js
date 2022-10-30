/**
 * @param {number} n
 * @return {number}
 */
var magicalString = function(n) {
    if (n <= 3) return 1
    var s = '122'
    var index = 2, num = 1, count = 1
    while (s.length < n) {
        s += num
        if (num == 1) count++;
        if (s[index++] == '2') {
            s += num
            if (num == 1 && s.length <= n) count++
        }
        num = num == 1 ? 2 : 1        
    }
    return count
}