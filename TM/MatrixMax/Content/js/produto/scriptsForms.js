$(document).ready(function () {
    $("#FormAtualiza").validate({
        rules: {
            "produtoedit.Nome": {
                required: true,
                minlength: 5,
                maxlength: 50,
                valoresIguaisEditar: true
            },
            "produtoedit.MarcaId": "required",
            CategoriaEdit: "required",
            "produtoedit.SubcategoriaId": "required",
            "produtoedit.EstoqueMinimo": {
                required: true,
                estoqueInicial: true
            },
            "produtoedit.PrecoUnitario": {
                required: true,
                valorPrecos: true
            },
            "produtoedit.PrecoRecarga": {
                required: "#TogglePrecoRecargaEditar:checked",
                valorPrecos: true
            },
            "produtoedit.PrecoTroca": {
                required: "#TogglePrecoTrocaEditar:checked",
                valorPrecos: true
            }
        },
        messages: {
            "produtoedit.Nome": {
                required: "Informe um nome.",
                minlength: "O nome deve ter no mínimo 5 caracteres.",
                maxlength: "O nome deve ter no máximo 50 caracteres."
            },
            "produtoedit.MarcaId": "Selecione a marca.",
            CategoriaEdit: "Selecione a categoria.",
            "produtoedit.SubcategoriaId": "Selecione a subcategoria.",
            "produtoedit.EstoqueMinimo": {
                required: "Informe o estoque mínimo."
            },
            "produtoedit.PrecoUnitario": {
                required: "Informe o preço unitário."
            },
            "produtoedit.PrecoRecarga": {
                required: "Informe o preço da recarga."
            },
            "produtoedit.PrecoTroca": {
                required: "Informe o preço de troca."
            },
        },
        errorPlacement: function (label, element) {
            label.addClass('alert alert-danger erroEditar');
            label.prop("role", "alert");
            label.insertAfter(element);
        },
        wrapper: 'div',
        errorClass: 'campoInvalido',
        highlight: function (element, errorClass) {
            $(element).addClass(errorClass);
        },
        unhighlight: function (element, errorClass) {
            $(element).removeClass(errorClass);
        }
    });
    $("#FormAdiciona").validate({
        rules: {
            "produto.Nome": {
                required: true,
                minlength: 5,
                maxlength: 50
            },
            "produto.MarcaId": "required",
            CategoriaAdd: "required",
            "produto.SubcategoriaId": "required",
            "produto.Estoque": {
                required: true,
                estoqueInicial: true
            },
            "produto.EstoqueMinimo": {
                required: true,
                estoqueInicial: true
            },
            "produto.PrecoUnitario": {
                required: true,
                valorPrecos: true
            },
            "produto.PrecoRecarga": {
                required: "#TogglePrecoRecargaAdd:checked",
                valorPrecos: true
            },
            "produto.PrecoTroca": {
                required: "#TogglePrecoTrocaAdd:checked",
                valorPrecos: true
            }
        },
        messages: {
            "produto.Nome": {
                required: "Informe um nome.",
                minlength: "O nome deve ter no mínimo 5 caracteres.",
                maxlength: "O nome deve ter no máximo 50 caracteres."
            },
            "produto.MarcaId": "Selecione a marca.",
            CategoriaAdd: "Selecione a categoria.",
            "produto.SubcategoriaId": "Selecione a subcategoria.",
            "produto.Estoque": {
                required: "Informe o estoque inicial."
            },
            "produto.EstoqueMinimo": {
                required: "Informe o estoque mínimo."
            },
            "produto.PrecoUnitario": {
                required: "Informe o preço unitário."
            },
            "produto.PrecoRecarga": {
                required: "Informe o preço da recarga."
            },
            "produto.PrecoTroca": {
                required: "Informe o preço de troca."
            },
        },
        errorPlacement: function (label, element) {
            label.addClass('alert alert-danger erroAdd');
            label.prop("role", "alert");
            label.insertAfter(element);
        },
        wrapper: 'div',
        errorClass: 'campoInvalido',
        highlight: function (element, errorClass) {
            $(element).addClass(errorClass);
        },
        unhighlight: function (element, errorClass) {
            $(element).removeClass(errorClass);
        },
    });

    $('#valorDesconto').mask("000,00", { reverse: true });
    $('#precoUnitarioAdd').mask("000,00", { reverse: true });
    $('#precoUnitarioEditar').mask("000,00", { reverse: true });
    $('#precoRecargaAdd').mask("000,00", { reverse: true });
    $('#precoRecargaEditar').mask("000,00", { reverse: true });
    $('#precoTrocaAdd').mask("000,00", { reverse: true });
    $('#precoTrocaEditar').mask("000,00", { reverse: true });
    $('#estoqueAdd').mask("000");
    $('#estoqueMinimoAdd').mask("000");
    $('#estoqueMinimoEditar').mask("000");

    $('#FormAdiciona').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.adicionou) {
                $("#msgErroProdutoAdd").prop("hidden", true);
                $('#FormAdiciona').resetForm();
                $('#fechaModalAdd').click(); $('#fechaModalAdd').click();
                tabelaprodutos.ajax.reload();
                $("#mensagensContainer").append(
                    '<div class="col-sm-12" id="msgProdutoAdicionado">'
                    + '<div class="alert  alert-success alert-dismissible fade show" role="alert">'
                    + '<span class="badge badge-pill badge-success">sucesso</span> Produto adicionado.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>');
            } else {
                $("#msgErroProdutoAdd").prop("hidden", false);
                $("#textoMsgErroProdutoAdd").html("Erro interno: <br/>" + resposta.msg);
            }
        }
    });

    $('#FormAtualiza').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.atualizou) {
                $("#msgProdutoNaoAlterado").prop("hidden", true);
                $('#fechaModalEdita').click(); $('#fechaModalEdita').click();
                tabelaprodutos.ajax.reload();
                $("#mensagensContainer").append(
                    '<div class="col-sm-12" id="msgProdutoAtualizado">'
                    + '<div class="sufee-alert alert with-close alert-warning alert-dismissible fade show">'
                    + '<span class="badge badge-pill badge-warning">sucesso</span> Produto atualizado.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>');
            } else {
                $("#msgProdutoNaoAlterado").prop("hidden", false);
                $("#textoMsgProdutoNaoAlterado").html("Erro interno: <br/>" + resposta.msg);
            }
        }
    });

    jQuery.validator.addMethod("estoqueInicial", function (value, element) {
        return this.optional(element) || (Number.parseInt(value) >= 1 && Number.parseInt(value) <= 100);
    }, 'Informe um valor de estoque válido (mínimo 1, máximo 100).');

    jQuery.validator.addMethod("valorPrecos", function (value, element) {
        return this.optional(element) || (Number.parseFloat(value.replace(',', '.')) >= 1);
    }, 'Informe um preço válido (Mínimo R$1,00).');

    jQuery.validator.addMethod("valoresIguaisEditar", function (value, element) {
        var NomeIgual = value == document.getElementById('nomeEditar').defaultValue;
        var MarcaIgual = document.getElementById('MarcaEditar')[document.getElementById("MarcaEditar").selectedIndex].defaultSelected;
        var CategoriaIgual = document.getElementById('categoriaEditar')[document.getElementById("categoriaEditar").selectedIndex].defaultSelected;
        var SubcategoriaIgual = document.getElementById('subcategoriaEditar')[document.getElementById("subcategoriaEditar").selectedIndex].defaultSelected;
        var EstoqueIgual = jQuery('#estoqueMinimoEditar').val() == document.getElementById('estoqueMinimoEditar').defaultValue;
        precoUnitario = Number.parseFloat(jQuery('#precoUnitarioEditar').val().replace(',', '.'));
        precoUnitarioPadrao = Number.parseFloat(document.getElementById('precoUnitarioEditar').defaultValue.replace(',', '.'));
        var PrecoUnitarioIgual = precoUnitario == precoUnitarioPadrao;

        var precoRecargaPadraoNulo = document.getElementById('precoRecargaEditar').defaultValue == "Desabilitado";
        var PrecoRecargaIgual = false;
        if (precoRecargaPadraoNulo && jQuery('#precoRecargaEditar').val() == "Desabilitado") {
            PrecoRecargaIgual = true;
        } else if (!(jQuery('#precoRecargaEditar').val() == "")) {
            precoRecarga = Number.parseFloat(jQuery('#precoRecargaEditar').val().replace(',', '.'));
            precoRecargaPadrao = Number.parseFloat(document.getElementById('precoRecargaEditar').defaultValue);
            PrecoRecargaIgual = precoRecarga == precoRecargaPadrao;
        }

        var precoTrocaPadraoNulo = document.getElementById('precoTrocaEditar').defaultValue == "Desabilitado";
        var PrecoTrocaIgual = false;
        if (precoTrocaPadraoNulo && jQuery('#precoTrocaEditar').val() == "Desabilitado") {
            PrecoTrocaIgual = true;
        } else if (!(jQuery('#precoTrocaEditar').val() == "")) {
            precoTroca = Number.parseFloat(jQuery('#precoTrocaEditar').val().replace(',', '.'));
            precoTrocaPadrao = Number.parseFloat(document.getElementById('precoTrocaEditar').defaultValue);
            PrecoTrocaIgual = precoTroca == precoTrocaPadrao;
        }

        return this.optional(element) ||
            !(NomeIgual &&
                MarcaIgual &&
                CategoriaIgual &&
                SubcategoriaIgual &&
                EstoqueIgual &&
                PrecoUnitarioIgual &&
                PrecoTrocaIgual &&
                PrecoRecargaIgual);
    }, 'Nenhuma alteração feita no produto.');
});