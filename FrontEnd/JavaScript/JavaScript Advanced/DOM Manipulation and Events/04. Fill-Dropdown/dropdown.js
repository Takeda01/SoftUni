function addItem() {
let op = document.createElement(`option`)
let text = document.getElementById(`newItemText`).value
let value = document.getElementById(`newItemValue`).value
let men = document.getElementById(`menu`)
op.textContent = text
op.value = value
men.appendChild(op)
document.getElementById(`newItemText`).value = "";
document.getElementById(`newItemValue`).value = "";
}
