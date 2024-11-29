// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onFail(jqXHR, textStatus, errorThrown) {
    console.log("Fail:" + jqXHR.status);

    if (jqXHR.status === 0) {
        alert('Not connect. Verify Network.');
    } else if (jqXHR.status == 401) {
        window.location.replace("/Login");
    } else if (jqXHR.status == 404) {
        window.location.replace("/NotFound");
    } else if (jqXHR.status == 500) {
        window.location.replace("/Error");
    }
}

function onData(data) {
    var placeholderElement = $('#placeholder');
    placeholderElement.html(data);
    placeholderElement.find('.modal').modal('show');
}