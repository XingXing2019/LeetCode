/**
 * @param {Function[]} functions
 * @param {number} n
 * @return {Function}
 */
var promisePool = async function (functions, n) {
    return new Promise((res, rej) => {
        n = Math.min(n, functions.length);
        if (n == 0) return res();
        let scheduled = 0;
        let resolved = 0;
        function scheduleOne() {
            functions[scheduled++]().then(() => {
                if (scheduled < functions.length) scheduleOne();
                resolved++;
                if (resolved == functions.length) {
                    res();
                }
            });
        }

        while (scheduled < n) {
            scheduleOne();
        }
    });
};
