﻿$(document).ready(function () {
    selecionarPagina('home');

    $("#periodoReserva").daterangepicker({
        startDate: moment(),
        endDate: moment().add(7, 'days'),
        "locale": {
            "format": "DD/MM/YYYY"
        }
    });

    $("#periodoReserva").val("");

    pesquisar();
});

function pesquisar() {
    mostrarCarregamento();

    var pagina = $("#numeroPagina").val();
    var pesquisa = ($("#pesquisa").val() !== null && $("#pesquisa").val() !== undefined) ? $("#pesquisa").val() : "";
    var statusReserva = $("#statusReserva").val();
    var periodoReserva = $("#periodoReserva").val();
    var [ dataInicial, dataFinal ] = periodoReserva.split(" - ");

    //var dataInicial = $("#periodoReserva").data('daterangepicker').startDate.format('YYYY-MM-DD');

    console.log(periodoReserva)
    console.log(dataInicial);
    console.log(dataFinal);

    $.ajax({
        type: 'GET',
        url: '/Reserva/Pesquisar?numeroPagina=' + pagina,
        data: {
            pesquisa: pesquisa,
            statusId: statusReserva,
            dataInicial: moment(dataInicial, "DD/MM/YYYY").format("YYYY-MM-DD"),
            dataFinal: moment(dataFinal, "DD/MM/YYYY").format("YYYY-MM-DD")
        },
        success: function (response) {
            $("#reservas").html(response);
        },
        complete: function () {
            ocultarCarregamento();
        }
    })
}

function limpar() {
    $("#pesquisa").val("");
    $("#statusReserva").val("");
    $("#periodoReserva").val("");
}