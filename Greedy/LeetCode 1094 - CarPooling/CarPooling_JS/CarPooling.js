/**
 * @param {number[][]} trips
 * @param {number} capacity
 * @return {boolean}
 */
var carPooling = function (trips, capacity) {
  var stops = []
  trips.forEach((x) => {
    if (!stops[x[1]]) stops[x[1]] = 0
    if (!stops[x[2]]) stops[x[2]] = 0
    stops[x[1]] += x[0]
    stops[x[2]] -= x[0]
  })
  var people = 0
  for (let i = 0; i < stops.length; i++) {
    people += stops[i] ? stops[i] : 0
    if (people > capacity) return false
  }
  return true
}
