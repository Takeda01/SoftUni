class Garden {
    constructor(spaceAvailable){
        this.spaceAvailable = spaceAvailable
        this.plants =[]
        this.storage = []

    }

    addPlant (plantName, spaceRequired){
        if(this.spaceAvailable - spaceRequired <= 0){
            throw new  Error("Not enough space in the garden.")
        }

        this.plants.push({plantName,spaceRequired,ripe:false,quantity:0})
        this.spaceAvailable -= spaceRequired
       return `The ${plantName} has been successfully planted in the garden.`
    }

    ripenPlant(plantName, quantity){
        let currentPlant = this.plants.find(plant => plant.plantName === plantName)
        if(currentPlant === undefined || currentPlant === null){
            throw new Error(`There is no ${plantName} in the garden.`)
        }

        else if(currentPlant.ripe === true){
            throw new Error(`The ${plantName} is already ripe.`)
        }
        else if(quantity <= 0){
            throw new Error(`The quantity cannot be zero or negative.`)

        }

        currentPlant.ripe = true
        currentPlant.quantity += quantity
        if (quantity == 1) {
          return `${quantity} ${plantName} has successfully ripened.`;
        }
        return `${quantity} ${plantName}s have successfully ripened.`;

    }


    harvestPlant(plantName) {
        let currentPlant = this.plants.find(plant => plant.plantName === plantName)
        if(currentPlant === undefined || currentPlant === null){
            throw new Error(`There is no ${plantName} in the garden.`)
        }


        if(currentPlant.ripe === false){
           throw new Error(`The ${plantName} cannot be harvested before it is ripe.`) 
        }
        let index = this.plants.indexOf(currentPlant)
        this.storage.push(currentPlant)
        this.plants.splice(index,1)
        this.spaceAvailable -= currentPlant.spaceRequired
        return `The ${plantName} has been successfully harvested.`
    }

    generateReport(){
        let buff = ""
        let InGarden = this.plants.sort((a,b) => a.plantName - b.plantName);
        let names = []
      
        for (const plant of InGarden) {
            names.push(plant.plantName)
        }

       
        buff+= `The garden has ${this.spaceAvailable} free space left.\n`
        buff+= "Plants in the garden:" + ` ` + `${names.join(", ")}\n`
        if(this.storage.length == 0){
            buff+= "Plants in storage: The storage is empty."
        }
        else{
            buff+= `Plants in storage:`+ `${this.storage.join(` `, x => x.plantName + ` ` + `(${x.quantity})`)} `
        }
    

       return buff
    }
}


const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 100));
console.log(myGarden.generateReport());
        
