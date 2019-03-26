'use strict';

// DOM document object model

// HTML is the serialized format of the DOM.

// (function() {
//     let textPara = document.getElementById('text');
//     console.log(textPara);
// })();

// really the way we do it is register event handlers.

// for right when the page starts...

// "on<event>" properties that we can assign functions to.
// when the event happens, they will run.
// this is for the "load" event on the window object.
window.onload = () => {
    let textPara = document.getElementById('text');
    console.log(textPara);
    console.log('this runs second');

};

console.log('this runs first');

// we have a better way to register event handlers
// better, because it allows more than one at a time.

window.addEventListener('load', () => {
    let textPara = document.getElementById('text');

    // change the contents of the element
    textPara.innerHTML = '<em>text</em>';
});

// "load" event fires pretty late... after all images and
// scripts/styles have finished downloading.

// usually we can use this event instead
document.addEventListener('DOMContentLoaded', () => {
    let textPara = document.getElementById('text');
    textPara.innerHTML += 'text 2';
    // this one ran first...
});

document.addEventListener('DOMContentLoaded', () => {
    let textPara = document.getElementById('text');
    let input = document.getElementById('input');

    let list = 
    let button = document.getElementsByTagName('button')[0];

    let count = 0;

    button.addEventListener('click', () => {
        count++;
        textPara.innerHTML = `text ${count}`;
        if (count === 10) {
            location.href = "http://google.com";
            // that's how we navigate to new pages
            // (i.e. tell the browser to make GET request)
        }
        if (input.value === 'google') {
            location.href = "http://google.com"
        }
    });

    // we can use CSS selector syntax with this function
    let table = document.querySelector('table');
    let row1 = table.tBodies[0].rows[0];
    let cellA = table.tBodies[0].rows[0].cells[0];

    row1.addEventListener('click', event => {
        // stop the event from bubbling out any further.
        // bad practice! can throw you off guard
        event.stopPropagation();
        // stops even other event listeners on this
        // same element right here.
        event.stopImmediatePropagation();
        printEventDetails(event);
    });
    cellA.addEventListener('click', event => {
        printEventDetails(event);
    });
});

// in the old days, some browsers propagated events in the
// opposite order. these days, all browsers support both, but
// default to "bubbling mode"

// bubbling mode is: event runs FIRST on the most deeply
// nested element, LAST on the whole document.
// capturing mode is the opposite.

function printEventDetails(event) {
    console.log(event);
    console.log(`type: ${event.type}`);
    console.log(`target: ${event.target}`);
    console.log(`currentTarget: ${event.currentTarget}`);
    console.log(`this ${this}`);
    console.log('');

}



