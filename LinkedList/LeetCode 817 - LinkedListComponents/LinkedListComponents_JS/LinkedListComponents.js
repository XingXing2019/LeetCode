function ListNode(val, next) {
    this.val = (val===undefined ? 0 : val)
    this.next = (next===undefined ? null : next)
}

/**
 * @param {ListNode} head
 * @param {number[]} nums
 * @return {number}
 */
var numComponents = function(head, nums) {
    var set = new Set(nums)    
    var res = 0;
    while (head) {
        if (set.has(head.val)) res++
        while (head && set.has(head.val))
            head = head.next
        if (!head) continue
        head = head.next
    }
    return res
};