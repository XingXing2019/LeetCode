function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}

var sortedArrayToBST = function (nums) {
  var dfs = function (nums, li, hi) {
    if (li > hi) return null
    var index = ~~((hi - li + 1) / 2) + li
    var root = new TreeNode(nums[index])
    root.left = dfs(nums, li, index - 1)
    root.right = dfs(nums, index + 1, hi)
    return root
  }
  return dfs(nums, 0, nums.length - 1)
}
