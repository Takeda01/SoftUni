import { render, html } from "./node_modules/lit-html//lit-html.js"

document.getElementById("btnLoadTowns").addEventListener(`click`, Adder)

function Adder(e){
    e.preventDefault();
const container = document.getElementById("root")
let form = document.getElementsByTagName(`form`)[0];
let towns = (form.querySelector(`input`).value).split(", ");




    

    const ul =  html`
    <ul>
    ${towns.map(town => html`<li>${town}</li>` )}
    </ul>
    `;
    render(ul,container)

}





