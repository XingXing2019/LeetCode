/**
 * @param {string} s
 * @return {string}
 */
var modifyString = function (s) {
  var letters = s.split('')
  for (let i = 0; i < letters.length; i++) {
    if (letters[i] != '?') continue
    var before = i == 0 ? '' : letters[i - 1]
    var after = i == s.length - 1 ? '' : letters[i + 1]
    for (let j = 0; j < 26; j++) {
      var letter = String.fromCharCode(97 + j)
      if (letter == before || letter == after) continue
      letters[i] = letter
      break
    }
  }
  return letters.join('')
}
