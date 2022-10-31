// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function checkClient() {
    const ClientId = document.getElementById("ClienteId").value

    if (ClientId.Exists() === false) {
        alert("Esse cliente nao existe.")
    }

}
