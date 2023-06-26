class Ticket{
    destination: string;
    price: number;
    status: string;

     constructor(destination: string, price: number, status: string) {
    this.destination = destination;
    this.price = price;
    this.status = status;
  }
}

function Tickets(tickets: string[], sorting:string){
    const boletos: Ticket[] = [];
    for (let index = 0; index < tickets.length; index++) {
       const [destination,price,status] = tickets[index].split('|');
       const ticket = new Ticket(destination, Number(price), status);
       boletos.push(ticket);
        
    }

    switch (sorting) {
        case 'destination':
            boletos.sort((a, b) => a.destination.localeCompare(b.destination));
          break;
        case 'price':
            boletos.sort((a, b) => a.price - b.price);
          break;
        case 'status':
            boletos.sort((a, b) => a.status.localeCompare(b.status));
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
    ],
    'destination'))