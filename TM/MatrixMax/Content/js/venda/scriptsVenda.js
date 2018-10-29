$(function () {
    $('#valorDesconto').mask("000,00", { reverse: true });
    $("#clienteVenda").select2({
        ajax: {
            url: "/Cliente/BuscaClienteVenda",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    q: params.term
                };
            },
            processResults: function (data, params) {
                return {
                    results: data.results
                };
            }
        },
        placeholder: 'Buscar...',
        language: {
            searching: function () {
                return "Buscando...";
            },
            inputTooShort: function (args) {
                return "Pesquise o cliente pelo nome";
            },
            noResults: function () {
                return "Nenhum resultado encontrado";
            }
        },
        minimumInputLength: 1,
        theme: "boostrap",
        dropdownCssClass: "dropdownSelect2"
    });

    populaProdutos();

    $(".select2-selection__rendered").addClass("rounded").addClass("form-control");

    $(".select2-selection select2-selection--single").addClass("rounded").addClass("form-control");

    $("#toggleDesconto").click(function () {
        if ($(this).prop("checked")) {
            $("#acoesDescontoContainer").fadeIn();
            descontoFixo = true;
            descontoPorPorcentagem = false;
            destravaOpcoesDesconto();
            $("#botaoAplicaDesconto").prop("disabled", false);
        } else {
            desativaDesconto();
        }
    });

    $("input[name='radioDesconto']").click(function () {
        if ($(this).prop("checked")) {
            if ($(this).prop("id") === "descontoFixo") {
                $("#porcentagemDesconto").prop("disabled", true).val("");
                $("#valorDesconto").prop("disabled", false);
                descontoFixo = true;
                descontoPorPorcentagem = false;
            }
            else {
                $("#valorDesconto").prop("disabled", true).val("");
                $("#porcentagemDesconto").prop("disabled", false);
                descontoFixo = false;
                descontoPorPorcentagem = true;
            }
        }
    });

    $("#formaDePagamento").change(function () {
        if ($(this).val() === "") return;
        if ($(this).val() === "3" || $(this).val() === "4") {
            $("#bandeiraCartao").prop("disabled", false);
            $("#opcoesCartao").fadeIn();
            cartaoDeCredito = $(this).val() === "3" ? true : false;
            cartaoDeDebito = !cartaoDeCredito;
            $("#parcelasCartao").prop("disabled", !cartaoDeCredito);
        } else {
            escondeCartoes();
        }
    });

    $("#produtosVenda").change(function () {
        if ($(this).val() === "") {
            $("#detalhesProdutoVenda").fadeOut();
            return;
        }

        var precosProduto = $(this).val().match(/pun=(.*)&prec=(.*)&ptr=(.*)&est=(.*)/);

        var precoUnitario = precosProduto[1];
        var precoRecarga = precosProduto[2];
        var precoTroca = precosProduto[3];
        var quantMax = precosProduto[4];

        $("#produtoVendaQuantidade").prop("max", quantMax);

        $("#produtoVendaTipoPreco option.precosProduto").remove();

        $("#produtoVendaTipoPreco").append(
            $("<option></option>")
                .text("UN: R$" + Number.parseFloat(precoUnitario).toFixed(2).replace(".", ","))
                .val(precoUnitario)
                .addClass("precosProduto")
        );

        if (precoRecarga > 0) {
            $("#produtoVendaTipoPreco").append(
                $("<option></option>")
                    .text("REC: R$" + Number.parseFloat(precoRecarga).toFixed(2).replace(".", ","))
                    .val(precoRecarga)
                    .addClass("precosProduto")
            );
        }

        if (precoTroca > 0) {
            $("#produtoVendaTipoPreco").append(
                $("<option></option>")
                    .text("TR: R$" + Number.parseFloat(precoTroca).toFixed(2).replace(".", ","))
                    .val(precoTroca)
                    .addClass("precosProduto")
            );
        }

        $("#detalhesProdutoVenda").fadeIn();
    });

    $("#botaoAdicionaProdutoVenda").click(function (event) {
        event.preventDefault();

        if (produtosDaVenda.findIndex(pv => pv.id == $("#produtosVenda").val().match(/id=(\d+)/)[1]) >= 0) {
            exibeErro("Produto já está presente na venda!");
            return;
        }

        if ($("#produtoVendaTipoPreco").val() === "") {
            exibeErro("Selecione o preço do produto escolhido.");
            return;
        }

        var quantidade = Number.parseInt($("#produtoVendaQuantidade").val());
        
        if (Number.isNaN(quantidade) || quantidade <= 0 || quantidade > 99) {
            exibeErro("Quantidade inválida.");
            return;
        }

        var quantMax = $("#produtosVenda").val().match(/est=(\d+)/)[1];

        if (quantidade > quantMax) {
            exibeErro("Quantidade informada excede o valor em estoque do produto.");
            return;
        }

        var produto = {};

        produto.nome = $("#select2-produtosVenda-container").text();
        produto.id = $("#produtosVenda").val().match(/id=(\d+)/)[1];
        produto.precoSelecionado = $("#produtoVendaTipoPreco").val();
        produto.quantidade = quantidade;
        produto.precoSubtotal = produto.quantidade * produto.precoSelecionado;

        venda.ValorTotal += produto.precoSubtotal;

        var botaoRemover = $("<button>").addClass("btn btn-sm btn-danger rounded").append(
            $("<i>").addClass("fa fa-minus-circle")
        );

        botaoRemover.click(function (event) {
            event.preventDefault();

            linhaSelecionada = $(this).parent().parent();

            idSelecionado = linhaSelecionada.find(".tdIdProduto").text();

            indexSelecionado = produtosDaVenda.findIndex(p => p.id === idSelecionado);

            venda.ValorTotal -= produtosDaVenda[indexSelecionado].precoSubtotal;

            atualizaLabelsValorTotaleDesconto();

            produtosDaVenda.splice(indexSelecionado, 1);

            linhaSelecionada.remove();

            if (produtosDaVenda.length === 0) {
                desativaDesconto();
                if ($("#toggleDesconto").prop("checked")) $("#toggleDesconto").prop("checked", false);
                $("#blocoDescontosVenda").fadeOut();
            }
        });

        $("#tabelaProdutosVenda").append(
            $("<tr>").append(
                $("<td>").text(produto.id).addClass("tdIdProduto").addClass("align-middle")
            ).append(
                $("<td>").text(produto.nome).addClass("align-middle")
            ).append(
                $("<td>").text("R$" + Number.parseFloat(produto.precoSelecionado).toFixed(2).replace(".", ",")).addClass("align-middle")
            ).append(
                $("<td>").text(produto.quantidade).addClass("align-middle")
            ).append(
                $("<td>").text("R$" + Number.parseFloat(produto.precoSubtotal).toFixed(2).replace(".", ",")).addClass("align-middle")
            ).append(
                $("<td>").html(botaoRemover).addClass("align-middle")
            )
        );

        atualizaLabelsValorTotaleDesconto();
        $("#detalhesProdutoVenda").fadeOut();
        $("#produtoVendaTipoPreco option.precosProduto").remove();
        $("#produtoVendaQuantidade").val("");
        $("#produtosVenda").val("").change();

        produtosDaVenda.push(produto);

        if (produtosDaVenda.length === 1) $("#blocoDescontosVenda").fadeIn();

        exibeAviso("Produto adicionado.");
    });

    $("#botaoProcessaVenda").click(function (event) {
        event.preventDefault();
        var cartaoSelecionado = (cartaoDeCredito || cartaoDeDebito);

        if ($("#formaDePagamento").val() === "") {
            exibeErro("Selecione a forma de pagamento.");
            return;
        }

        if (cartaoSelecionado) {
            if ($("#bandeiraCartao").val() === "") {
                exibeErro("Selecione a bandeira do cartão.");
                return;
            }
            if (cartaoDeCredito && $("#parcelasCartao").val() === "") {
                exibeErro("Selecione as parcelas do cartão.");
                return;
            }
        }

        if ($("#clienteVenda").val() === "") {
            exibeErro("Selecione o cliente.");
            return;
        }

        if (produtosDaVenda.length < 1) {
            exibeErro("Adicione ao menos um produto na venda.");
            return;
        }

        venda.PessoaId = $("#clienteVenda").val();
        venda.Data = $("#dataVenda").val();
        venda.FormaDePagamentoId = cartaoSelecionado ? $("#bandeiraCartao").val() : $("#formaDePagamento").val();
        venda.Observacao = $("#observacaoVenda").val();
        venda.TipoVenda = $("#tipoVenda").val();
        venda.Parcelas = cartaoDeCredito ? $("#parcelasCartao").val() : 0; 

        produtosDaVenda = transformaProdutos(produtosDaVenda);

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            type: 'POST',
            url: '/Venda/Cadastra',
            data: JSON.stringify({ venda: venda, produtosDaVenda: produtosDaVenda }),
            success: function (response) {
                if (response.adicionou) {
                    resetaVenda();
                    exibeAviso("Venda registrada com sucesso!");
                } else {
                    exibeErro("Erro interno: " + response.msg);
                }
            }
        });
    });

    $("#botaoAplicaDesconto").click(function (event) {
        event.preventDefault();

        if (descontoFixo) {
            valorDesconto = $("#valorDesconto").cleanVal() / 100;
            if (valorDesconto < 1 || valorDesconto > venda.ValorTotal) {
                exibeErro("Valor do desconto inválido.");
                return;
            }
            venda.DescontoValorFixo = valorDesconto;
        } else {
            if ($("#porcentagemDesconto").val() === "") {
                exibeErro("Selecione a porcentagem do desconto.");
                return;
            }
            venda.DescontoPorcento = $("#porcentagemDesconto").val();
        }

        atualizaLabelsValorTotaleDesconto();

        $("#botaoAlterarDesconto").prop("disabled", false);
        $(this).prop("disabled", true);
        travaOpcoesDesconto();
        exibeAviso("Desconto aplicado.");
    });

    $("#botaoAlterarDesconto").click(function (event) {
        event.preventDefault();
        destravaOpcoesDesconto();
        $("#botaoAplicaDesconto").prop("disabled", false);
        $("#botaoAlterarDesconto").prop("disabled", true);
    });
});

