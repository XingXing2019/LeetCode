/**
 * @param {number} num
 * @return {boolean}
 */
var checkPerfectNumber = function (num) {
  if (num === 1) return false
  var temp = num - 1
  for (let i = 2; i < Math.sqrt(num); i++) {
    if (num % i === 0) temp -= i + num / i
  }
  return temp === 0
}
