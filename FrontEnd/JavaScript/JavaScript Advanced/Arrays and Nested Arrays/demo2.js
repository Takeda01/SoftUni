function Steps(array, number){
    let a =[];
for (let index = 0; index < array.length; index+=number) {
    a.push(array[index]);
}
return a;


}


