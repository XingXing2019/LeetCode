/**
 * @param {string} text
 * @return {string}
 */
var reorderSpaces = function (text) {
    var words = []
    var space = 0;
    var word = ''
    for (let i = 0; i < text.length; i++) {
        if (text[i] == ' ') {
            space++;
            if (word === '') continue
            words.push(word)
            word = ''
        }            
        else
            word += text[i]        
    }
    if (word != '') words.push(word)
    var count = ~~(space / (words.length - 1))
    var res = ''
    for (let i = 0; i < words.length; i++) {
        res += words[i]
        if (i == words.length - 1) continue
        res += ' '.repeat(count)
        space -= count        
    }
    return res + ' '.repeat(space)
}