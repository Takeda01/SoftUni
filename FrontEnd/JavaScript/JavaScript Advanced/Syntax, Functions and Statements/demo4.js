    function PreviousDate(year,month,day){
        let a = new Date(year,month -1,day -1)
        let b = `${a.getFullYear()}-${a.getMonth() + 1}-${a.getDate()}`
        console.log(b)

    }
   