function ListNode(val, next) {
  this.val = val === undefined ? 0 : val
  this.next = next === undefined ? null : next
}
/**
 * @param {ListNode} list1
 * @param {ListNode} list2
 * @return {ListNode}
 */
var mergeTwoLists = function (list1, list2) {
    var dummy = new ListNode(), point = dummy
    while (list1 && list2) {
        if (list1.val < list2.val) {
            point.next = list1
            list1 = list1.next
        } else {
            point.next = list2
            list2 = list2.next
        }
        point = point.next
    }
    point.next = list1 ? list1 : list2
    return dummy.next
}
