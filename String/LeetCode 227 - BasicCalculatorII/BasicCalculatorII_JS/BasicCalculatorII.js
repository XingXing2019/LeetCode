/**
 * @param {string} s
 * @return {number}
 */
 var calculate = function (s) {
    s += '#';
    var operator = '', num = '';
    var stack = [];
    for (let i = 0; i < s.length; i++) {
        if (s[i] == ' ') continue;
        if (!isNaN(s[i])) {
            num += s[i];
        } else {
            if (operator == '+' || operator == '')
                stack.push(parseInt(num));
            else if (operator == '-')
                stack.push(-parseInt(num));
            else if (operator == '*')
                stack.push(parseInt(num) * stack.pop());
            else if (operator == '/')                       
                stack.push(~~(stack.pop() / parseInt(num)));
            operator = s[i];
            num = '';
        }
    }
    var res = 0;
    while (stack.length != 0)
        res += stack.pop();
    return res;
};