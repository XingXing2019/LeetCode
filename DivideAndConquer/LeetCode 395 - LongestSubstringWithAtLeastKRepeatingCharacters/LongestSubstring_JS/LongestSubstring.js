/**
 * @param {string} s
 * @param {number} k
 * @return {number}
 */
var longestSubstring = function (s, k) {
  var res = 0
  var divideConquer = function (li, hi) {
    if (li > hi) return 0
    if (hi - li + 1 <= res) return res
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
    res = Math.max(res, hi - li + 1)
    return hi - li + 1
  }
  divideConquer(0, s.length - 1)
  return res
}
