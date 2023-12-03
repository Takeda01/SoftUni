import { html, render } from "./node_modules/lit-html/lit-html.js"
const container = document.querySelector("#menu")
const form = document.querySelector("form")
form.addEventListener(`submit`, OnSunmit)


const url = "http://localhost:3030/jsonstore/advanced/dropdown"
LoadData()
function OnSunmit(){
    let v = document.querySelector("#itemText").value
    addItem(v)
}
async function addItem(data) {
   

    const response = await fetch(url,{
        method: "POST",
        headers: {
            "Content-Type": "Application/json"
        },
        body:JSON.stringify({text: data})

    })
    LoadData()

}

async function LoadData(){
    
    const response = await fetch(url)
    const data = await response.json()

    const result = Object.values(data).map(x => createOptionTemplate(x))

    render(result,container)
  
}
function createOptionTemplate(x){
    return html`<option value = ${x._id}>${x.text}</option>`
}

