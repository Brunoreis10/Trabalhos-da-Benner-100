var indexproduto = 0;

var desativados = {
    dom: '<"tabelaprodutosbotoes"B><"tabelaprodutosfiltros"f><"tabelaprodutosinfo"il><tp>',
    select: true,
    "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],
    buttons: [
        { extend: 'selected', text: '<button type="button" class="btn btn-success mb-1 rounded" data-toggle="modal" data-target="#ModalAtivar" onclick="pegaDados()">Ativar selecionados <i class="fa fa-check"></i></button>' }
    ],
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
        "lengthMenu": "Produtos por página:  _MENU_",
        select: {
            rows: {
                _: "%d produtos selecionados.",
                0: "Clique em um produto para selecioná-lo.",
                1: "1 produto selecionado."
            }
        }
    },
    "ajax": {
        "url": "/Produto/getDesativados",
        "type": "GET",
        "datatype": "json",
    },
    columns: [
        { data: "Id", visible: false, searchable: false },
        { data: "Subcategoria.CategoriaId", visible: false, searchable: true },
        { data: "SubcategoriaId", visible: false, searchable: false },
        { data: "PrecoRecarga", visible: false, searchable: false },
        { data: "PrecoTroca", visible: false, searchable: false },
        { data: "MarcaId", visible: false, searchable: false },
        { data: "Nome", width: "30%" },
        {
            data: "PrecoUnitario",
            searchable: false,
            orderable: false,
            render: function (data, type, row) {
                if (row.PrecoRecarga != null && row.PrecoTroca != null) {
                    return "UN - R$" + Number.parseFloat(row.PrecoUnitario).toFixed(2).replace('.', ',') +
                        "<br/>TR - R$" + Number.parseFloat(row.PrecoTroca).toFixed(2).replace('.', ',') +
                        "<br/>REC - R$" + Number.parseFloat(row.PrecoRecarga).toFixed(2).replace('.', ',');
                }
                else {
                    return "UN - R$" + Number.parseFloat(row.PrecoUnitario).toFixed(2).replace('.', ',');
                }
            }
        },
        { data: "Marca.Nome", searchable: false, orderable: false },
        { data: "EstoqueMinimo", searchable: false, orderable: false },
        { data: "Estoque", visible: false, searchable: false, orderable: false },
        {
            data: "Subcategoria.Nome",
            searchable: false,
            orderable: false,
            render: function (data, type, row) {
                return row.Subcategoria.CategoriaDaSubcategoria.Nome + " - " + row.Subcategoria.Nome;
            }
        },
    ],
    initComplete: function () {
        $(".dataTables_filter input").removeClass('form-control-sm');
        $(".dataTables_filter input").prop('placeholder', 'Pesquisar por nome');
        $(".dataTables_filter").append('<label><select id="FiltroCategorias" onclick="FiltraPorCategoria()" class="mt-2 ml-1 form-control"><option value="0">Filtrar por categoria</option></select></label>');
        $.getJSON("/Categoria/getCategorias", null, function (data) {
            $.each(data.Categorias, function (index, item) {
                $("#FiltroCategorias").append(
                    $("<option></option>")
                        .text(item.Nome)
                        .val(item.Id)
                );
            });
        });
    }
};

var ativados = {
    dom: '<"tabelaprodutosbotoes"B><"tabelaprodutosfiltros"f><"tabelaprodutosinfo"il><tp>',
    select: true,
    "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],
    buttons: [
        { text: '<button type="button" class="btn btn-success rounded" data-toggle="modal" onclick="pegaCategoriasEMarcas(\'Add\')" data-target="#ModalAdicionar">Novo produto <i class="fa fa-plus-circle"></i></button>' },
        { extend: 'selected', text: '<button type="button" class="btn btn-danger rounded" data-toggle="modal" data-target="#ModalRemover" onclick="pegaDados()">Desativar selecionados <i class="fa fa-ban"></i></button>' }
    ],
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
        "lengthMenu": "Produtos por página:  _MENU_",
        select: {
            rows: {
                _: "%d produtos selecionados.",
                0: "Clique em um produto para selecioná-lo.",
                1: "1 produto selecionado."
            }
        }
    },
    "ajax": {
        "url": "/Produto/getProdutos",
        "type": "GET",
        "datatype": "json",
    },
    columns: [
        { data: "Id", visible: false, searchable: false },
        { data: "Subcategoria.CategoriaId", visible: false, searchable: true },
        { data: "SubcategoriaId", visible: false, searchable: false },
        { data: "PrecoRecarga", visible: false, searchable: false },
        { data: "PrecoTroca", visible: false, searchable: false },
        { data: "MarcaId", visible: false, searchable: false },
        {
            data: "Nome",
            render: function (data, type, row, meta) {
                return '<button type="button" class="btn btn-link mb-1 font-weight-bold" data-toggle="modal" data-target="#ModalEditar" onclick="indexproduto = ' + meta.row + '; populaEditar()">'
                    + row.Nome +
                    '<i class="fa ml-1 fa-edit"></i>' +
                    '</button> ';
            },
            width: "30%",
        },
        {
            data: "PrecoUnitario",
            searchable: false,
            orderable: false,
            render: function (data, type, row) {
                var precos = "UN - R$" + Number.parseFloat(row.PrecoUnitario).toFixed(2).replace('.', ',');
                if (row.PrecoRecarga != null) {
                    precos += "<br/>REC - R$" + Number.parseFloat(row.PrecoRecarga).toFixed(2).replace('.', ',');
                }
                if (row.PrecoTroca != null) {
                    precos += "<br/>TR - R$" + Number.parseFloat(row.PrecoTroca).toFixed(2).replace('.', ',');
                }

                return precos;
            }
        },
        { data: "Marca.Nome", searchable: false, orderable: false },
        { data: "EstoqueMinimo", searchable: false, orderable: false },
        { data: "Estoque", visible: false, searchable: false, orderable: false },
        {
            data: "Subcategoria.Nome",
            searchable: false,
            orderable: false,
            render: function (data, type, row) {
                return row.Subcategoria.CategoriaDaSubcategoria.Nome + " - " + row.Subcategoria.Nome;
            }
        },
    ],
    initComplete: function () {
        $(".tabelaprodutosfiltros .dataTables_filter input").removeClass('form-control-sm');
        $(".tabelaprodutosfiltros .dataTables_filter input").prop('placeholder', 'Pesquisar por nome');
        $(".tabelaprodutosfiltros .dataTables_filter").append('<label><select id="FiltroCategorias" onclick="FiltraPorCategoria()" class="mt-2 ml-1 form-control"><option value="0">Filtrar por categoria</option></select></label>');
        $.getJSON("/Categoria/getCategorias", null, function (response) {
            $.each(response.data, function (index, item) {
                $("#FiltroCategorias").append(
                    $("<option></option>")
                        .text(item.Nome)
                        .val(item.Id)
                );
            });
        });
    }
};

var tabelaprodutos = $('#bootstrap-data-table').DataTable(ativados);

$(function () {
    $("#nav-produtos-tab").click(function () {
        tabelaprodutos.ajax.reload();

        $("#FiltroCategorias option").remove();
        $("#FiltroCategorias").append(
            $("<option></option>")
                .text("Filtrar por categoria")
                .val("0")
        );

        $.getJSON("/Categoria/getCategorias", null, function (response) {
            $.each(response.data, function (index, item) {
                $("#FiltroCategorias").append(
                    $("<option></option>")
                        .text(item.Nome)
                        .val(item.Id)
                );
            });
        });
    });
});