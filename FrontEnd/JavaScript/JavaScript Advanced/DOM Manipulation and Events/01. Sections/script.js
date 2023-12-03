function create(words) {
   let container = document.getElementById("content")
   for (let word of words) {
   let div = document.createElement(`div`)
   let p = document.createElement(`p`)
 
   p.textContent = word;
   p.style.display = `none`;
   
   div.appendChild(p);
   container.appendChild(div)
   div.addEventListener(`click`, function (event) {
      p.style.display = `block`;
   })

      
   }
  
 
   
 
}