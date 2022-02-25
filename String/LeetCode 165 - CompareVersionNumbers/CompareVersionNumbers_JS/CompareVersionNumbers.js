/**
 * @param {string} version1
 * @param {string} version2
 * @return {number}
 */
var compareVersion = function (version1, version2) {
    var v1 = version1.split('.')
    var v2 = version2.split('.')
    var p1 = 0, p2 = 0
    while (p1 < v1.length && p2 < v2.length) {
        var revision1 = parseInt(v1[p1++])
        var revision2 = parseInt(v2[p2++])
        if (revision1 == revision2)
            continue
        if (revision1 > revision2)
            return 1
        else
            return -1
    }
    while (p1 < v1.length) {
        var revision1 = parseInt(v1[p1++])
        if (revision1 != 0)
            return 1
    }
    while (p2 < v2.length) {
        var revision2 = parseInt(v2[p2++])
        if (revision2 != 0)
            return -1
    }
    return 0
}
