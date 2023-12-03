function func(athlete){
    if(athlete.dizziness === true){
        let neededhydration = athlete.weight / 10 * athlete.experience
        athlete.levelOfHydrated += neededhydration
        athlete.dizziness = false
    }
    return athlete
}