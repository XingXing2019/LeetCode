class Node {
    constructor() {
        this.isWord = false
        this.children = new Array(26)
    }
}

var WordDictionary = function() {
    WordDictionary.prototype.root = new Node()
    WordDictionary.prototype.a = 'a'.charCodeAt(0)
};

/** 
 * @param {string} word
 * @return {void}
 */
WordDictionary.prototype.addWord = function(word) {
    var point = this.root
    for (let i = 0; i < word.length; i++) {
        var letter = word.charCodeAt(i) - this.a
        if (!point.children[letter])
            point.children[letter] = new Node()
        point = point.children[letter]
    }
    point.isWord = true
};

/** 
 * @param {string} word
 * @return {boolean}
 */
WordDictionary.prototype.search = function(word) {
    var point = this.root
    return this.dfs(point, word, 0)
};

WordDictionary.prototype.dfs = function (point, word, index) {
    if (!point) return false
    if (index == word.length) return point.isWord
    if (word[index] != '.') {
        var letter = word.charCodeAt(index) - this.a
        return this.dfs(point.children[letter], word, index + 1)
    }
    for (let i = 0; i < point.children.length; i++) {
        if (this.dfs(point.children[i], word, index + 1))
            return true        
    }
    return false
}