var produtosDaVenda = [];

var venda = {
    ValorTotal: 0,
    DescontoValorFixo: 0,
    DescontoPorcento: 0
};

var descontoFixo = false;
var descontoPorPorcentagem = false;
var cartaoDeCredito = false;
var cartaoDeDebito = false;

function atualizaLabelsValorTotaleDesconto() {
    if (descontoFixo || descontoPorPorcentagem) {
        valorDesconto = descontoFixo ? venda.DescontoValorFixo : (venda.ValorTotal / 100) * venda.DescontoPorcento;
        totalComDesconto = venda.ValorTotal - valorDesconto;
        $("#tdValorDesconto").text("R$ " + Number.parseFloat(valorDesconto).toFixed(2).replace(".", ","));
        $("#labelComDesconto").show();
        $("#labelTotalVenda").text("R$ " + Number.parseFloat(totalComDesconto).toFixed(2).replace(".", ","));
    } else {
        $("#tdValorDesconto").text("R$0,00");
        $("#labelTotalVenda").text("R$ " + Number.parseFloat(venda.ValorTotal).toFixed(2).replace(".", ","));
        $("#labelComDesconto").hide();
    }
}

function travaOpcoesDesconto() {
    $(".opcoesDesconto, .containerRadio, #porcentagemDesconto, #valorDesconto").addClass("cursorDesativado");
    $("input[name='radioDesconto']").prop("checked", false);
    $("#descontoFixo, #descontoPorcentagem, #porcentagemDesconto, #valorDesconto").prop("disabled", true);
}

