import {html, render} from "./node_modules/lit-html/lit-html.js"
import {cats} from "./catSeeder.js"



const container = document.querySelector(`#allCats`)

const ul =  html
`<ul>
${cats.map(cat => html `<li>
<img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
<div class="info">
<button class="showBtn">Show status code</button>
<div class="status" style="display: none" id="${cat.id}">
    <h4>${cat.statusCode}</h4>
    <p>${cat.statusMessage}</p>
</div>
</div>
</li>`)}
</ul>
  `
  render(ul,container)
let buttons = document.querySelectorAll(".showBtn")
buttons.forEach(e => e.addEventListener(`click`,onClick))
function onClick(e){

let target = e.target
 let div = target.parentElement
 let toreveal = div.children[1]
 
 toreveal.style.display = `block`
 target.textContent = `Hide status code`

 

}

