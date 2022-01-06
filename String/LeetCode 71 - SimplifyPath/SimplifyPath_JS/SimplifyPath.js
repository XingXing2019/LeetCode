/**
 * @param {string} path
 * @return {string}
 */
var simplifyPath = function (path) {
  var parts = path.split('/')
  var stack = []
  for (const part of parts) {
    if (part == '') continue
    if (part == '..' && stack.length > 0) stack.pop()
    else if (part != '.' && part != '..') stack.push(part)
  }
  return '/' + stack.join('/')
}
