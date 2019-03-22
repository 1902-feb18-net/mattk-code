'use strict';

// callback functions

// similar to delegate/func/etc in C#,
// we can write code that accepts other code as parameter
// in order to either
// 1. provide some polymorphism / extensibility to code.
//  (give the caller some input on what will be done)
// 2. for asynchronous stuff - caller says what code to
//  run WHEN the result is finally ready.

// without callbacks
// function add(a, b) {
//     let result = a + b;
//     return result;
// }
// console.log(add(1, 3));

// // with callbacks         callback function
// //                          vvv
// function multiply(a, b, onSuccess) {
//     let result = a + b;
//     return onSuccess(result);
// }
// multiply(2, 3, console.log);


// func(params, result => {
//     func(result, result2 => {
//         // nested callbacks are a common occurrence in JS.
//     });
// });

// common thing to do e.g.
// register an event handler on some HTML element and its event

// javascript has closure
// javascript functions "close over" their environment

// 

function newCounter() {
    let x = 0;
    return function() {
        return x++;
    };
}

let counter1 = newCounter();
console.log(counter1());
console.log(counter1());
console.log(counter1());

let counter2 = newCounter();
console.log(counter2());
console.log(counter2());

// it's really a conecpt from computer science .. as
// programmers, we are very loose about the meaning of
// closure

// closure gives us public versus private to an extent in the
// absence of access modifiers

// in JS, all these <script> contents are basically
// concatenated
// we really try to avoid putting things in global scope.

// there is a technique called "IIFE"
// immediately invoked function expression

// we can use this to hide our variables from the global scope
// and yet run immediately
(function () {

})();

let library = (function () {
    let privateData = 0;

    function privateFunction(x) {
        return privateData;
    }

    return {
        libraryMethod() {
            return privateFunction() +
            privateData;
        }
    }
})();

// only libraryMethod is visible to anyone
console.log(library);

// with ES6 we have modules
// a file can be a module, and if it is,
// it gets its own global scope
// and only what is explicitly exported
// and then explicitly imported by other files
// can be seen in those other files.

// ES6 features... https://es6-features.org
// block scope (let, const)
// arrow functions
// method syntax
// default parameters

// function add(a = 1, b = 2) {

// }

// string interpolation (template literals)
//  `${}`
// classes with class inheritance (extends)
// symbol type
// many added useful buildin functions
//  like on string
// es6 modules
// Set and Map objects
// for of loop (like foreach in C#)
// get/set properties

// get name() {
//  return this._name.toUpperCase();
//}

// internationalization features
// spread / destructuring
// Promises (a way to do asynchronous stuff)


