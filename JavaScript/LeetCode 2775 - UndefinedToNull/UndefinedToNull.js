/**
 * @param {object} obj
 * @return {object}
 */
var undefinedToNull = function(obj) {
    if (obj === undefined || obj === null)        
        return null
    if (typeof obj !== "object")
        return obj
    for (const key of Object.keys(obj))
        obj[key] = undefinedToNull(obj[key])
    return obj
};
