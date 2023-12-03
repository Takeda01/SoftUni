


function Calc(num) {
    let sum =0;
    let a = false;
    let b = num.toString();
    for(let index = 0; index < b.length - 1; index++) {
       
        if(b[index] === b[index + 1]) {
            a = true;
           
        }
        else{
            a = false;
            break;
        }
    
    }
    for(let index = 0; index < b.length; index++) {

        sum += Number(b[index])
    }
        
        console.log(a)
        console.log(sum);   
}
    