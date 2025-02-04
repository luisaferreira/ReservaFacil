let contaId = 1;

$(document).ready(function () {
    selecionarPagina('room');

    $("#btnAdicionarHorario").on("click", function () {
        const horariosContainer = document.getElementById('horariosContainer');
        const horarioTemplate = document.getElementById('horarioTemplate');

        if (horariosContainer && $(horarioTemplate).css('display') === 'none') {
            $(horarioTemplate).css('display', 'block');
            adicionaEventoDeRemoverHorario(horarioTemplate, true);
            //verificarCamposPreenchidos();
            return;
        }

        const novoHorario = horarioTemplate.cloneNode(true);
        novoHorario.id = `horarioTemplate_${contaId}`;

        adicionaEventoDeRemoverHorario(novoHorario);
        atualizarCamposDeHorario(novoHorario, contaId);
        
        horariosContainer.appendChild(novoHorario);
        contaId++;
    })

})

function adicionaEventoDeRemoverHorario(horarioElemento, isDefault = false) {
    const removeButton = horarioElemento.querySelector('.btn-removeHorario');
    if (removeButton) {
        removeButton.addEventListener('click', function () {
            if (!isDefault) {
                horarioElemento.remove();
            } else {
                $(horarioTemplate).css('display', 'none');
                const horarioInicialInput = horarioElemento.querySelector(`input[name^="Periodo"]`);
                const horarioFinalInput = horarioElemento.querySelector(`input[name^="Periodo"]`);
                horarioInicialInput.value = "";
                horarioFinalInput.value = "";
            }
        });
    }

    $(`.txtPeriodo`).daterangepicker({
        timePicker: true,
        timePicker24Hour: true,
        timePickerIncrement: 1,
        locale: {
            format: 'HH:mm'
        }
    }).on('show.daterangepicker', function (ev, picker) {
        picker.container.find(".calendar-table").hide();
    });
}

function atualizarCamposDeHorario(horarioElemento, id) {
    const periodoLabel = horarioElemento.querySelector(`label[for^="Periodo"]`);
    const periodoInput = horarioElemento.querySelector(`input[name^="Periodo"]`);

    periodoLabel.setAttribute('for', `Periodo[${id}]`);
    periodoInput.setAttribute('name', `Periodo[${id}]`);
    periodoInput.setAttribute('id', `Periodo[${id}]`);
    periodoLabel.setAttribute('for', `Periodo[${id}]`);
    periodoInput.setAttribute('name', `Periodo[${id}]`);
}

function verificarCamposPreenchidos() {
    const horariosIniciais = document.querySelectorAll('input[name^="HorarioInicial"]');
    const horariosFinais = document.querySelectorAll('input[name^="HorarioFinal"]');
    const addHorarioButton = document.getElementById('addHorario');

    for (let i = 0; i < horariosIniciais.length; i++) {
        const nameHorarioInicial = horariosIniciais[i].name;

        if (nameHorarioInicial === "HorarioInicial[0]" && $(horarioTemplate).css('display') === 'none') {
            continue;
        }

        if (!horariosIniciais[i].value || !horariosFinais[i].value) {
            $("#btnAdicionarHorario").attr("disabled", true);

            return;
        }
    }

    if (verificarSobreposicao(horariosIniciais, horariosFinais)) {
        addHorarioButton.disabled = true;
        limparUltimosCamposDeHorario(horariosIniciais, horariosFinais);
        alert('O novo intervalo se sobrepõe a um horário já cadastrado. Escolha um horário fora do intervalo existente.');
    } else {
        $("#btnAdicionarHorario").attr("disabled", false);
    }
}

function verificarSobreposicao(horariosIniciais, horariosFinais) {
    for (let i = 0; i < horariosIniciais.length; i++) {
        const horarioInicial = new Date(horariosIniciais[i].value);
        const horarioFinal = new Date(horariosFinais[i].value);

        for (let j = 0; j < horariosIniciais.length; j++) {
            if (i !== j) {
                const outroHorarioInicial = new Date(horariosIniciais[j].value);
                const outroHorarioFinal = new Date(horariosFinais[j].value);

                if (
                    (horarioInicial >= outroHorarioInicial && horarioInicial < outroHorarioFinal) ||
                    (horarioFinal > outroHorarioInicial && horarioFinal <= outroHorarioFinal) ||
                    (horarioInicial < outroHorarioInicial && horarioFinal > outroHorarioFinal)
                ) {
                    return true;
                }
            }
        }
    }
    return false;
}

function limparUltimosCamposDeHorario(horariosIniciais, horariosFinais) {
    const ultimoHorarioInicial = horariosIniciais[horariosIniciais.length - 1];
    const ultimoHorarioFinal = horariosFinais[horariosFinais.length - 1];

    if (ultimoHorarioInicial && ultimoHorarioFinal) {
        ultimoHorarioInicial.value = "";
        ultimoHorarioFinal.value = "";
    }
}