function destravaOpcoesDesconto() {
    $(".opcoesDesconto, .containerRadio, #porcentagemDesconto, #valorDesconto").removeClass("cursorDesativado");
    $("#descontoFixo, #descontoPorcentagem").prop("disabled", false);

    $("#descontoFixo").prop("checked", descontoFixo);
    $("#descontoPorcentagem").prop("checked", descontoPorPorcentagem);
    $("#porcentagemDesconto").prop("disabled", !descontoPorPorcentagem);
    $("#valorDesconto").prop("disabled", !descontoFixo);
}

function transformaProdutos(produtosDaVenda) {
    var novo = [];
    produtosDaVenda.forEach(function (produto) {
        novo.push({
            ProdutoId: produto.id,
            Quantidade: produto.quantidade,
            PrecoSelecionado: produto.precoSelecionado
        });
    });
    return novo;
}

function desativaDesconto() {
    travaOpcoesDesconto();
    descontoFixo = false;
    descontoPorPorcentagem = false;
    venda.DescontoPorcento = 0;
    venda.DescontoValorFixo = 0;
    atualizaLabelsValorTotaleDesconto();
    $("#botaoAplicaDesconto, #botaoAlterarDesconto").prop("disabled", true);
    $("#porcentagemDesconto, #valorDesconto").val("");
    $("#acoesDescontoContainer").hide();
}

