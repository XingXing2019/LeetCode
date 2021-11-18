/**
 * @param {string} s
 * @return {string}
 */
var decodeString = function (s) {
    var stack = [];
    var num = '', res = '';
    for (let i = 0; i < s.length; i++) {
        if (!isNaN(s[i]))
            num += s[i];
        else if (s[i] != ']') {
            if (num != '')
                stack.push(num);
            num = '';
            stack.push(s[i])
        }
        else {
            var temp = '';
            while (stack.length != 0 && stack[stack.length - 1] != '[')
                temp = stack.pop() + temp;
            if (stack.length != 0 && stack[stack.length - 1] == '[')
                stack.pop();
            if (stack.length != 0 && !isNaN(stack[stack.length - 1])){
                var count = parseInt(stack.pop());
                var record = temp;
                for (let j = 0; j < count - 1; j++)
                    temp += record;                
            }
            stack.push(temp);
        }
    }
    while (stack.length != 0)
        res = stack.pop() + res;
    return res;
};