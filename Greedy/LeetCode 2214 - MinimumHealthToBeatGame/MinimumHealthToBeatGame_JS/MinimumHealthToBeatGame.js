/**
 * @param {number[]} damage
 * @param {number} armor
 * @return {number}
 */
var minimumHealth = function(damage, armor) {
    var sum = 0, max = 0
    for (let i = 0; i < damage.length; i++) {
        max = Math.max(max, damage[i])
        sum += damage[i]
    }
    return sum - Math.min(max, armor) + 1
}