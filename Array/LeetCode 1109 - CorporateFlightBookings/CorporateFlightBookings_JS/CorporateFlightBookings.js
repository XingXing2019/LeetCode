/**
 * @param {number[][]} bookings
 * @param {number} n
 * @return {number[]}
 */
var corpFlightBookings = function (bookings, n) {
    var flights = [];
    for (let i = 0; i < n; i++)
        flights.push(0);
    bookings.forEach(x => {
        flights[x[0] - 1] += x[2];
        if (x[1] < n)
            flights[x[1]] -= x[2];
    });
    var res = [];
    var seats = 0;
    for (let i = 0; i < n; i++) {
        if (flights[i])
            seats += flights[i];
        res[i] = seats;
    }
    return res;
};