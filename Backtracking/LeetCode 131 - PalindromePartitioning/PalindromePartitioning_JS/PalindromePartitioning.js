/**
 * @param {string} s
 * @return {string[][]}
 */
var partition = function (s) {
  var res = []
  var dfs = function (str, list) {
    if (str.length == 0) res.push(list.slice())
    for (let i = 0; i < str.length; i++) {
      var temp = str.substring(0, i + 1)
      if (!isPalindrome(temp)) continue
      list.push(temp)
      dfs(str.substring(i + 1), list)
      list.pop()
    }
  }
  var isPalindrome = function (str) {
    var li = 0,
      hi = str.length - 1
    while (li < hi) {
      if (str[li++] != str[hi--]) return false
    }
    return true
  }
  dfs(s, [])
  return res
}
