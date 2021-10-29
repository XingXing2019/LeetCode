/**
 * @param {string} a
 * @param {string} b
 * @return {string}
 */
 var addBinary = function(a, b) {
    let p1 = a.length - 1, p2 = b.length - 1;
    let res = '';
    let cur = 0, car = 0;
    while (p1 >= 0 && p2 >= 0){
        let digitA = a[p1--] - '0', digitB = b[p2--] - '0';
        cur = (digitA + digitB + car) % 2;
        car = parseInt((digitA + digitB + car) / 2);
        res = cur + res;
    }
    while (p1 >= 0) {
        let digitA = a[p1--] - '0'
        cur = (digitA + car) % 2;
        car = parseInt((digitA + car) / 2);
        res = cur + res;
    }
    while (p2 >= 0) {
        let digitB = b[p2--] - '0'
        cur = (digitB + car) % 2;
        car = parseInt((digitB + car) / 2);
        res = cur + res;
    }
    if (car != 0) res = car + res;
    return res;
};