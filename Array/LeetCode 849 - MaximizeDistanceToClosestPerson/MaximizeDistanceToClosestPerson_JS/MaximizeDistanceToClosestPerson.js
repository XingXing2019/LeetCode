/**
 * @param {number[]} seats
 * @return {number}
 */
var maxDistToClosest = function (seats) {
    var first = -1, cur = 0, res = 0
    for (let i = 0; i < seats.length; i++) {
        if (seats[i] == 0) 
            continue        
        if (first === -1)
            first = i            
        else {
            var dis = (i - cur - 1) % 2 === 0 ? (i - cur - 1) / 2 : ~~((i - cur - 1) / 2) + 1
            res = Math.max(res, dis)
        }            
        cur = i
    }
    return Math.max(res, first, seats.length - cur - 1)
}
