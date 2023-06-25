function Rotate(array,times){
    for (let index = 0; index < times; index++) {
      let a = array[array.length - 1]
       array.unshift(a)
       array.pop()
    }
return console.log(array.join(' '));
}
