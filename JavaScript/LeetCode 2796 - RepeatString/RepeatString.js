String.prototype.replicate = function(times) {
    var res = ''
    for (let i = 0; i < times; i++)
        res += this
    return res
}