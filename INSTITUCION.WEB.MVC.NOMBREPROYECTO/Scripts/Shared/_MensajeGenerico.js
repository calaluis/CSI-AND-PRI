$(function () {
    document.getElementById("txtMensajeDetalle").style.display = "none";
    if (document.getElementById("MSGDetalle").value != "") {
        document.getElementById("txtMensajeDetalle").style.display = "block";
        if (document.getElementById("MSGTipoRespuesta").value == "0" ||
            document.getElementById("MSGTipoRespuesta").value == "2") {
            document.getElementById("txtMensajeDetalle").className = "alert alert-success";
        }
        if (document.getElementById("MSGTipoRespuesta").value == "1") {
            document.getElementById("txtMensajeDetalle").className = "alert alert-warning";
        }
        if (document.getElementById("MSGTipoRespuesta").value == "3" ||
            document.getElementById("MSGTipoRespuesta").value == "4") {
            document.getElementById("txtMensajeDetalle").className = "alert alert-danger";
        }
        if (document.getElementById("MSGTipoRespuesta").value == "5") {
            document.getElementById("txtMensajeDetalle").className = "alert alert-info";
        }
        document.getElementById("txtMensajeTitulo").innerHTML = document.getElementById("MSGTitulo").value;
        document.getElementById("txtMensajeDetalle").innerHTML = document.getElementById("MSGDetalle").value;
        document.getElementById("MSGDetalle").value = "";
        $("#Mensaje").modal({
            show: true
        });
    }
});