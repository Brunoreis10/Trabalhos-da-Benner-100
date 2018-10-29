$(function () {
    $("#nav-categorias-tab").click(function () {
        tabelacategorias.ajax.reload();
    });

    $("#nav-subcategorias-tab").click(function () {
        $("#selectFiltrarPorCategoria option").remove();
        processaFiltroPorCategoria();
        tabelasubcategorias.ajax.reload();
    });

    processaFiltroPorCategoria();

    $("#BotaoAddCategorias").click(function () {
        $("#FormAddCategoria").fadeIn();
    });

    $("#BotaoCancelaCategoriaAdd").click(function (event) {
        event.preventDefault();
        $("#FormAddCategoria").fadeOut();
        $('#FormAddCategoria').resetForm();
    });

    $("#BotaoAddSubcategorias").click(function () {
        $("#selectSubcategoriaAdd option").remove();
        $("#selectSubcategoriaAdd").append(
            $("<option></option>")
                .text("Categoria")
                .val("")
        );
        $.getJSON("/Categoria/getCategoriasAtivas", null, function (response) {
            $.each(response.data, function (index, item) {
                $("#selectSubcategoriaAdd").append(
                    $("<option></option>")
                        .text(item.Nome)
                        .val(item.Id)
                );
            });
        });
        $("#FormAddSubcategoria").fadeIn();
    });

    $("#BotaoCancelaSubcategoriaAdd").click(function (event) {
        event.preventDefault();
        $("#FormAddSubcategoria").fadeOut();
        $('#FormAddSubcategoria').resetForm();
    });

    $('#botaoPesquisaCategoria').on('keyup', function () {
        tabelacategorias.search(this.value).draw();
    });

    $('#botaoPesquisaSubcategoria').on('keyup', function () {
        tabelasubcategorias.search(this.value).draw();
    });

    $('#FormAddSubcategoria').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.adicionou) {
                $('#FormAddSubcategoria').resetForm();
                $('#FormAddSubcategoria').fadeOut();
                tabelasubcategorias.ajax.reload();
                $("#mensagensContainerSubcategorias").append(
                    '<div class="col-sm-12" id="msgSubcategoriaAdicionada">'
                    + '<div class="alert  alert-success alert-dismissible fade show" role="alert">'
                    + '<span class="badge badge-pill badge-success">sucesso</span> Subcategoria adicionada.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>');
                $("#msgErroSubcategoriaAdd").prop("hidden", true);
            } else {
                $("#msgErroSubcategoriaAdd").prop("hidden", false);
                $("#msgErroSubcategoriaAdd").html("Erro interno: <br/>" + resposta.msg);
            }
        }
    });

    $('#FormAddCategoria').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.adicionou) {
                $('#FormAddCategoria').resetForm();
                $('#FormAddCategoria').fadeOut();
                tabelacategorias.ajax.reload();
                $("#mensagensContainerCategorias").append(
                    '<div class="col-sm-12" id="msgCategoriaAdicionada">'
                    + '<div class="alert  alert-success alert-dismissible fade show" role="alert">'
                    + '<span class="badge badge-pill badge-success">sucesso</span> Categoria adicionada.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>');
                $("#msgErroCategoriaAdd").prop("hidden", true);
            } else {
                $("#msgErroCategoriaAdd").prop("hidden", false);
                $("#msgErroCategoriaAdd").html("Erro interno: <br/>" + resposta.msg);
            }
        }
    });

    $("#BotaoCancelaCategoriaEdit").click(function (event) {
        event.preventDefault();
        $("#FormEditategoria").fadeOut();
        $('#FormEditCategoria').resetForm();
        $("#msgErroCategoriaEdit").prop("hidden", true);
    });

    $("#BotaoCancelaSubcategoriaEdit").click(function (event) {
        event.preventDefault();
        $("#FormEditSubcategoria").fadeOut();
        $('#FormEditSubcategoria').resetForm();
        $("#msgErroSubcategoriaEdit").prop("hidden", true);
    });

    $('#FormEditCategoria').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.atualizou) {
                $('#FormEditCategoria').resetForm();
                $('#FormEditCategoria').fadeOut();
                tabelacategorias.ajax.reload();
                $("#mensagensContainerCategorias").append(
                    '<div class="col-sm-12" id="msgCategoriaAtualizada">'
                    + '<div class="sufee-alert alert with-close alert-warning alert-dismissible fade show">'
                    + '<span class="badge badge-pill badge-warning">sucesso</span> Categoria atualizada.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>');
                $("#msgErroCategoriaEdit").prop("hidden", true);
            } else {
                $("#msgErroCategoriaEdit").prop("hidden", false);
                $("#msgErroCategoriaEdit").html("Erro interno: <br/>" + resposta.msg);
            }
        }
    });

    $('#FormEditSubcategoria').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.atualizou) {
                $('#FormEditSubcategoria').resetForm();
                $('#FormEditSubcategoria').fadeOut();
                tabelasubcategorias.ajax.reload();
                $("#mensagensContainerSubcategorias").append(
                    '<div class="col-sm-12" id="msgCategoriaAtualizada">'
                    + '<div class="sufee-alert alert with-close alert-warning alert-dismissible fade show">'
                    + '<span class="badge badge-pill badge-warning">sucesso</span> Subcategoria atualizada.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>');
                $("#msgErroSubcategoriaEdit").prop("hidden", true);
            } else {
                $("#msgErroSubcategoriaEdit").prop("hidden", false);
                $("#msgErroSubcategoriaEdit").html("Erro interno: <br/>" + resposta.msg);
            }
        }
    });
});

