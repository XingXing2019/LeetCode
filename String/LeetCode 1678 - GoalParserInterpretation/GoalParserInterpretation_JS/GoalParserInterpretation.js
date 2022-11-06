/**
 * @param {string} command
 * @return {string}
 */
var interpret = function(command) {
    var res = ''
    for (let i = 0; i < command.length; i++) {
        if (command[i] == '(' && command[i + 1] == ')')
            res += 'o'
        else if (command[i] != '(' && command[i] != ')')
            res += command[i]
    }
    return res
}