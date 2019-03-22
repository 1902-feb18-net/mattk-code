'use strict';

// JS is object-oriented or object-based
// though it lacks classes at least in ES5
// however it does have inheritance!
// in JS objects can inherit directly from other concrete
// objects
// it's called "prototypal inheritance"

var obj = {
    a: '5',
    b: '3'
};
obj.c = 3;
obj.sayName = function () {
    console.log('Bob');
}

obj.sayName();

var studentLiteral = {
    name: 'Nick',
    age: 26,
    sayName: function () {
        console.log(this.name);
    },
    sayNameArrow: () => {
        console.log(this.name);
    }
}

// in JS, "this" works in a special way.
// when you call a function, it is "set" to the
// object what was to the left of the dot when you called the
// function.

// there is an exception to that for ES6 arrow functions.
// with "this" in arrow functions, it is set when the 
// function is written, and does not change.

studentLiteral.sayName();

var func = studentLiteral.sayName;
obj.func = func;
obj.name = 'Bill';

obj.func();

// obj.arrowFunc = studentLiteral.sayNameArrow;
// arrowFunc();

// we can make new objects from a template using, not class,
// but just constructor.
// and by constructor, we just mean a function.

function Student(name, age, gpa) {
    this.name = name;
    this.age = age;
    this.gpa = gpa;
    this.sayName = function () {
        console.log(this.name);
    }
}

let student = new Student('Nick', 26, 3.0);
student.sayName();

// like i said, we have inheritance in C#

function StudentWithBirthday(name, age, gpa, birthday) {
    this.__proto__ = new Student(name, age, gpa);
    this.birthday = birthday;
    this.checkBirthday = function (date) {
        if (date === birthday) {
            console.log('Happy birthday');
        }
    }
}

// in JS, we can set the prototype of an object with the
// special property __proto__.

let studentB = new StudentWithBirthday('Nick', 26, 3.0, 'yesterday');

studentB.checkBirthday('yesterday');
studentB.sayName();

console.log(studentB);

// in JS, property access falls back to looking at the
// prototype if the property is not found on the current
// object (and so and so on)

// in ES6, classes were added as syntactic sugar around
// prototypal inheritance.

function StudentClass(name, age, gpa) {
    let otherprop = 3;


    constructor(name, age, gpa) {
        this.name = name;
        this.age = age;
        this.gpa = gpa;
    }
    

    sayName() {
        console.log(this.name);
    }
}

let student2 = new StudentClass('Nick', 26, 3.0);
student2.sayName();

// like i said, we have inheritance in C#

function StudentWithBirthdayClass(name, age, gpa, birthday) {
    this.__proto__ = new Student(name, age, gpa);
    this.birthday = birthday;
    this.checkBirthday = function (date) {
        if (date === this.birthday) {
            console.log('Happy birthday');
        }
    }
}

// in JS, we can set the prototype of an object with the
// special property __proto__.

let studentBa = new StudentWithBirthdayClass('Nick', 26, 3.0, 'yesterday');

studentBa.checkBirthday('yesterday');
studentBa.sayName();

console.log(studentBa);

// in JS, property access falls back to looking at the
// prototype if the property is not found on the current
// object (and so and so on)

// in ES6, classes were added as syntactic sugar around
// prototypal inheritance.



