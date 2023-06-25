function func(car){
    function EngineList(enginePower) {
        if (enginePower > 120){
            return { power: 200, volume: 3500 }
        }
        else if (enginePower > 90){
            return { power: 120, volume: 2400 }
        }
        else {
            return { power: 90, volume: 1800 }
        }
    }

    let wheels = new Array(4);
    if(car.wheelsize % 2 == 0 ){
        wheels.fill(car.wheelsize - 1, 0,4)       
    }
    else{
     wheels.fill(car.wheelsize, 0,4)
    }
 
    let newcar = {
        model: car.model,
        enjine: EngineList(Number(car.power)),
        carriage: {type: car.carriage, color: car.color},
        wheels

    }

    return newcar;
}
