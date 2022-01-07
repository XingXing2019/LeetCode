function ListNode(val, next) {
  this.val = val === undefined ? 0 : val
  this.next = next === undefined ? null : next
}
/**
 * @param {ListNode} head
 */
var Solution = function (head) {
    Solution.prototype.head = head
}

/**
 * @return {number}
 */
Solution.prototype.getRandom = function () {
    var count = 0, res = 0
    var pointer = this.head
    while (pointer != null) {
        count++;
        if (parseInt(Math.random() * count) === 0)
            res = pointer.val
        pointer = pointer.next
    }
    return res
}
