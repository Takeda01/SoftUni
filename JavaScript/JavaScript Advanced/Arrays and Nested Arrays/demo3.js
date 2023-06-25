function AddRemove(array){
    let ar =[];
for(let i = 0; i < array.length;i++){
    if(array[i] == 'add'){
        ar.push(i + 1);

    }
    else if(array[i] == 'remove' ){

        ar.pop()


    }
}
if(ar.length == 0){
    return`Empty`;
}
return console.log(ar.join(`\n`))
}

