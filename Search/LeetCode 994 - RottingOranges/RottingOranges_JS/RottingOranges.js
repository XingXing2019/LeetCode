/**
 * @param {number[][]} grid
 * @return {number}
 */
 var orangesRotting = function (grid) {
    let queue = [];
    let fresh = 0;
    for (let x = 0; x < grid.length; x++) {
        for (let y = 0; y < grid[0].length; y++) {
            if (grid[x][y] === 1)
                fresh++;
            else if (grid[x][y] === 2)
                queue.push([x, y]);
        }
    }
    if (fresh === 0) return 0;
    let days = 0;
    let dir = [1, 0, -1, 0, 1];
    while (queue.length != 0) {
        let count = queue.length;
        for (let i = 0; i < count; i++) {
            let cur = queue.shift();
            for (let j = 0; j < 4; j++) {
                let newX = cur[0] + dir[j];
                let newY = cur[1] + dir[j + 1];
                if (newX < 0 || newX >= grid.length || newY < 0 || newY >= grid[0].length || grid[newX][newY] != 1)
                    continue;
                grid[newX][newY] = 2;
                queue.push([newX, newY]);
                fresh--;
            }
        }
        days++;
    }
    return fresh == 0 ? days - 1 : -1;
};