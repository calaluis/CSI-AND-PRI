function Insertar() {
    $('#Control').val('Insertar');
    $('#Evento').val('click');
    $('#GrillaPersonas').submit();
}
function Editar(Dato) {
    $('#Control').val('Editar');
    $('#Evento').val('click');
    $('#ValorControlEvento').val(Dato);
    $('#GrillaPersonas').submit();
}
function Actualizar() {
    $('#Control').val('Actualizar');
    $('#Evento').val('click');
    $('#GrillaPersonas').submit();
}
function Cancelar(Dato) {
    $('#Control').val('Cancelar');
    $('#Evento').val('click');
    $('#ValorControlEvento').val(Dato);
    $('#GrillaPersonas').submit();
}
function Eliminar(Dato) {
    $('#Control').val('Eliminar');
    $('#Evento').val('click');
    $('#ValorControlEvento').val(Dato);
    $('#GrillaPersonas').submit();
}
$(function () {
    $('#ModeloVistaNegocio_PersonaSeleccionada_Sexo_SelectedValue').change(function () {
        $('#Control').val('ModeloVistaNegocio.PersonaSeleccionada.Sexo.SelectedValue');
        $('#Evento').val('change');
        $('#ValorControlEvento').val($('#ModeloVistaNegocio_PersonaSeleccionada_Sexo_SelectedValue').val());
        $('#ModeloVistaNegocio_PersonaSeleccionada_Sexo_SelectedValue').submit();
    });
    $('#BtnPrimeraPagina').click(function () {
        $('#Control').val('PrimeraPagina');
        $('#Evento').val('click');
        $('#BtnPrimeraPagina').submit();
    });
    $('#BtnPaginaAnterior').click(function () {
        $('#Control').val('PaginaAnterior');
        $('#Evento').val('click');
        $('#BtnPaginaAnterior').submit();
    });
    $('#ModeloVistaNegocio_DatosPaginacion_Nro_Pag').keypress(function (e) {
        if (e.which == 13) {
            $('#Control').val('NumeroDePagina');
            $('#Evento').val('keypress');
            $('#ValorControlEvento').val($('#ModeloVistaNegocio_DatosPaginacion_Nro_Pag').val());
            $('#ModeloVistaNegocio_DatosPaginacion_Nro_Pag').submit();
        }
    });
    $('#BtnPaginaSiguiente').click(function () {
        $('#Control').val('PaginaSiguiente');
        $('#Evento').val('click');
        $('#BtnPaginaSiguiente').submit();
    });
    $('#BtnUltimaPagina').click(function () {
        $('#Control').val('UltimaPagina');
        $('#Evento').val('click');
        $('#BtnUltimaPagina').submit();
    });
});