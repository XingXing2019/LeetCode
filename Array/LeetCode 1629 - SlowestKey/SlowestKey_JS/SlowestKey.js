/**
 * @param {number[]} releaseTimes
 * @param {string} keysPressed
 * @return {character}
 */
var slowestKey = function (releaseTimes, keysPressed) {
    var res = keysPressed[0], max = releaseTimes[0]
    for (let i = 1; i < releaseTimes.length; i++) {
        if (releaseTimes[i] - releaseTimes[i - 1] >= max) {            
            if (releaseTimes[i] - releaseTimes[i - 1] > max)
                res = keysPressed[i]
            else if (keysPressed[i].charCodeAt() > res.charCodeAt())
                res = keysPressed[i]
            max = releaseTimes[i] - releaseTimes[i - 1]
        }        
    }
    return res
}
