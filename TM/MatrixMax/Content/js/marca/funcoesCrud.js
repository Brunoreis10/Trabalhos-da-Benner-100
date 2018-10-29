$(function () {
    $("#nav-marcas-tab").click(function () {
        tabelamarcas.ajax.reload();
    });

    $("#BotaoAddMarcas").click(function () {
        $("#FormAddMarca").fadeIn();
    });

    $('#FormAddMarca').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.adicionou) {
                $('#FormAddMarca').resetForm();
                $('#FormAddMarca').fadeOut();
                tabelamarcas.ajax.reload();
                $("#mensagensContainerMarcas").append(
                    '<div class="col-sm-12" id="msgMarcaAdicionada">'
                    + '<div class="alert  alert-success alert-dismissible fade show" role="alert">'
                    + '<span class="badge badge-pill badge-success">sucesso</span> Marca adicionada.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>');
                $("#msgErroMarcaAdd").prop("hidden", true);
            } else {
                $("#msgErroMarcaAdd").prop("hidden", false);
                $("#msgErroMarcaAdd").html("Erro interno: <br/>" + resposta.msg);
            }
        }
    });

    $("#BotaoCancelaMarcaEdit").click(function (event) {
        event.preventDefault();
        $("#FormEditMarca").fadeOut();
        $('#FormEditMarca').resetForm();
        $("#msgErroMarcaEdit").prop("hidden", true);
    });

    $("#BotaoCancelaMarcaAdd").click(function (event) {
        event.preventDefault();
        $("#FormAddMarca").fadeOut();
        $('#FormAddMarca').resetForm();
        $("#msgErroMarcaAdd").prop("hidden", true);
    });

    $('#FormEditMarca').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.atualizou) {
                $('#FormEditMarca').resetForm();
                $('#FormEditMarca').fadeOut();
                tabelamarcas.ajax.reload();
                $("#mensagensContainerMarcas").append(
                    '<div class="col-sm-12" id="msgMarcaAtualizada">'
                    + '<div class="sufee-alert alert with-close alert-warning alert-dismissible fade show">'
                    + '<span class="badge badge-pill badge-warning">sucesso</span> Marca atualizada.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>');
                $("#msgErroMarcaEdit").prop("hidden", true);
            } else {
                $("#msgErroMarcaEdit").prop("hidden", false);
                $("#msgErroMarcaEdit").html("Erro interno: <br/>" + resposta.msg);
            }
        }
    });

    $('#botaoPesquisaMarca').on('keyup', function () {
        tabelamarcas.search(this.value).draw();
    }); 
});

function editaMarca(index) {
    var dados = tabelamarcas.rows(index).data();
    $("#idMarcaEdit").val(dados[0].Id);
    $("#nomeMarcaEdit").val(dados[0].Nome);
    $("#FormEditMarca").fadeIn();
}

function ativaMarca(index) {
    var marcaId = tabelamarcas.rows(index).data()[0].Id;
    $.ajax({
        url: "/Marca/Ativa/" + marcaId,
        dataType: "json",
        success: function (response) {
            if (response.ativou) {
                tabelamarcas.ajax.reload();
            } else {
                alert("Erro!");
            }
        }
    });
}

function desativaMarca(index) {
    var marcaId = tabelamarcas.rows(index).data()[0].Id;
    $.ajax({
        url: "/Marca/Desativa/" + marcaId,
        dataType: "json",
        success: function (response) {
            if (response.desativou) {
                tabelamarcas.ajax.reload();
            } else {
                alert("Erro!");
            }
        }
    });
}