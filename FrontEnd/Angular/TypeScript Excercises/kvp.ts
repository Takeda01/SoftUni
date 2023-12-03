class KeyValuePair<T,U>{
    private key: T;
    private value: U;

    setKeyValue(a: T, b: U){
        this.key = a;
        this.value = b
    }

    display(){
        console.log("key:" +this.key)
        console.log("value:" +this.value)
        
    }

    

}


let kvp = new KeyValuePair<number, string>();
kvp.setKeyValue(1, "Steve");
kvp.display();

    
