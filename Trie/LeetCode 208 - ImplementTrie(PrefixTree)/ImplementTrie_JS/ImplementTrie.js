class Node {
    constructor() {
        this.isWord = false
        this.children = new Array(26)
    }
}

var Trie = function () {
    Trie.prototype.root = new Node()
    Trie.prototype.a = 'a'.charCodeAt(0)
};

/**
 * @param {string} word
 * @return {void}
 */
Trie.prototype.insert = function (word) {
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
Trie.prototype.search = function (word) {
    var point = this.root
    for (let i = 0; i < word.length; i++) {
        var letter = word.charCodeAt(i) - this.a
        if (!point.children[letter])
            return false
        point = point.children[letter]        
    }
    return point.isWord
};

/**
 * @param {string} prefix
 * @return {boolean}
 */
Trie.prototype.startsWith = function (prefix) {
    var point = this.root
    for (let i = 0; i < prefix.length; i++) {
        var letter = prefix.charCodeAt(i) - this.a
        if (!point.children[letter])
            return false
        point = point.children[letter]        
    }
    return true
};
