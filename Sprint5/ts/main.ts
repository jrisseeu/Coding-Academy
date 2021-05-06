export {}
let message = 'Hello World - Welcome back, good to see you';
console.log(message);


let x = 10;
const y = 20;

let sum;
const title = 'Code Academy';

let isBeginner: boolean = true;
let total: number = 0;
let name: string = 'Riseeuw';

let sentence: string = `My name is ${name}
I am a beginner in Typescript`;
console.log(sentence);

//sub types
let n: null = null;
let u: undefined = undefined;

let isNew: boolean = null;
let myName: string = undefined;

//both the same
let list1: number[] = [1,2,3];
let list2: Array<number> = [1,2,3];


let person1: [string, number] = ['Chris', 22];

enum Color {Red = 5, Green, Blue};
let c: Color = Color.Green;
console.log(c);

//allows to reassign values and any type can be created
let randomValue: any = 10;
randomValue = true;
randomValue = 'Risseeuw';
//Unkown like any but you cannot access any properties of the unknown type
let myVariable: unknown = 10;
function hasName(obj: any): obj is {name: string} {
    return !!obj && typeof obj === "object" && "name" in obj
}



//anything since not intitialized
let a;
a = 10;
a = true;

//Can be either
let multiType: number | boolean;
multiType = 20;
multiType = true;


//Functions in TypeScript

//num2? == optional
//if want the vavlue to be defaulted if not passed in do: num2: number = 10
//or constant let xss: number = 10;
let xss: number = 10;
function add(num1: number, num2: number = xss) :number{
    if (num2)
        return num1 + num2;
    else
        return num1;
}
add(5,10);
add(5);

console.log(add(5));


//Interfaces

interface Person {
    firstName: string;
    lastName: string;
}

function fullName(person: Person){
    console.log(`${person.firstName} ${person.lastName}`);
}

//Object
let p = {
    firstName: 'Jeff',
    lastName: 'Risseeuw'
};


class Employee {
    public employeeName: string;

    constructor(name: string){
        this.employeeName = name;
    }

    greet() {
        console.log(`Good Morning ${this.employeeName}`);
    }
}

let emp1 = new Employee('Jeff Risseeuw');
console.log(emp1.employeeName);
emp1.greet();


//inheritance 
class Manager extends Employee {
    constructor(managerName: string) {
        super(managerName);
    }
    delegateWork() {
        console.log(`Manager delegating tasks`);
    }
}

let m1 = new Manager('Jeffro');
m1.delegateWork();
m1.greet;
console.log(m1.employeeName);

//Access Modifiers
//private - only within the class
//public - free to all
//protected - only within the class and derived classed


