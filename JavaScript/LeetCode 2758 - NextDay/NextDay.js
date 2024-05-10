Date.prototype.nextDay = function() {
    var next = this.getTime() + 24 * 60 * 60 * 1000
    return new Date(next).toISOString().split('T')[0]
}
