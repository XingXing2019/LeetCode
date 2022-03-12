function Node(val, next, random) {
  this.val = val
  this.next = next
  this.random = random
}

/**
 * @param {Node} head
 * @return {Node}
 */
var copyRandomList = function (head) {
    if (!head) return null
    var map = new Map()
    var point = head
    map.set(point, new Node(point.val))
    while (point) {
        var next = point.next
        if (next != null && !map.has(point.next))
            map.set(next, new Node(next.val))
        var random = point.random
        if (random && !map.has(random))
            map.set(random, new Node(random.val))
        point = point.next
    }
    point = head
    while (point) {
        var copy = map.get(point)
        copy.next = map.has(point.next) ? map.get(point.next) : null
        copy.random = map.has(point.random) ? map.get(point.random) : null
        point = point.next
    }
    return map.get(head)
}
