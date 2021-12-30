/**
 * @param {number[]} hand
 * @param {number} groupSize
 * @return {boolean}
 */
var isNStraightHand = function (hand, groupSize) {
    if (hand.length % groupSize != 0) return false;
    var min = Number.MAX_VALUE;
    var record = [];
    hand.forEach(x => {
        if (!record[x])
            record[x] = 0;
        record[x]++;
        min = Math.min(min, x);
    });
    for (let i = min; i < record.length; i++) {
        if (!record[i]) continue;
        for (let j = 0; j < groupSize; j++) {
            if (!record[i + j])
                return false;
            record[i + j]--;
        }
        if (record[i])
            i--;
    }
    return true;
};