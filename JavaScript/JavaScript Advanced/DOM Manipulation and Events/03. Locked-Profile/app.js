function lockedProfile() {
    let btns = document.getElementsByTagName(`button`);
        for (const btn of btns) {
            btn.addEventListener(`click`, function (){
            let parent = btn.parentElement;
            let unlocked = parent.children.item(4)
            let hiddenInfo = parent.children.item(9)
                if (unlocked.checked === true){
                    if (btn.textContent === `Show more`){
                    hiddenInfo.style.display = `block`;
                    btn.textContent = `Hide it`
                    }
                    else if (btn.textContent === `Hide it`){
                    hiddenInfo.style.display = `none`;
                    btn.textContent = `Show more`
                    }
                }
                else{
                    if (btn.textContent === `Hide it`){
                        btn.disabled = false;
                    }
                    return;
                }
            });
        }
    }