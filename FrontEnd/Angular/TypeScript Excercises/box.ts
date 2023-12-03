class Box<T>{
    private arr: T[] = [];
add(a: T){
this.arr.push(a)
}

remove(){
this.arr.pop()
}

get count() : number{
    return this.arr.length
}
   
}

let box = new Box<String>();
box.add("Pesho");
box.add("Gosho");
console.log(box.count);
box.remove();
console.log(box.count);