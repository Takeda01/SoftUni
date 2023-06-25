function GCD(first, second) {
    let number = 0;
    for (let i = 0; i < 100; i++) {
        if (first % i == 0 && second % i == 0) {
            number = i;
        }
        
    }
    return number;
}
console.GCD(func(15,5));