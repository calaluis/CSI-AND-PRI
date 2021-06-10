$(function () {
    document.getElementById("MensajeCargando").style.display = "none";
});

function EnProceso() {
    var url = $('#EnProceso').val();
    document.getElementById("txtMensajeTituloCargando").innerHTML = 'Procesando....';
    document.getElementById("txtMensajeDetalleCargando").innerHTML = '<h1><img id="waitimage" src="' + url + '" width="40" /></h1>';
    $("#MensajeCargando").modal({
        show: true,
        backdrop: "static"
    });
}
var onSuccess = function (result) {
    $("#MensajeCargando").modal('hide');
    if (result.url) {
        window.location.href = result.url;
    }
}

var OnFailure = function (result)
{
    var Test = result;
}