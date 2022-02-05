function ListNode(val, next) {
  this.val = val === undefined ? 0 : val
  this.next = next === undefined ? null : next
}
var mergeKLists = function (lists) {
    var nodes = []
    lists.forEach(list => {
        while (list) {
            nodes.push(list)
            list = list.next
        }
    })
    nodes.sort((a, b) => { return a.val - b.val })
    var dummy = new ListNode(), point = dummy
    nodes.forEach(node => {
        point.next = node
        point = point.next
    })
    return dummy.next
}
