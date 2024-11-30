$(document).ready(function () {
    selecionarPagina('user')

    listarUsuarios();
});

function listarUsuarios() {
    var pagina = $("#numeroPagina").val();

    $.ajax({
        type: "GET",
        url: "/Usuario/ListarUsuarios?numeroPagina=" + pagina,
        success: function (data) {
            $("#divListaUsuarios").html(data);
        }
    });

}