async function getInfo() {
    let element = document.getElementById("stopId")
    let value = element.value
    let  busesList = document.getElementById(`buses`)
    let StopName = document.getElementById(`stopName`)
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId.value}`
    try{
        busesList.innerHTML = ""
        value.value = ""
   
    const response = await fetch(url)
    const data = await response.json()

    Object.entries(data.buses).forEach(([busId,time]) => {
        let li = document.createElement(`li`);
        li.textContent = `Bus ${busId} arrives in ${time} minutes`
        busesList.appendChild(li);
    });

    StopName.textContent = data.name
}
catch(err){
    StopName.textContent = "Error"
}
}