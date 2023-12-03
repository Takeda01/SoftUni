function calc(fruit,grams,price){
    let k = grams / 1000;
    let a = k * price;
    console.log(`I need $${a.toFixed(2)} to buy ${k.toFixed(2)} kilograms ${fruit}.`)

}
