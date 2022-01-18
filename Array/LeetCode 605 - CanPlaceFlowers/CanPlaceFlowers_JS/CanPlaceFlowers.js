/**
 * @param {number[]} flowerbed
 * @param {number} n
 * @return {boolean}
 */
var canPlaceFlowers = function (flowerbed, n) {
    if (n == 0) return true
    for (let i = 0; i < flowerbed.length; i++) {
        if (flowerbed[i] == 1) continue
        var before = i == 0 ? true : flowerbed[i - 1] == 0;
        var after = i == flowerbed.length - 1 ? true : flowerbed[i + 1] == 0
        if (before && after) {
            n--
            flowerbed[i] = 1
        }    
        if (n == 0) return true
    }
    return false
}
