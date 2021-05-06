"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
exports.__esModule = true;
var message = 'Hello World - Welcome back, good to see you';
console.log(message);
var x = 10;
var y = 20;
var sum;
var title = 'Code Academy';
var isBeginner = true;
var total = 0;
var name = 'Riseeuw';
var sentence = "My name is " + name + "\nI am a beginner in Typescript";
console.log(sentence);
//sub types
var n = null;
var u = undefined;
var isNew = null;
var myName = undefined;
//both the same
var list1 = [1, 2, 3];
var list2 = [1, 2, 3];
var person1 = ['Chris', 22];
var Color;
(function (Color) {
    Color[Color["Red"] = 5] = "Red";
    Color[Color["Green"] = 6] = "Green";
    Color[Color["Blue"] = 7] = "Blue";
})(Color || (Color = {}));
;
var c = Color.Green;
console.log(c);
//allows to reassign values and any type can be created
var randomValue = 10;
randomValue = true;
randomValue = 'Risseeuw';
//Unkown like any but you cannot access any properties of the unknown type
var myVariable = 10;
function hasName(obj) {
    return !!obj && typeof obj === "object" && "name" in obj;
}
//anything since not intitialized
var a;
a = 10;
a = true;
//Can be either
var multiType;
multiType = 20;
multiType = true;
//Functions in TypeScript
//num2? == optional
//if want the vavlue to be defaulted if not passed in do: num2: number = 10
//or constant let xss: number = 10;
var xss = 10;
function add(num1, num2) {
    if (num2 === void 0) { num2 = xss; }
    if (num2)
        return num1 + num2;
    else
        return num1;
}
add(5, 10);
add(5);
console.log(add(5));
function fullName(person) {
    console.log(person.firstName + " " + person.lastName);
}
//Object
var p = {
    firstName: 'Jeff',
    lastName: 'Risseeuw'
};
var Employee = /** @class */ (function () {
    function Employee(name) {
        this.employeeName = name;
    }
    Employee.prototype.greet = function () {
        console.log("Good Morning " + this.employeeName);
    };
    return Employee;
}());
var emp1 = new Employee('Jeff Risseeuw');
console.log(emp1.employeeName);
emp1.greet();
//inheritance 
var Manager = /** @class */ (function (_super) {
    __extends(Manager, _super);
    function Manager(managerName) {
        return _super.call(this, managerName) || this;
    }
    Manager.prototype.delegateWork = function () {
        console.log("Manager delegating tasks");
    };
    return Manager;
}(Employee));
var m1 = new Manager('Jeffro');
m1.delegateWork();
m1.greet;
console.log(m1.employeeName);
//Access Modifiers
//private - only within the class
//public - free to all
//protected - only within the class and derived classed
