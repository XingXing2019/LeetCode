/**
 * @param {Object} obj
 * @return {Object}
 */
var invertObject = function (obj) {
    var res = {}   
    for (const key in obj) {
        if (Object.hasOwnProperty.call(obj, key)) {
            const element = obj[key].toString();
            if (!res[element])
                res[element] = key
            else
                res[element] = Array.isArray(res[element]) ? [...res[element], key] : [res[element], key.toString()]
        }
    }    
    return res
}