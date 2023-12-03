abstract class Employee{
    name: string
    age: number
    tasks: string[]
    salary: number;


    constructor(name:string, age: number){
        this.name = name
        this.age = age
        this.salary = 0
        this.tasks = []
    }

    public work() : void{

const currTask = this.tasks.shift()
this.tasks.push(String(currTask));
console.log(this.name + currTask)

    }
public collectSallary() : void{

}
    public getSalary() : number{
return this.salary
    }
}

class Juniour extends Employee{

}