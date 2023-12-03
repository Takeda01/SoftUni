function subtract() {
    let a = document.getElementById("firstNumber").value
    let b = document.getElementById("secondNumber").value
    let result =  Number(b) - Number(a)
    document.getElementById("result").innerText = -result;
}