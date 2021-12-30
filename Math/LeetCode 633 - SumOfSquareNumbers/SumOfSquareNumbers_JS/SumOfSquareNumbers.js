/**
 * @param {number} c
 * @return {boolean}
 */
var judgeSquareSum = function (c) {
  var li = 0
  var hi = parseInt(Math.sqrt(c))
  while (li <= hi) {
    if (li * li + hi * hi === c) return true
    else if (li * li + hi * hi > c) hi--
    else li++
  }
  return false
}