function processaFiltroPorCategoria() {
    $("#selectFiltrarPorCategoria").append(
        $("<option></option>")
            .text("Filtrar por categoria...")
            .val("0")
    );

    $.getJSON("/Categoria/getCategorias", null, function (response) {
        $.each(response.data, function (index, item) {
            $("#selectFiltrarPorCategoria").append(
                $("<option></option>")
                    .text(item.Nome)
                    .val(item.Id)
            );
        });
    });

    $("#selectFiltrarPorCategoria").click(function () {
        if ($(this).val() > 0) {
            var regex = "^"+$(this).val()+"$";
            tabelasubcategorias.column(4).search(regex,true).draw();
        } else {
            tabelasubcategorias.columns().search('').draw();
        }
    });
}

function editaCategoria(index) {
    var dados = tabelacategorias.rows(index).data();
    $("#idCategoriaEdit").val(dados[0].Id);
    $("#nomeCategoriaEdit").val(dados[0].Nome);
    $("#FormEditCategoria").fadeIn();
}

function editaSubcategoria(index) {
    var dados = tabelasubcategorias.rows(index).data();
    $("#selectSubcategoriaEdit option").remove();
    $.getJSON("/Categoria/getCategorias", null, function (response) {
        $.each(response.data, function (index, item) {
            if (item.Id === dados[0].CategoriaId) {
                $("#selectSubcategoriaEdit").append(
                    $("<option></option>")
                        .text(item.Nome)
                        .val(item.Id)
                        .attr("selected", true)
                );
            } else {
                $("#selectSubcategoriaEdit").append(
                    $("<option></option>")
                        .text(item.Nome)
                        .val(item.Id)
                );
            }
        });
    });
    $("#idSubcategoriaEdit").val(dados[0].Id);
    $("#nomeSubcategoriaEdit").val(dados[0].Nome);
    $("#FormEditSubcategoria").fadeIn();
}

function ativaCategoria(index) {
    var categoriaId = tabelacategorias.rows(index).data()[0].Id;
    $.ajax({
        url: "/Categoria/Ativa/" + categoriaId,
        dataType: "json",
        success: function (response) {
            if (response.ativou) {
                tabelacategorias.ajax.reload();
            } else {
                alert("Erro!");
            }
        }
    });
}

function desativaCategoria(index) {
    var categoriaId = tabelacategorias.rows(index).data()[0].Id;
    $.ajax({
        url: "/Categoria/Desativa/" + categoriaId,
        dataType: "json",
        success: function (response) {
            if (response.desativou) {
                tabelacategorias.ajax.reload();
            } else {
                alert("Erro!");
            }
        }
    });
}

function ativaSubcategoria(index) {
    var categoriaId = tabelasubcategorias.rows(index).data()[0].Id;
    $.ajax({
        url: "/Categoria/Ativa/" + categoriaId,
        dataType: "json",
        success: function (response) {
            if (response.ativou) {
                tabelasubcategorias.ajax.reload();
            } else {
                alert("Erro!");
            }
        }
    });
}

function desativaSubcategoria(index) {
    var categoriaId = tabelasubcategorias.rows(index).data()[0].Id;
    $.ajax({
        url: "/Categoria/Desativa/" + categoriaId,
        dataType: "json",
        success: function (response) {
            if (response.desativou) {
                tabelasubcategorias.ajax.reload();
            } else {
                alert("Erro!");
            }
        }
    });
}