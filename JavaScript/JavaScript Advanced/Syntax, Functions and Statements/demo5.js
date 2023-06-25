function calc(steps,footprint,speed){
    let speedInMeters = speed * 1000;
    let distance = steps * footprint;
    let time = distance / speedInMeters * 3600;
    let rest = Math.floor(distance / 500) * 60;
    let allTime = time + rest;
    let hours = Math.floor(allTime / 3600).toString();
    let mins = Math.floor(allTime / 60).toString();
    let secs = Math.ceil(allTime % 60).toString();

    console.log(`${hours.padStart(2, '0')}:${mins.padStart(2, '0')}:${secs.padStart(2, '0')}`)
}