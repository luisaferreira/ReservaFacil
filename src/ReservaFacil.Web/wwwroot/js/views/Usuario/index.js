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

function alterarPagina(valor, numeroMaximo) {
    if (valor > numeroMaximo || valor < 0)
        return;

    $("#numeroPagina").val(valor);
    listarUsuarios();
}