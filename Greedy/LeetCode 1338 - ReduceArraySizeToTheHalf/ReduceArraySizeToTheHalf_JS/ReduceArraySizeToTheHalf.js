/**
 * @param {number[]} arr
 * @return {number}
 */
var minSetSize = function (arr) {
  var map = new Map()
  arr.forEach((num) => {
    if (!map.has(num)) map.set(num, 0)
    map.set(num, map.get(num) + 1)
  })
  var freq = []
  map.forEach((value, key) => {
    freq.push(value)
  })
  freq.sort((a, b) => b - a)
  var count = 0, res = 0
  for (let i = 0; i < freq.length; i++) {
    count += freq[i]
    res++
    if (count >= arr.length / 2) return res
  }
  return res
}
