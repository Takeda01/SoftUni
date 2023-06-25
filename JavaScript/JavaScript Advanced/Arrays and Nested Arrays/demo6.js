function SortedNames(array){
    array.sort()
    array.sort((a,b)=>a-b)
    for (let index = 1; index <= array.length; index++) {
        array[index - 1] = `${index}.` + `${array[index - 1]}`
        
    }
    return console.log(array.join(`\n`))
}

