/**
 * @param {string} s
 * @param {number} k
 * @return {number}
 */
var longestSubstring = function (s, k) {
  var divideConquer = function (li, hi) {
    if (li > hi) return 0
    var record = []
    for (let i = li; i <= hi; i++) {
      var index = s[i].charCodeAt() - 'a'.charCodeAt()
      if (!record[index]) record[index] = [i, 0]
      record[index][1]++
    }
    for (let i = 0; i < 26; i++) {
      if (!record[i]) continue
      if (record[i][1] < k)
        return Math.max(
          divideConquer(li, record[i][0] - 1),
          divideConquer(record[i][0] + 1, hi)
        )
    }
    return hi - li + 1
  }
  return divideConquer(0, s.length - 1)
}
