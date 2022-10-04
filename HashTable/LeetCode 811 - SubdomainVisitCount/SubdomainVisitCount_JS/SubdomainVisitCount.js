/**
 * @param {string[]} cpdomains
 * @return {string[]}
 */
var subdomainVisits = function (cpdomains) {
    var map = new Map()
    var countVisits = function (domain) {
        var parts = domain.split(' ')
        var count = +parts[0]
        var domains = parts[1].split('.')
        var temp = ''
        for (let i = domains.length - 1; i >= 0; i--) {
            if (i != domains.length - 1) temp = '.' + temp
            temp = domains[i] + temp
            if (!map.has(temp))
                map.set(temp, 0)
            map.set(temp, map.get(temp) + count)
        }
    }
    for (let i = 0; i < cpdomains.length; i++)
        countVisits(cpdomains[i])
    var res = []
    map.forEach((val, key) => {
        res.push(`${val} ${key}`)
    })
    return res
}