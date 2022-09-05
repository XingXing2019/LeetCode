function Node(val, children) {
  this.val = val
  this.children = children
}

var levelOrder = function (root) {
    var res = []
    if (!root) return res
    var queue = []
    queue.push(root)
    while (queue.length != 0) {
        var count = queue.length
        var temp = []
        for (let i = 0; i < count; i++) {
            var cur = queue.shift();
            temp.push(cur.val)
            cur.children.forEach(x => {
                if (x) queue.push(x)
            })
        }
        res.push(temp)
    }
    return res
}
