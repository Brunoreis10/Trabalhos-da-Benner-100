$("#botao-frase").click(fraseAleatoria);
$("#botao-frase-id").click(buscaFrase);

function fraseAleatoria() {
    $("#spinner").slideToggle();
    $.get("http://localhost:3001/frases", trocaFraseAleatoria)
    .fail(function(){
        $("#erro").slideToggle();
        setTimeout(function(){
            $("#erro").slideToggle();
        }, 3000);
    })
    .always(function(){
        $("#spinner").slideToggle();
    });
}

function trocaFraseAleatoria(frases) { 
    var randomIndex = Math.floor(Math.random() * frases.length);
    $(".frase").text(frases[randomIndex].texto);
    atualizaTamanhoFrase();
    atualizaTempoInicial(frases[randomIndex].tempo);
}

function buscaFrase() {
    $("#spinner").slideToggle();
    var dados = { id: $("#frase-id").val() };
    $.get("http://localhost:3001/frases", dados, trocaFrase)
    .fail(function() {
        $("#erro").slideToggle();
        setTimeout(function(){
            $("#erro").slideToggle();
        }, 3000);
    })
    .always(function(){
        $("#spinner").slideToggle();
    });
}

function trocaFrase(frase) {
    $(".frase").text(frase.texto);
    atualizaTamanhoFrase();
    atualizaTempoInicial(frase.tempo);
}