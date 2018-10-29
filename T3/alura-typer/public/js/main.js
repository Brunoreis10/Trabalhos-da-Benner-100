var tempoInicial = $("#tempo-digitacao").text();
var campo = $(".campo-digitacao");

$(function(){
    atualizaTamanhoFrase();
    inicializaContadores();
    inicializaCronometro();
    inicializaMarcadores();
    atualizaPlacar();
    
    $("#botao-reiniciar").click(reiniciaJogo);
    
    $("#usuarios").selectize({
        create: true,
        sortField: 'text'
    });

    $(".tooltip").tooltipster({
        trigger: "custom"
    });
});

function atualizaTempoInicial(tempo) {
    tempoInicial = tempo;
    $("#tempo-digitacao").text(tempoInicial);
}

function reiniciaJogo() {
    campo.attr("disabled", false);
    campo.val("");
    campo.toggleClass("gameover");
    campo.removeClass("campo-certo");
    campo.removeClass("campo-errado");
    $("#tempo-digitacao").text(tempoInicial);
    $("#contador-palavras").text("0");
    $("#contador-caracteres").text("0");
    inicializaCronometro();
}

function atualizaTamanhoFrase() {
    var frase = $(".frase").text();
    var contPalavras = frase.split(" ").length;
    var tamanhoFrase = $("#tamanho-frase").text(contPalavras);
}

function inicializaContadores() {
    campo.on("input", function () {
        $("#contador-palavras").text(campo.val().split(/\S+/).length - 1);
        $("#contador-caracteres").text(campo.val().replace(/\s+/g, "").length);
    });
}

function inicializaCronometro() {
    $("#botao-reiniciar").attr("disabled", true);
    campo.one("focus", function () {
        var tempoRestante = $("#tempo-digitacao").text();
        var contador = setInterval(function () {
            tempoRestante--;
            $("#tempo-digitacao").text(tempoRestante);
            if (tempoRestante < 1) {
                
                clearInterval(contador);
                finalizaJogo();
            }
        }, 1000);
    });
}

function inicializaMarcadores() {    
    campo.on("input", function () {
        var frase = $(".frase").text();
        if (frase.startsWith(campo.val())) {
            campo.addClass("campo-certo");
            campo.removeClass("campo-errado");
        }
        else {
            campo.addClass("campo-errado");
            campo.removeClass("campo-certo");
        }
    });
}

function finalizaJogo() {
    campo.attr("disabled", true);
    $("#botao-reiniciar").removeAttr("disabled");
    campo.toggleClass("gameover");
    inserePlacar();
}