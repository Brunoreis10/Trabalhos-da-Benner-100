var tabelaestoque = $('#bootstrap-data-table-Estoque').DataTable(
    {
        dom: 't',
        paging: false,
        "language":
        {
            "info": "Total: _TOTAL_ produto(s) - Página _PAGE_ de _PAGES_.",
            "zeroRecords": "Nenhum resultado encontrado.",
            "infoEmpty": "Mostrando 0 produtos.",
            "infoFiltered": "(Filtrado de _MAX_ itens.)",
            "decimal": ",",
            "thousands": ".",
            "search": "",
            "loadingRecords": "Carregando...",
            "processing": "Processando...",
            "paginate": {
                "first": "Primeira",
                "last": "Última",
                "next": "Próxima",
                "previous": "Anterior"
            },
            "lengthMenu": "Produtos por página:  _MENU_"
        },
        "ajax": {
            "url": "/Produto/getListaEstoque",
            "type": "GET",
            "datatype": "json"
        },
        order: [[4, 'asc']],
        rowGroup: {
            dataSrc: "estadoEstoque"
        },
        columns: [
            { data: "Id", visible: true, searchable: false, orderable: false },
            {
                visible: true, searchable: true, orderable: false, width: "70%",
                render: function (data, type, row, meta) {
                    return '<button type="button" class="btn btn-link mb-1 font-weight-bold botaoEstoque" onclick="reporEstoque(' + meta.row + ')">'
                        + row.Nome + '<i class="fa ml-1 fa-external-link"></i>'
                        + '</button>';
                }
            },
            { data: "Estoque", visible: true, searchable: false, orderable: false },
            { data: "EstoqueMinimo", visible: true, searchable: false, orderable: false },
            { data: "estadoEstoque", visible: false, searchable: false, orderable: false }
        ],
        rowCallback: function (row, data) {
            if (data.estadoEstoque == "Positivo") $(row).addClass('table-success');
            if (data.estadoEstoque == "Neutro") $(row).addClass('table-warning');
            if (data.estadoEstoque == "Alerta") $(row).addClass('table-danger');
            if (data.estadoEstoque == "Sem estoque") $(row).addClass('table-secondary');
        }
    }
);

var idSelecionado = 0;

$("#unidadesEstoque").mask("000");

$('#filtroNome').on('keyup', function () {
    tabelaestoque.search(this.value).draw();
});

const reporEstoque = index => {
    let dados = tabelaestoque.rows(index).data();
    idSelecionado = dados[0].Id;
    $("#unidadesEstoque").val("");
    $("#dialogReporEstoque").fadeIn();
    $("#labelEstoque").hide().html("Repondo o estoque de: <br/>" + dados[0].Nome).fadeIn();
};

$("#botaoRepoeEstoque").click(() => {
    var unidades = Number.parseInt($("#unidadesEstoque").val());
    if (isNaN(unidades) || unidades <= 0 || unidades >= 100) {
        $("#mensagensEstoqueContainer").hide().html("Quantidade inválida.").fadeIn();
        return;
    }
    $.ajax({
        url: "/Produto/RepoeEstoque",
        data: { id: idSelecionado, unidades },
        dataType: "json",
        success: response => {
            if (response.incrementou) {
                tabelaestoque.ajax.reload();
                escondeContainer();
            } else {
                $("#mensagensEstoqueContainer").hide().html("Erro interno: " + response.msg).fadeIn();
            }
        }
    });
});

$("#botaoCancelaReporEstoque").click(() => {
    escondeContainer();
});

const escondeContainer = () => {
    $("#mensagensEstoqueContainer").html("").fadeOut();
    $("#dialogReporEstoque").fadeOut();
    $("#unidadesEstoque").val("");
    $("#labelEstoque").hide().text("Clique no nome do produto para repor o estoque.").fadeIn();
};