$("#botao-placar").click(function() {
    $(".placar").stop().slideToggle(1000);
    scrollPlacar();
});

$("#botao-sync").click(sincronizaPlacar);

function inserePlacar() {
    var corpoTabela = $(".placar").find("tbody");
    var placar = $("#contador-palavras").text();
    var usuario = $("#usuarios").val();
    var linha = criaLinhaPlacar(usuario, placar);

    linha.find(".botao-remover").click(removeLinha);

    corpoTabela.prepend(linha);

    $(".placar").slideDown(600);
    
    scrollPlacar();

}

function criaLinhaPlacar(usuario, placar) {
    var linha = $("<tr>");
    var colunaUsuario = $("<td>").text(usuario);
    var colunaPlacar = $("<td>").text(placar);
    var colunaRemover = $("<td>");
    
    var link = $("<a>").addClass("botao-remover").attr("href", "#");
    var icone = $("<i>").addClass("small").addClass("material-icons").text("delete");
    
    link.append(icone);
    colunaRemover.append(link);
    linha.append(colunaUsuario);
    linha.append(colunaPlacar);
    linha.append(colunaRemover);

    return linha;
}

function removeLinha(event) {
    event.preventDefault();
    var linha = $(this).parent().parent();
    linha.fadeOut(500);
    setTimeout(function (){
        linha.remove();
    }, 500);
}

function scrollPlacar() {
    var posicaoPlacar = $(".placar").offset().top;
    $("html, body").animate(
    {
        scrollTop: posicaoPlacar+"px"
    }, 1000);
}

function sincronizaPlacar(){
    var placar = [];
    var linhas = $(".placar tbody>tr");
    linhas.each(function() {
        var score = {
            usuario: $(this).find("td:nth-child(1)").text(),
            pontos: $(this).find("td:nth-child(2)").text()
        }
        placar.push(score);
    });

    dados = { placar: placar };
    $.post("http://localhost:3000/placar", dados, function(){
        $(".tooltip").tooltipster("open");
    }).fail(function(){
        $(".tooltip").tooltipster("open").tooltipster("content", "Falha ao sincronizar.");
    }).always(function(){
        setTimeout(function(){
            $(".tooltip").tooltipster("close");
        }, 2000);
    });
}

function atualizaPlacar() {
    $.get("http://localhost:3000/placar", function(data) {
        $(data).each(function() {
            var linha = criaLinhaPlacar(this.usuario, this.pontos);
            linha.find(".botao-remover").click(removeLinha);
            $(".placar tbody").append(linha);
        });
    });
}