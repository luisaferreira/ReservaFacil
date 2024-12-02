$(document).ready(function () {
    selecionarPagina('home');

    $("#periodoReserva").daterangepicker({
        startDate: moment(),
        endDate: moment().add(7, 'days'),
        "locale": {
            "format": "DD/MM/YYYY"
        }
    });
});