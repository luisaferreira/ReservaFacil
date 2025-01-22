let contaId = 1;

$(document).ready(function () {
    selecionarPagina('room');

    $("#btnAdicionarHorario").on("click", function () {
        const horariosContainer = document.getElementById('horariosContainer');
        const horarioTemplate = document.getElementById('horarioTemplate');

        if (horariosContainer && $(horarioTemplate).css('display') === 'none') {
            $(horarioTemplate).css('display', 'block');
            adicionaEventoDeRemoverHorario(horarioTemplate, true);
            verificarCamposPreenchidos();
            return;
        }

        const novoHorario = horarioTemplate.cloneNode(true);
        novoHorario.id = `horarioTemplate_${contaId}`;

        adicionaEventoDeRemoverHorario(novoHorario);
        atualizarCamposDeHorario(novoHorario, contaId);

        horariosContainer.appendChild(novoHorario);
        contaId++;

        verificarCamposPreenchidos();
    })

})

document.getElementById('horariosContainer').addEventListener('input', function (e) {
    validaHorarioFinalMaiorQueInicial(e.target.name);
    verificarCamposPreenchidos();
});

function validaHorarioFinalMaiorQueInicial(nomeElemento) {
    const indexRegx = nomeElemento.match(/\[(\d+)]/);

    if (indexRegx) {
        const index = indexRegx[1];

        const horarioInicial = document.querySelector(`input[name="HorarioInicial[${index}]"]`);
        const horarioFinal = document.querySelector(`input[name="HorarioFinal[${index}]"]`);

        if (horarioInicial && horarioFinal) {
            const horarioInicialValue = new Date(horarioInicial.value);
            const horarioFinalValue = new Date(horarioFinal.value);

            if (horarioFinalValue <= horarioInicialValue) {
                horarioFinal.value = "";
                alert('O horário final deve ser maior que o horário inicial.');
            }
        }
    }
}

function adicionaEventoDeRemoverHorario(horarioElemento, isDefault = false) {
    const removeButton = horarioElemento.querySelector('.btn-removeHorario');
    if (removeButton) {
        removeButton.addEventListener('click', function () {
            if (!isDefault) {
                horarioElemento.remove();
            } else {
                $(horarioTemplate).css('display', 'none');
                const horarioInicialInput = horarioElemento.querySelector(`input[name^="HorarioInicial"]`);
                const horarioFinalInput = horarioElemento.querySelector(`input[name^="HorarioFinal"]`);
                horarioInicialInput.value = "";
                horarioFinalInput.value = "";
            }
            verificarCamposPreenchidos();
        });
    }
}

function atualizarCamposDeHorario(horarioElemento, id) {
    const horarioInicialLabel = horarioElemento.querySelector(`label[for^="HorarioInicial"]`);
    const horarioInicialInput = horarioElemento.querySelector(`input[name^="HorarioInicial"]`);

    const horarioFinalLabel = horarioElemento.querySelector(`label[for^="HorarioFinal"]`);
    const horarioFinalInput = horarioElemento.querySelector(`input[name^="HorarioFinal"]`);

    horarioInicialLabel.setAttribute('for', `HorarioInicial[${id}]`);
    horarioInicialInput.setAttribute('name', `HorarioInicial[${id}]`);
    horarioInicialInput.setAttribute('id', `HorarioInicial[${id}]`);
    horarioFinalLabel.setAttribute('for', `HorarioFinal[${id}]`);
    horarioFinalInput.setAttribute('name', `HorarioFinal[${id}]`);
    horarioFinalInput.setAttribute('id', `HorarioFinal[${id}]`);

    horarioInicialInput.value = "";
    horarioFinalInput.value = "";
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
