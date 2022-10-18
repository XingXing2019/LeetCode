/**
 * @param {number[]} students
 * @param {number[]} sandwiches
 * @return {number}
 */
var countStudents = function(students, sandwiches) {
    var one = 0, zero = 0
    for (let i = 0; i < students.length; i++) {
        if (students[i] == 0)
            zero++
        else
            one++        
    }
    while (sandwiches.length != 0) {
        if (students[0] == sandwiches[0]) {
            students.shift()
            var s = sandwiches.shift()
            if (s == 0)
                zero--
            else
                one--
        } else {
            if (sandwiches[0] == 0 && zero == 0 || sandwiches[0] == 1 && one == 0)
                return sandwiches.length
            students.push(students.shift())
        }
    }
    return 0
}