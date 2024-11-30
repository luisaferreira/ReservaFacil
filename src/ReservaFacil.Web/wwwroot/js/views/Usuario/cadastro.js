$(document).ready(function () {
    selecionarPagina('user');

    $("form").submit(function(e) {
        e.preventDefault();

        const form = $(this);

        // Remove as permissões que são vinculadas ao perfil do usuário
        form.find('input[type="checkbox"]:disabled').remove();
        
        $.post("/Usuario/Cadastro", form.serialize())
            .done(function(response) {
                if (response.success) {
                    window.location.href = "/";
                } else {
                    let errorMessage = "";

                    response.errors.forEach(function(error) {
                        if (error) {
                            errorMessage += error + "<br>";
                        }
                    });

                    document.getElementById("modalErrorMessages").innerHTML = errorMessage;

                    let errorModal = new bootstrap.Modal(document.getElementById('errorModal'));
                    errorModal.show();
                }
            })
            .fail(function() {
                document.getElementById("modalErrorMessages").innerHTML = "Ocorreu um erro ao tentar realizar o cadastro do usuário.";

                let errorModal = new bootstrap.Modal(document.getElementById('errorModal'));
                errorModal.show();
            });
    });

    // Regra para desabilitar os checkboxes de acordo com o perfil selecionado 
    document.getElementById("Perfil").addEventListener("change", function (e) {
        const perfilSelecionadoId = $(this).val();

        habilitarCheckbox();
        desabilitarPorPerfil(perfilSelecionadoId);
    });

    function habilitarCheckbox() {
        const checkboxes = document.querySelectorAll('input[type="checkbox"]');
        checkboxes.forEach(function(checkbox) {
            checkbox.checked = false;
            checkbox.disabled = false;
        });
    }

    function desabilitarPorPerfil(perfilSelecionadoId){
        const perfil = perfilComPermissoes.find(p => p.idPerfil == perfilSelecionadoId);

        if (perfil) {
            perfil.permissoes.forEach(permissao => {
                const checkbox = document.getElementById(`permissao_${permissao.idPermissao}`);
                if (checkbox) {
                    checkbox.disabled = true;
                    checkbox.checked = true;
                }
            });
        }
    }
});