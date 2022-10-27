/**
 * @param {number[][]} img1
 * @param {number[][]} img2
 * @return {number}
 */
var largestOverlap = function(img1, img2) {
    var one1 = [], one2 = []
    for (let x = 0; x < img1.length; x++) {
        for (let y = 0; y < img1[0].length; y++) {
            if (img1[x][y] == 1)
                one1.push(x * 100 + y)
            if (img2[x][y] == 1)
                one2.push(x * 100 + y)
        }        
    }
    var map = new Map()
    var res = 0
    for (let i = 0; i < one1.length; i++) {
        for (let j = 0; j < one2.length; j++) {
            var temp = one1[i] - one2[j]
            if (!map.has(temp))
                map.set(temp, 0)
            map.set(temp, map.get(temp) + 1)
            res = Math.max(res, map.get(temp))
        }        
    }
    return res
}

