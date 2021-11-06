/**
 * @param {number[][]} room
 * @return {number}
 */
 var numberOfCleanRooms = function(room) {
    var record = new Array(room.length);
    for (let i = 0; i < record.length; i++) {
        record[i] = new Array(room[0].length);
        for (let j = 0; j < record[0].length; j++)
            record[i][j] = new Set();
    }
    var dir = [0, 1, 0, -1, 0];
    var x = 0, y = 0, index = 0, res = 0;
    while (!record[x][y].has(index % 4)){
        record[x][y].add(index % 4)
        var newX = x + dir[index % 4], newY = y + dir[index % 4 + 1];
        var times = 0;
        while ((newX < 0 || newX >= room.length || newY < 0 || newY >= room[0].length || room[newX][newY] == 1) && times < 4) {
            index++;
            times++;
            newX = newX = x + dir[index % 4];
            newY = y + dir[index % 4 + 1];
        }
        if (times > 3) break;
        x = newX;
        y = newY;
    }
    for (let i = 0; i < record.length; i++) {
        for (let j = 0; j < record[0].length; j++) {
            if (record[i][j].size != 0)
                res++;            
        }        
    }
    return res;
};