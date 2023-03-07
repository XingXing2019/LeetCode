/**
 * @param {number[]} time
 * @param {number} totalTrips
 * @return {number}
 */
var minimumTime = function(time, totalTrips) {
    var li = 0, hi = Math.max(...time) * totalTrips    
    var getTrips = function (time, minTime) {
        var trips = 0
        for (let i = 0; i < time.length; i++) 
            trips += Math.floor(minTime / time[i])
        return trips
    }
    while (li <= hi) {
        var mid = li + Math.floor((hi - li) / 2)
        if (getTrips(time, mid) >= totalTrips)
            hi = mid - 1
        else
            li = mid + 1
    }
    return li
}