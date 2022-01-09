/**
 * @param {string} instructions
 * @return {boolean}
 */
 var isRobotBounded = function(instructions) {
     var x = 0, y = 0, index = 0
     var dx = [-1, 0, 1, 0]
     var dy = [0, 1, 0, -1]
     for (let i = 0; i < instructions.length; i++) {
         if (instructions[i] == 'G') {
             x += dx[index]
             y += dy[index]
         } else if (instructions[i] == 'L') {
             index--;
             if (index < 0) index = 3
         } else {
             index++
             if (index > 3) index = 0
         }         
     }
     return x == 0 && y == 0 || index != 0
};