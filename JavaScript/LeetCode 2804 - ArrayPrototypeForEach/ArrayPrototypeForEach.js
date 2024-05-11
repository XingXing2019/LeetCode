/**
 * @param {Function} callback
 * @param {Context} context
 */
Array.prototype.forEach = function(callback, context) {
    for (let i = 0; i < this.length; i++) {
        if (Object.hasOwn(this, i)) {
            callback.apply(context, [this[i], i, this])
        }        
    }
}
