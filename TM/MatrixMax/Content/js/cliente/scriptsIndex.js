$(function () {
    $('#filtroNome').on('keyup', function () {
        tabelaclientes.columns(14).search(this.value).draw();
    });

    $('#filtroTipoPessoa').on('change', function () {
        tabelaclientes.columns(15).search(this.value).draw();
    });

    var validacoes = $("#FormDadosPessoa").validate({
        rules: {
            "pessoa.NomeRazaoSocial": {
                required: true,
                minlength: 5,
                maxlength: 50
            },
            "pessoa.Email": {
                required: true,
                email: true
            },
            "pessoa.Telefone": {
                required: true,
                minlength: 14
            },
            "pessoa.CpfCnpj": {
                required: true,
                cpfcnpj: true
            },
            "pessoa.InscricaoEstadual": {
                required: true,
                minlength: 15
            },
            "pessoa.NomeFantasia": {
                required: true,
                minlength: 5,
                maxlength: 50
            },
            "pessoa.Endereco.Cep": {
                required: true,
                minlength: 9
            },
            "pessoa.Endereco.Numero": {
                required: true
            }
        },
        messages: {
            "pessoa.NomeRazaoSocial": {
                required: "Informe um nome/razão social.",
                minlength: "O nome deve ter no mínimo 5 caracteres.",
                maxlength: "O nome deve ter no máximo 50 caracteres."
            },
            "pessoa.Email": {
                required: "Informe um email."
            },
            "pessoa.Telefone": {
                required: "Informe um telefone.",
                minlength: "Número inválido."
            },
            "pessoa.CpfCnpj": {
                required: "Informe um CPF/CNPJ."
            },
            "pessoa.InscricaoEstadual": {
                required: "Informe a inscrição estadual.",
                minlength: "Inscrição estadual inválida."
            },
            "pessoa.NomeFantasia": {
                required: "Informe o nome fantasia.",
                minlength: "O nome deve ter no mínimo 5 caracteres.",
                maxlength: "O nome deve ter no máximo 50 caracteres."
            },
            "pessoa.Endereco.Cep": {
                required: "Informe o CEP.",
                minlength: "CEP inválido."
            },
            "pessoa.Endereco.Numero": {
                required: "Informe o número.",
            }
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
        }
    });

    jQuery.validator.addMethod("email", function (value, element) {
        var regexEmail = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        return this.optional(element) || regexEmail.test(value);
    }, 'Email inválido.');

    jQuery.validator.addMethod("cpfcnpj", function (value, element) {
        var tamanho = $(element).attr("id") === "cpfPessoa" ? 14 : 18;
        var valido = $(element).attr("id") === "cpfPessoa" ? validaCPF(value) : validaCNPJ(value);
        return this.optional(element) || value.length === tamanho && valido;
    }, 'CPF ou CNPJ inválido.');

    $('#telefonePessoa').mask('(00) 00000-0000');
    $('#cpfPessoa').mask('000.000.000-00', { reverse: true });
    $('#cnpjPessoa').mask('00.000.000/0000-00', { reverse: true });
    $('#inscricaoEstadualPessoa').mask('000.000.000.000', { reverse: true });
    $('#cepEndereco').mask('00000-000');
    $('#numeroEndereco').mask('0#');

    $('#ModalEditar').on('hide.bs.modal', function () {
        $("#mensagensContainerClienteForm").html("");
        $("#FormDadosPessoa").resetForm();
        validacoes.resetForm();
    });

    $('#FormDadosPessoa').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.adicionou) {
                $('#fechaModalEditar').click(); $('#fechaModalEditar').click();
                tabelaclientes.ajax.reload();
                $("#mensagensContainerCliente").html("");
                $("#mensagensContainerClienteForm").html("");
                $("#mensagensContainerCliente").hide().append(
                    '<div class="col-sm-12" id="msgClienteAtualizado">'
                    + '<div class="alert  alert-success alert-dismissible fade show" role="alert">'
                    + '<span class="badge badge-pill badge-success">sucesso</span> Cliente atualizado.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>').fadeIn();
            } else {
                $("#mensagensContainerClienteForm").html("");
                $("#mensagensContainerClienteForm").hide().append(
                    '<div class="col-sm-12" id="msgErroInternoCliente">'
                    + '<div class="sufee-alert alert with-close alert-danger alert-dismissible fade show">'
                    + '<span class="badge badge-pill badge-danger">erro interno</span> ' + resposta.msg
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>').fadeIn();
            }
        }
    });
});

