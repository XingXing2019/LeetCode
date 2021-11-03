/**
 * @param {string} s
 * @return {boolean}
 */
var checkOnesSegment = function (s) {
    let matches = s.match(/1+/g);
    return matches != null && matches.length < 2;
};