$(document).ready(function () {
    $("#FormUsuario").validate({
        rules: {
            "senhaUsuarioRepetida": {
                required: true,
                minlength: 5,
                maxlength: 15,
                senhasIguais: true
            },
            "senhaUsuario": {
                required: true,
                minlength: 5,
                maxlength: 15,
            },
            "usuario.Login": {
                required: true,
                minlength: 3,
                maxlength: 50
            },
            "usuario.TipoUsuario": {
                required: true,
            },
            "usuario.Pessoa.NomeRazaoSocial": {
                required: true,
                minlength: 5,
                maxlength: 50
            },
            "usuario.Pessoa.Email": {
                required: true,
                email: true
            },
            "usuario.Pessoa.Telefone": {
                required: true,
                minlength: 14
            },
            "usuario.Pessoa.CpfCnpj": {
                required: true,
                cpfcnpj: true
            },
            "usuario.Pessoa.InscricaoEstadual": {
                required: true,
                minlength: 15
            },
            "usuario.Pessoa.NomeFantasia": {
                required: true,
                minlength: 5,
                maxlength: 50
            },
            "usuario.Pessoa.Endereco.Cep": {
                required: true,
                minlength: 9
            },
            "usuario.Pessoa.Endereco.Numero": {
                required: true
            }
        },
        messages: {
            "senhaUsuarioRepetida": {
                required: "Informe a senha.",
                minlength: "A senha deve possuir ao menos 5 caracteres.",
                maxlength: "A senha pode possuir no máximo 15 caracteres."
            },
            "senhaUsuario": {
                required: "Informe a senha.",
                minlength: "A senha deve possuir ao menos 5 caracteres.",
                maxlength: "A senha pode possuir no máximo 15 caracteres."
            },
            "usuario.Login": {
                required: "Informe um login.",
                minlength: "O login deve ter no mínimo 3 caracteres.",
                maxlength: "O login deve ter no máximo 50 caracteres."
            },
            "usuario.TipoUsuario": {
                required: "Selecione o privilégio."
            },
            "usuario.Pessoa.NomeRazaoSocial": {
                required: "Informe um nome/razão social.",
                minlength: "O nome deve ter no mínimo 5 caracteres.",
                maxlength: "O nome deve ter no máximo 50 caracteres."
            },
            "usuario.Pessoa.Email": {
                required: "Informe um email."
            },
            "usuario.Pessoa.Telefone": {
                required: "Informe um telefone.",
                minlength: "Número inválido."
            },
            "usuario.Pessoa.CpfCnpj": {
                required: "Informe um CPF/CNPJ."
            },
            "usuario.Pessoa.InscricaoEstadual": {
                required: "Informe a inscrição estadual.",
                minlength: "Inscrição estadual inválida."
            },
            "usuario.Pessoa.NomeFantasia": {
                required: "Informe o nome fantasia.",
                minlength: "O nome deve ter no mínimo 5 caracteres.",
                maxlength: "O nome deve ter no máximo 50 caracteres."
            },
            "usuario.Pessoa.Endereco.Cep": {
                required: "Informe o CEP.",
                minlength: "CEP inválido."
            },
            "usuario.Pessoa.Endereco.Numero": {
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

    jQuery.validator.addMethod("senhasIguais", function (value, element) {
        return this.optional(element) || value === $("#senhaUsuario").val();
    }, 'As senhas informadas não coincidem.');

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

    $('#FormUsuario').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.adicionou) {
                tabelausuarios.ajax.reload();
                $('#FormUsuario').resetForm();

                $("#nav-novoUsuario-tab").prop("aria-selected", false).removeClass("active show");
                $("#nav-novoUsuario").removeClass("active show in");
                $("#nav-usuarios-tab").prop("aria-selected", true).addClass("active show");
                $("#nav-usuarios").addClass("active show in");

                $("#mensagensContainer").hide().append(
                    '<div class="col-sm-12" id="msgUsuarioAdicionado">'
                    + '<div class="alert  alert-success alert-dismissible fade show" role="alert">'
                    + '<span class="badge badge-pill badge-success">sucesso</span> Usuario adicionado.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>').fadeIn();
            } else {
                $("#mensagensContainerErrosForm").hide().append(
                    '<div class="col-sm-12" id="msgErroInternoUsuario">'
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