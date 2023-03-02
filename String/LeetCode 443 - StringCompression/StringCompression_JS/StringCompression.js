/**
 * @param {character[]} chars
 * @return {number}
 */
var compress = function(chars) {
    var count = 0, p1 = 0, p2 = 0
    var cur = chars[0]
    var convert = function () {
        var temp = count.toString()
        for (let i = 0; i < temp.length; i++)
            chars[p2++] = temp[i]   
    }
    while (p1 < chars.length) {
        if (chars[p1] == cur)
            count++
        else {
            chars[p2++] = cur
            if (count != 1)
                convert()
            count = 1
            cur = chars[p1]
        }
        p1++
    }
    chars[p2++] = cur
    if (count != 1)
        convert()
    return p2
};