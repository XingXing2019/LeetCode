/**
 * @param {number[]} asteroids
 * @return {number[]}
 */
var asteroidCollision = function (asteroids) {
    var stack = [];
    asteroids.forEach(x => {
        if (x > 0)
            stack.push(x);
        else {
            while (stack.length != 0 && stack[stack.length - 1] > 0 && stack[stack.length - 1] < -x)
                stack.pop();
            if (stack.length == 0 || stack[stack.length - 1] < 0)
                stack.push(x);
            else if (stack[stack.length - 1] == -x)
                stack.pop();
        }
    });
    return stack;
};