$("#labelRadioPessoaFisica").click(toggleFisica());

function validaCNPJ(cnpj) {
    var b = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
    if ((cnpj = cnpj.replace(/[^\d]/g, "")).length != 14)
        return false;
    if (/0{14}/.test(cnpj))
        return false;
    for (var i = 0, n = 0; i < 12; n += cnpj[i] * b[++i]);
    if (cnpj[12] != (((n %= 11) < 2) ? 0 : 11 - n))
        return false;
    for (var i = 0, n = 0; i <= 12; n += cnpj[i] * b[i++]);
    if (cnpj[13] != (((n %= 11) < 2) ? 0 : 11 - n))
        return false;
    return true;
}

function validaCPF(cpf) {
    cpf = cpf.replace(/[^\d]+/g, '');
    if (cpf == '') return false;	
    if (cpf.length != 11 ||
        cpf == "00000000000" ||
        cpf == "11111111111" ||
        cpf == "22222222222" ||
        cpf == "33333333333" ||
        cpf == "44444444444" ||
        cpf == "55555555555" ||
        cpf == "66666666666" ||
        cpf == "77777777777" ||
        cpf == "88888888888" ||
        cpf == "99999999999")
        return false;	
    add = 0;
    for (i = 0; i < 9; i++)
        add += parseInt(cpf.charAt(i)) * (10 - i);
    rev = 11 - (add % 11);
    if (rev == 10 || rev == 11)
        rev = 0;
    if (rev != parseInt(cpf.charAt(9)))
        return false;
    add = 0;
    for (i = 0; i < 10; i++)
        add += parseInt(cpf.charAt(i)) * (11 - i);
    rev = 11 - (add % 11);
    if (rev == 10 || rev == 11)
        rev = 0;
    if (rev != parseInt(cpf.charAt(10)))
        return false;
    return true;
}

function limpaCEP() {
    // Limpa valores do formulário de cep.
    $("#logradouroEndereco").val("");
    $("#bairroEndereco").val("");
    $("#cidadeEndereco").val("");
    $("#estadoEndereco").val("");
}

$("#cepEndereco").blur(function () {
//Quando o campo cep perde o foco.

    //Nova variável "cep" somente com dígitos.
    var cep = $(this).val().replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            $("#logradouroEndereco").val("...");
            $("#bairroEndereco").val("...");
            $("#cidadeEndereco").val("...");
            $("#estadoEndereco").val("...");

            //Consulta o webservice viacep.com.br/
            $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                if (!("erro" in dados)) {
                    //Atualiza os campos com os valores da consulta.
                    $("#logradouroEndereco").val(dados.logradouro);
                    $("#bairroEndereco").val(dados.bairro);
                    $("#cidadeEndereco").val(dados.localidade);
                    $("#estadoEndereco").val(dados.uf);
                }
                else {
                    //CEP pesquisado não foi encontrado.
                    limpaCEP();
                }
            });
        }
        else {
            //cep é inválido.
            limpaCEP();
        }
    }
    else {
        //cep sem valor, limpa formulário.
        limpaCEP();
    }
});

