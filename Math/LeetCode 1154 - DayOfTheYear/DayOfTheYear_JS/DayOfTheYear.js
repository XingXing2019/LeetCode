/**
 * @param {string} date
 * @return {number}
 */
var dayOfYear = function (date) {
    var dates = date.split('-');
    var year = parseInt(dates[0]), month = parseInt(dates[1]), day = parseInt(dates[2]);
    var res = day;
    res += 30 * (month - 1);
    if (month > 2) res -= 2;
    var months = [1, 3, 5, 7, 8, 10, 12];
    var index = 0;
    while (index < months.length && months[index] < month) {
        res++;
        index++;
    }
    if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0) && month > 2)
        res++;
    return res;
};