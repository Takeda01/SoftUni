function validate() {
    let text = document.getElementById('email');
    text.addEventListener('change', (event) => {
        let email = event.target.value;
        let pattern = /[A-Za-z0_9]+@[A-Za-z0_9]+\.[A-Za-z]+/g
        if (pattern.test(email)) {
            event.target.classList.remove("error")
        }
        else{
            event.target.classList.add("error")
        }
    });
}