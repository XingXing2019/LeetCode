/**
 * @return {Generator<number>}
 */
var fibGenerator = function*() {
    let x = 0, y = 1
    while (true) {
        yield x
        let t = x + y
        x = y
        y = t
    }
};