function populaEndereco(index) {
    var dados = tabelaclientes.rows(index).data();

    $('#infoCEP').text(dados[0].Endereco.Cep);
    $('#infoLogradouro').text(dados[0].Endereco.Logradouro);
    $('#infoNro').text(dados[0].Endereco.Numero);
    $('#infoBairro').text(dados[0].Endereco.Bairro);
    $('#infoCidade').text(dados[0].Endereco.Cidade);
    $('#infoEstado').text(dados[0].Endereco.Estado);

    $('#infoComplemento').text(dados[0].Endereco.Complemento == null ? "N/A" : dados[0].Endereco.Complemento);
    $('#infoReferencia').text(dados[0].Endereco.Referencia == null ? "N/A" : dados[0].Endereco.Referencia);


}

function populaDados(index) {
    var dados = tabelaclientes.rows(index).data();

    $('#infoTelefone').text(dados[0].Telefone);
    $('#infoEmail').text(dados[0].Email);

    if (dados[0].TipoPessoa == "F") {
        $('#infoNome').text(dados[0].NomeRazaoSocial);
        $('#infoCPF').text(dados[0].CpfCnpj);
        $('#containerJuridica').hide();
        $('#containerFisica').show();
    } else {
        $('#infoRazaoSocial').text(dados[0].NomeRazaoSocial);
        $('#infoCNPJ').text(dados[0].CpfCnpj);
        $('#infoNomeFantasia').text(dados[0].InscricaoEstadual);
        $('#infoInscricaoEstadual').text(dados[0].NomeFantasia);
        $('#containerJuridica').show();
        $('#containerFisica').hide();
    }
}

function populaEditar(index) {
    var dados = tabelaclientes.rows(index).data();

    $('#telefonePessoa').val(dados[0].Telefone);
    $('#emailPessoa').val(dados[0].Email);
    $('#pessoaEndereco').val(dados[0].Id);
    $('#idPessoa').val(dados[0].Id);

    $('#cepEndereco').val(dados[0].Endereco.Cep);
    $('#logradouroEndereco').val(dados[0].Endereco.Logradouro);
    $('#numeroEndereco').val(dados[0].Endereco.Numero);
    $('#complementoEndereco').val(dados[0].Endereco.Complemento);
    $('#bairroEndereco').val(dados[0].Endereco.Bairro);
    $('#cidadeEndereco').val(dados[0].Endereco.Cidade);
    $('#estadoEndereco').val(dados[0].Endereco.Estado);
    $('#referenciaEndereco').val(dados[0].Endereco.Referencia);

    if (dados[0].TipoPessoa == "F") {
        $('#nomePessoa').val(dados[0].NomeRazaoSocial);
        $('#cpfPessoa').val(dados[0].CpfCnpj);
        $('#razaoSocialPessoa').val("");
        $('#cnpjPessoa').val("");
        $('#inscricaoEstadualPessoa').val("");
        $('#nomeFantasiaPessoa').val("");
        toggleFisica();
    } else {
        $('#razaoSocialPessoa').val(dados[0].NomeRazaoSocial);
        $('#cnpjPessoa').val(dados[0].CpfCnpj);
        $('#inscricaoEstadualPessoa').val(dados[0].InscricaoEstadual);
        $('#nomeFantasiaPessoa').val(dados[0].NomeFantasia);
        $('#nomePessoa').val("");
        $('#cpfPessoa').val("");
        toggleJuridica();
    }
}

function toggleFisica() {
    $("#labelRadioPessoaFisica").addClass("active");
    $("#labelRadioPessoaJuridica").removeClass("active");
    $(".divsFisicas").show();
    $(".divsJuridicas").hide();
    $("#tipoPessoa").val("F");
    $(".inputsJuridicos").prop("disabled", true);
    $(".inputsFisicos").prop("disabled", false);
}

function toggleJuridica() {
    $("#labelRadioPessoaFisica").removeClass("active");
    $("#labelRadioPessoaJuridica").addClass("active");
    $(".divsFisicas").hide();
    $(".divsJuridicas").show();
    $("#tipoPessoa").val("J");
    $(".inputsJuridicos").prop("disabled", false);
    $(".inputsFisicos").prop("disabled", true);
}

$("#labelRadioPessoaJuridica").click(toggleJuridica);
$("#labelRadioPessoaFisica").click(toggleFisica);