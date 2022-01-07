/**
 * @param {string} s
 * @return {number}
 */
var maxDepth = function (s) {
  var res = 0, level = 0
  for (let i = 0; i < s.length; i++) {
    if (s[i] === '(') {
      level++
      res = Math.max(res, level)
    } else if (s[i] === ')') level--
  }
  return res
}
