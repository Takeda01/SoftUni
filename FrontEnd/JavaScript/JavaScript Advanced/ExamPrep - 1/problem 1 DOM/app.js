function solve(){
  let author = document.getElementById("creator")
  let title = document.getElementById("title")
  let category = document.getElementById("category")
  let content = document.getElementById("content")
  let section = document.querySelector(`main section`)
  document.querySelector("form button").addEventListener("click", creatAr)
  
  function GetValues(author,title,category,content){
   let authorValue = author.value;
   let titleValue = title.value;
   let categoryValue = category.value;
   let contentValue = content.value;

 createDOMelements(authorValue,titleValue,categoryValue,contentValue)
  
 function createDOMelements(authorValue,titleValue,categoryValue,contentValue){
   

   let StrongAuthor = document.createElement("strong");
   let Strongcategory = document.createElement("strong");
   StrongAuthor.textContent = authorValue
   Strongcategory.textContent = categoryValue

   let article = document.createElement("article");
   let heading = document.createElement("h1");
   let cat = document.createElement("p");
   let creator = document.createElement("p");
   let text = document.createElement("p");

   heading.textContent = titleValue
   cat.textContent+= `Category: `
   cat.appendChild(Strongcategory)
   creator.textContent += `Creator: `
   creator.appendChild(StrongAuthor)
   text.textContent = contentValue

   article.appendChild(heading)
   article.appendChild(cat)
   article.appendChild(creator)
   article.appendChild(text)

   let div = document.createElement("div")
   div.setAttribute(`class`, `buttons`)

   let deletebut = document.createElement("button")
   let archivebut = document.createElement("button")
   deletebut.classList.add("btn")
   deletebut.classList.add("delete")
   deletebut.textContent = `Delete`


   archivebut.classList.add("btn")
   archivebut.classList.add("archive")
   archivebut.textContent = `Archive`

   archivebut.addEventListener(`click`,archive)
   deletebut.addEventListener(`click`,Delete)

   div.appendChild(deletebut)
   div.appendChild(archivebut)

   article.appendChild(div)
   section.appendChild(article)
   


 

   
  
   
  }
}

  function archive(e){
    let div = e.target.parentElement
    let article = div.parentElement
    let articlecontent = article.children

    let titleValue = articlecontent[0].textContent

   let list = document.getElementsByTagName(`ol`)[0]

   let li = document.createElement(`li`)

   li.textContent = titleValue

   list.appendChild(li)
   article.remove()
   

  }

  function Delete(e){
    let div = e.target.parentElement
    let article = div.parentElement
    article.remove()
   
  }

  function creatAr(e){
    e.preventDefault();


   GetValues(author,title,category,content)
   ClearInputFields()
   
 

  }

  function ClearInputFields(){
   author.value = ""
   title.value = ""
   content.value = ""
   category.value = ""
  }


  }
