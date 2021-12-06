/**
 * @param {number[]} position
 * @return {number}
 */
 var minCostToMoveChips = function(position) {
    var even = 0, odd = 0;
    position.forEach(x => {
        x % 2 === 0 ? even++ : odd++;
    });
    return even > odd ? odd : even;
};s