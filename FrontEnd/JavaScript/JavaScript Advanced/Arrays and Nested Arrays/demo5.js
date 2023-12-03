function Numbers(array){
    let biggest = array[0]
    let bigones = [];
    for (let index = 0; index < array.length; index++) {
      
        if(array[index] >= biggest){
            biggest = array[index]
            bigones.push(biggest);
        }
    }
    return bigones;
}


