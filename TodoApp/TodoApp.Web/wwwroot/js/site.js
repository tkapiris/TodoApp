// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const uri = 'Todo/Finish';

function finishTodo(todoId) {
    fetch(`${uri}/${todoId}`, {
        method: 'POST',
        //headers: {
        //    'Accept': 'application/json',
        //    'Content-Type': 'application/json'
        //},
        // body: JSON.stringify(item)
    })
        .then(() => window.location.reload())
        .catch(error => console.error('Unable to finish item.', error));

    return false;
}