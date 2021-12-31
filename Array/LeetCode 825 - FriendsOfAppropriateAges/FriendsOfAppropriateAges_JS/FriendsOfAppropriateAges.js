/**
 * @param {number[]} ages
 * @return {number}
 */
var numFriendRequests = function (ages) {
  var freq = [],
    sumFreq = []
  ages.forEach((x) => {
    if (!freq[x]) freq[x] = 0
    freq[x]++
  })
  sumFreq[0] = 0
  for (let i = 1; i < freq.length; i++)
    sumFreq[i] = freq[i] ? freq[i] + sumFreq[i - 1] : sumFreq[i - 1]
  var res = 0
  for (let x = 15; x < freq.length; x++) {
    if (!freq[x]) continue
    var temp = sumFreq[x] - sumFreq[~~(x / 2) + 7]
    res += temp * freq[x] - freq[x]
  }
  return res
}
