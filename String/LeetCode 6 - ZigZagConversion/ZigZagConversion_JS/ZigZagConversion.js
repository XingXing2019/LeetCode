/**
 * @param {string} s
 * @param {number} numRows
 * @return {string}
 */
var convert = function (s, numRows) {
    if (numRows == 1) return s;
    let rows = new Array(numRows);
    for (let i = 0; i < rows.length; i++)
        rows[i] = [];
    let index = 0;
    let moveDown = true;
    for (let i = 0; i < s.length; i++) {
        if (index == numRows - 1)
            moveDown = false;
        else if (index == 0)
            moveDown = true;
        rows[index].push(s[i]);
        index += moveDown ? 1 : -1;
    }
    let res = '';
    rows.forEach(row => {
        res += row.join('');
    });
    return res;
};