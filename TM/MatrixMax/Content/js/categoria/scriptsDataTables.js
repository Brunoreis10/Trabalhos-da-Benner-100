var tabelacategorias = $('#bootstrap-data-table-Categorias').DataTable(
    {
        dom: 'iltp',
        "language":
            {
                "info": "Total: _TOTAL_ categoria(s) - Página _PAGE_ de _PAGES_.",
                "zeroRecords": "Nenhum resultado encontrado.",
                "infoEmpty": "Mostrando 0 categorias.",
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
                "lengthMenu": "Categorias por página:  _MENU_",
                select: {
                    rows: {
                        _: "%d categorias selecionadas.",
                        0: "Clique em uma categoria para selecioná-la.",
                        1: "1 categoria selecionada."
                    }
                }
            },
        "ajax": {
            "url": "/Categoria/getCategorias",
            "type": "GET",
            "datatype": "json",
        },
        columns: [
            { data: "Id", visible: true, searchable: false, orderable: false },
            {
                data: "Nome", visible: true, searchable: true, orderable: true,
                render: function (data, type, row, meta) {
                    return '<button type="button" class="btn btn-link mb-1 font-weight-bold" onclick="editaCategoria(' + meta.row + ')">' + row.Nome + '<i class="fa ml-1 fa-edit"></i></button>';
                }
            },
            {
                data: "Ativo",
                render: function (data, type, row, meta) {
                    return row.Ativo ?
                        '<button type="button" class="btn btn-danger rounded" onclick="desativaCategoria(' + meta.row + ')"><i class="fa fa-ban"></i></button>'
                        :
                        '<button type="button" class="btn btn-success mb-1 rounded" onclick="ativaCategoria(' + meta.row + ')"><i class="fa fa-check"></i></button>';
                }
            }
        ]
    }
);

var tabelasubcategorias = $('#bootstrap-data-table-Subcategorias').DataTable(
    {
        dom: 'iltp',
        "language":
            {
                "info": "Total: _TOTAL_ subcategoria(s) - Página _PAGE_ de _PAGES_.",
                "zeroRecords": "Nenhum resultado encontrado.",
                "infoEmpty": "Mostrando 0 subcategorias.",
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
                "lengthMenu": "Subcategorias por página:  _MENU_",
                select: {
                    rows: {
                        _: "%d subcategorias selecionadas.",
                        0: "Clique em uma subcategoria para selecioná-la.",
                        1: "1 subcategoria selecionada."
                    }
                }
            },
        "ajax": {
            "url": "/Categoria/getTodasAsSubcategorias",
            "type": "GET",
            "datatype": "json",
        },
        columns: [
            { data: "Id", visible: true, searchable: false, orderable: false },
            {
                data: "Nome", visible: true, searchable: true, orderable: true,
                render: function (data, type, row, meta) {
                    return '<button type="button" class="btn btn-link mb-1 font-weight-bold" onclick="editaSubcategoria(' + meta.row + ')">' + row.Nome + '<i class="fa ml-1 fa-edit"></i></button>';
                }
            },
            { data: "Categoria", visible: true, searchable: false, orderable: false },
            {
                data: "Ativo",
                render: function (data, type, row, meta) {
                    return row.Ativo ?
                        '<button type="button" class="btn btn-danger rounded" onclick="desativaSubcategoria(' + meta.row + ')"><i class="fa fa-ban"></i></button>'
                        :
                        '<button type="button" class="btn btn-success mb-1 rounded" onclick="ativaSubcategoria(' + meta.row + ')"><i class="fa fa-check"></i></button>';
                }
            },
            { data: "CategoriaId", visible: false, searchable: true }
        ]
    }
);