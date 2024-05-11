/**
 * @param {Array} keysArr
 * @param {Array} valuesArr
 * @return {Object}
 */
var createObject = function(keysArr, valuesArr) {
    var res = {}    
    for (let i = 0; i < keysArr.length; i++) {
        var key = keysArr[i] === null ? 'null' : keysArr[i].toString()
        if (res[key] !== undefined) continue        
        res[key] = valuesArr[i]
    }
    return res
};