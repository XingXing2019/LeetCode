/**
 * @param {string[]} list1
 * @param {string[]} list2
 * @return {string[]}
 */
var findRestaurant = function (list1, list2) {
    var map1 = {}, map2 = {}
    for (let i = 0; i < list1.length; i++) 
        map1[list1[i]] = i
    for (let i = 0; i < list2.length; i++) 
        map2[list2[i]] = i
    var res = {}, min = Number.MAX_VALUE
    for (const restaurant in map1) {
        if (map2[restaurant] != undefined) {
            var sum = map1[restaurant] + map2[restaurant]
            min = Math.min(min, sum)
            if (res[sum] == undefined)
                res[sum] = []
            res[sum].push(restaurant)
        }
    }
    return res[min]
}
