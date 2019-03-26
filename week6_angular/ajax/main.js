'use strict';

// AJAX (aka Ajax)
// Asynchronous JavaScript and Xml
// a set of tools / technique to send HTTP requests from
// JavaScript and process the results without the browser
// reloading the page.

// the traditional tool for the job is XMLHttpRequest object

document.addEventListener('DOMContentLoaded', () => {
    let jokeButton = document.getElementById('jokeButton');
    let jokePara = document.getElementById('jokePara');
    let cardButton = document.getElementById('cardButton');
    let input = document.getElementById('field');

    jokeButton.addEventListener('click', () => {
        let xhr = new XMLHttpRequest();

        xhr.addEventListener('readystatechange', () => {
            console.log(`ready state: ${xhr.readyState}`);
            if (xhr.readyState === 4) {
                // response is here
                if (xhr.status >= 200 && xhr.status < 300) {
                    // if successful...
                    let text = xhr.responseText;
                    let obj = JSON.parse(text);
                    console.log(obj);
                    let joke = obj.value.joke;
                    jokePara.textContent = joke;
                    console.log('success');
                } else {
                    jokePara.textContent = (xhr.statusText
                    === undefined) ? 'Error' : xhr.statusText;
                    console.log('failure');
                }
            }
        });
        console.log('added listener');
        xhr.open('get', 'http://api.icndb.com/jokes/random');

        xhr.send();
    });

    jokeBtnFetch.addEventListener('click', () => {
        // a promise is an object which represents
        // some value that we will eventually get or fail to
        // get. so a promise can "resolve" to success or
        // failure.

        fetch('http://api.icndb.com/jokes/random?escape=javascript')
        .then(response => response.json())
        .then(obj => {
            jokePara.textContent = obj.value.joke;
        })
        .catch(error => console.log(error));
    });

    // cardBtnFetch.addEventListener('click', () => {
    //     // a promise is an object which represents
    //     // some value that we will eventually get or fail to
    //     // get. so a promise can "resolve" to success or
    //     // failure.

    //     fetch('https://api.scryfall.com/catalog/card-names')
    //         .then(response => response.json())
    //         .then(obj => {
    //             jokePara.textContent = obj.data;
    //         })
    //         .catch(error => console.log(error));
    // });

    cardButton.addEventListener('click', () => {
        // a promise is an object which represents
        // some value that we will eventually get or fail to
        // get. so a promise can "resolve" to success or
        // failure.

        let field = input.value;
        console.log(field);
        fetch('https://api.scryfall.com/catalog/' + field)
            .then(response => response.json())
            .then(obj => {
                jokePara.textContent = obj.data;
            })
            .catch(error => console.log(error));
    });
});

