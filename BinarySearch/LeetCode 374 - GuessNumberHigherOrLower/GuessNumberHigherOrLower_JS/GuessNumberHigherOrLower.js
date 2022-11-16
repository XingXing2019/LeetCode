var guess = function (num) { }
var guessNumber = function(n) {
    var li = 1, hi = n
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        if (guess(mid) == 0)
            return mid
        else if (guess(mid) == -1)
            hi = mid - 1
        else
            li = mid + 1
    }
    return -1
}