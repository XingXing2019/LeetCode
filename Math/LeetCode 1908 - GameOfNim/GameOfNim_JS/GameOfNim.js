/**
 * @param {number[]} piles
 * @return {boolean}
 */
 var nimGame = function(piles) {
    var xOr = 0;
    for (i = 0; i < piles.length; i++)
        xOr ^= piles[i]
    return xOr != 0;
}