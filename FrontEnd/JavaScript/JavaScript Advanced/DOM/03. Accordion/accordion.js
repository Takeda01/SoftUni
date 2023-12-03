function toggle() {
  let main = document.getElementsByClassName("button")[0] 
  
  let div = document.getElementById("extra");

  if(main.textContent === "More"){
    main.textContent = "Less"
    div.style.display = "block"
  }
  else {
  main.textContent = `More`;
  div.style.display = `none`;

  }
 
}