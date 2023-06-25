async function attachEvents() {
  document.getElementById("refresh").addEventListener(`click`, GetAllMsg);
  document.getElementById("submit").addEventListener(`click`, onSend);

  function onSend() {
    const author = document.getElementsByName("author");
    const content = document.getElementsByName("content");

    const body = {
      author: author.value,
      content: content.value,
    };
     author.value = ""
     content.value = ""
    CreateMsg(body);
  }
}

function RenderData(data) {
  const textarea = document.getElementById("messages");

  const c = Object.values(data)
    .map((entry) => `${entry.author}: ${entry.content}`)
    .join(`\n`);
  textarea.textContent = c;
}
async function GetAllMsg() {
  const url = `http://localhost:3030/jsonstore/messenger`;
  const response = await fetch(url);
  const data = await response.json();

  RenderData(data);
}

async function CreateMsg(body) {
  const url = `http://localhost:3030/jsonstore/messenger`;
  const response = await fetch(url, {
    method: "POST",
    headers: {
      "Content-type": "application/json",
    },

    body: JSON.stringify(body),
  });

  const data = await response.json();

GetAllMsg()
}
attachEvents();