function resetaVenda() {
    $("#clienteVenda").val("").change();
    $("#dataVenda").val(new Date().toISOString().substr(0, 10));
    $("#formaDePagamento").val("").change();
    $("#observacaoVenda").val("");
    $("#parcelasCartao").val("1");
    $("#bandeiraCartao").val("");
    $("#tabelaProdutosVenda tbody tr").remove();
    $("#produtosVenda").val("").change();
    $("#produtosVenda").val("").change();

    produtosDaVenda = [];

    venda = {
        ValorTotal: 0,
        DescontoValorFixo: 0,
        DescontoPorcento: 0
    };
    
    cartaoDeCredito = false;
    cartaoDeDebito = false;

    populaProdutos();
    desativaDesconto();
    escondeCartoes();

    if ($("#toggleDesconto").prop("checked")) $("#toggleDesconto").prop("checked", false);
    $("#blocoDescontosVenda").fadeOut();
}

function exibeErro(mensagem) {
    $("#containerMensagensVenda").html("");
    $("#containerMensagensVenda").hide().append(
        '<div class="col-sm-12" id="msgErroVenda">'
        + '<div class="sufee-alert alert with-close alert-danger alert-dismissible fade show">'
        + '<span class="badge badge-pill badge-danger">alerta</span> ' + mensagem
        + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
        + '<span aria-hidden="true">&times;</span>'
        + '</button>'
        + '</div>'
        + '</div>').fadeIn();
}

function exibeAviso(mensagem) {
    $("#containerMensagensVenda").html("");
    $("#containerMensagensVenda").hide().append(
        '<div class="col-sm-12" id="msgAlertaVenda">'
        + '<div class="sufee-alert alert with-close alert-success alert-dismissible fade show">'
        + '<span class="badge badge-pill badge-success">alerta</span> ' + mensagem
        + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
        + '<span aria-hidden="true">&times;</span>'
        + '</button>'
        + '</div>'
        + '</div>').fadeIn();
}

function populaProdutos() {
    $.getJSON("/Produto/BuscaProdutosVenda", function (response) {
        $("#produtosVenda").html($("<option>")).select2({
            data: response,
            theme: "bootstrap",
            placeholder: "Selecione um produto",
            language: {
                searching: function () {
                    return "Buscando...";
                },
                inputTooShort: function (args) {
                    return "Pesquise pelo nome do produto";
                },
                noResults: function () {
                    return "Nenhum resultado encontrado";
                }
            },
            minimumInputLength: 1,
            dropdownCssClass: "dropdownSelect2"
        });
    });
}

function escondeCartoes() {
    $("#opcoesCartao").fadeOut();
    cartaoDeCredito = false;
    cartaoDeDebito = false;
    $("#bandeiraCartao").prop("disabled", true);
    $("#parcelasCartao").prop("disabled", true);
}