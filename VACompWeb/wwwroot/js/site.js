// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#Update").click(function () {

    $(".alert").show('medium');
});


function changetextbox()
{
    if (document.getElementById("depstatus").value < 6) {
        document.getElementById("childunder").disabled = true;
        document.getElementById("childunder").value = 0;
        document.getElementById("childplus").disabled = true;
        document.getElementById("childplus").value = 0;
    }
    else
    {
        document.getElementById("childunder").disabled = false;
        document.getElementById("childplus").disabled = false;
    }
    
}


