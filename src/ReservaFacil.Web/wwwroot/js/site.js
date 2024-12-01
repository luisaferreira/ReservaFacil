function voltar() {
    window.history.back();
}

function selecionarPagina(pagina) {
    //Limpando o item ativo anteriormente
    var item = $(".menu-item-active");
    item.removeClass("menu-item-active");
    var img = item.find("img");
    var srcAntigo = img.attr("src");
    srcAntigo = srcAntigo.replace("filled", "outline");
    img.attr("src", srcAntigo)

    //Selecionando o item novo
    var imgSelecionado = $("img#" + pagina + "-icon").first();
    var srcNovo = imgSelecionado.attr("src");
    srcNovo = srcNovo.replace("outline", "filled");
    imgSelecionado.attr("src", srcNovo);
    var itemSelecionado = imgSelecionado.closest(".menu-item");
    itemSelecionado.addClass("menu-item-active");
}

function mostrarCarregamento() {
    $("#loading").css("display", "flex");
}

function ocultarCarregamento() {
    $("#loading").css("display", "none");
}