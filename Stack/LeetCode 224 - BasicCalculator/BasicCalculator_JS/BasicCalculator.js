/**
 * @param {string} s
 * @return {number}
 */
var calculate = function (s) {
    var stack = [];
    var temp = '';
    for (let i = 0; i < s.length; i++) {
        if (s[i] == ' ') continue;
        if (s[i] != ')')
            stack.push(s[i]);
        else {
            temp = '';
            while (stack.length != 0 && stack[stack.length - 1] != '(')
                temp = stack.pop() + temp;
            stack.pop();
            var num = calc(temp);
            if (num < 0 && stack.length != 0 && stack[stack.length - 1] == '-'){
                stack.pop();
                stack.push('+');
                num = -num;
            }
            stack.push(num);
        }        
    }
    temp = '';
    while (stack.length != 0)
        temp = stack.pop() + temp;
    return calc(temp);
};

var calc = function (s) {
    s += '#';
    var num = 0, op = '';
    var stack = [];
    for (let i = 0; i < s.length; i++) {
        if (!isNaN(s[i]))
            num = num * 10 + parseInt(s[i]);
        else {
            stack.push(op == '-' ? -num : num);
            op = s[i];
            num = 0;
        }        
    }
    var res = 0;
    while (stack.length != 0)
        res += stack.pop();
    return res;
}