// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ajaxGet (url, data, onBeforeSend){
    return $.ajax({
        url,
        type: 'GET',
        data: JSON.stringify(data),
        contentType: 'application/json',
        beforeSend: onBeforeSend,
    });
}

function ajaxPost (url, data, onBeforeSend) {
    return $.ajax({
        url,
        type: 'POST',
        data: JSON.stringify(data),
        contentType: 'application/json',
        beforeSend: onBeforeSend
    });
}

function ajaxPut(url, data, onBeforeSend) {
    return $.ajax({
        url,
        type: 'PUT',
        data: JSON.stringify(data),
        contentType: 'application/json',
        beforeSend: onBeforeSend
    });
}

function ajaxDelete(url, data, onBeforeSend) {
    return $.ajax({
        url,
        type: 'DELETE',
        data: JSON.stringify(data),
        contentType: 'application/json',
        beforeSend: onBeforeSend
    });
}