var Ticket = /** @class */ (function () {
    function Ticket(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
    return Ticket;
}());
function Tickets(tickets, sorting) {
    var boletos = [];
    for (var index = 0; index < tickets.length; index++) {
        var _a = tickets[index].split('|'), destination = _a[0], price = _a[1], status_1 = _a[2];
        var ticket = new Ticket(destination, Number(price), status_1);
        boletos.push(ticket);
    }
    switch (sorting) {
        case 'destination':
            boletos.sort(function (a, b) { return a.destination.localeCompare(b.destination); });
            break;
        case 'price':
            boletos.sort(function (a, b) { return a.price - b.price; });
            break;
        case 'status':
            boletos.sort(function (a, b) { return a.status.localeCompare(b.status); });
            break;
        default:
            break;
    }
    return boletos;
}
console.log(Tickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
], 'destination'));
