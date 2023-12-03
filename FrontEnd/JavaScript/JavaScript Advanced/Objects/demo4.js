function func(data) {
    let result = []

    for (const iterator of data) {
        let[name,level,items] = iterator.split(` / `)
        level = Number(level)
        items = items ?  items.split(`, `):[]

        let obj = {
            name,
            level,
            items
        }
        result.push(obj)
    }
    return console.log(JSON.stringify(result));
}