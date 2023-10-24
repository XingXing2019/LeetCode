/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} root
 * @return {number[]}
 */
var largestValues = function(root) {
    var res = []
    if (!root)
        return res
    var queue = [root]
    while (queue.length != 0) {
        var count = queue.length
        var max = -Number.MAX_VALUE
        for (let i = 0; i < count; i++) {
            var cur = queue.shift()
            max = Math.max(max, cur.val)
            if (cur.left) queue.push(cur.left)
            if (cur.right) queue.push(cur.right)
        }
        res.push(max)
    }
    return res
}