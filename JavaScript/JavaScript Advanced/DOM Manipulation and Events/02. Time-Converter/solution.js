function attachEventsListeners() {

let d = document.getElementById(`days`)
let h = document.getElementById(`hours`)
let m = document.getElementById(`minutes`)
let s = document.getElementById(`seconds`)

let days = document.getElementById(`daysBtn`)
let hours = document.getElementById(`hoursBtn`)
let minutes = document.getElementById(`minutesBtn`)
let seconds = document.getElementById(`secondsBtn`)

days.addEventListener(`click`, function(event){
    h.value = d.value * 24
    m.value = h.value * 60
    s.value = m.value * 60
})

hours.addEventListener(`click`, function(event){
    d.value = h.value / 24
    m.value = h.value * 60
    s.value = m.value * 60
})

minutes.addEventListener(`click`, function(event){
    d.value = h.value / 24
    h.value = m.value / 60
    s.value = m.value * 60

})

seconds.addEventListener(`click`,function(event){
    m.value = s.value / 60
    h.value = m.value / 60
    d.value = h.value / 24
})



}
