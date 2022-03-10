function ListNode(val, next) {
  this.val = val === undefined ? 0 : val
  this.next = next === undefined ? null : next
}

/**
 * @param {ListNode} head
 * @return {boolean}
 */
var isPalindrome = function (head) {    
    var point = head
    var reversed = null
    while (point) {
        reversed = new ListNode(point.val, reversed)
        point = point.next
    }
    while (head != null) {
        if (reversed.val != head.val)
            return false
        reversed = reversed.next
        head = head.next
    }
    return true
}

