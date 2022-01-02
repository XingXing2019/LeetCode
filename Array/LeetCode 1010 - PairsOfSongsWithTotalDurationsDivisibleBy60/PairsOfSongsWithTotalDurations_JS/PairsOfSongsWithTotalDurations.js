/**
 * @param {number[]} time
 * @return {number}
 */
var numPairsDivisibleBy60 = function (time) {
  var record = []
  var res = 0
  time.forEach((x) => {
    var mod = (60 - (x % 60)) % 60
    if (record[mod]) res += record[mod]
    if (!record[x % 60]) record[x % 60] = 0
    record[x % 60]++
  })
  return res
}
