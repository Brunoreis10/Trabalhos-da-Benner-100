moment.locale("pt-br");
var tabelaclientes = $('#bootstrap-data-table-Clientes').DataTable(
    {
        dom: 'iltp',
        "language":
        {
            "info": "Total: _TOTAL_ cliente(s) - Página _PAGE_ de _PAGES_.",
            "zeroRecords": "Nenhum resultado encontrado.",
            "infoEmpty": "Mostrando 0 clientes.",
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
            "lengthMenu": "clientes por página:  _MENU_",
        },
        "ajax": {
            "url": "/Cliente/getClientes",
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { data: "Id", visible: false, searchable: false, orderable: false },
            { data: "Email", visible: false, searchable: false, orderable: false },
            { data: "Telefone", visible: false, searchable: false, orderable: false },
            { data: "CpfCnpj", visible: false, searchable: false, orderable: false },
            { data: "InscricaoEstadual", visible: false, searchable: false, orderable: false },
            { data: "NomeFantasia", visible: false, searchable: false, orderable: false },
            { data: "Endereco.Logradouro", visible: false, searchable: false, orderable: false },
            { data: "Endereco.Numero", visible: false, searchable: false, orderable: false },
            { data: "Endereco.Cep", visible: false, searchable: false, orderable: false },
            { data: "Endereco.Referencia", visible: false, searchable: false, orderable: false },
            { data: "Endereco.Bairro", visible: false, searchable: false, orderable: false },
            { data: "Endereco.Complemento", visible: false, searchable: false, orderable: false },
            { data: "Endereco.Cidade", visible: false, searchable: false, orderable: false },
            { data: "Endereco.Estado", visible: false, searchable: false, orderable: false },
            {
                data: "NomeRazaoSocial", visible: true, searchable: true, orderable: true,
                render: function (data, type, row, meta) {
                    return '<button type="button" class="btn btn-link mb-1 font-weight-bold" data-toggle="modal" data-target="#ModalEditar" onclick="populaEditar(' + meta.row + ')">'
                        + row.NomeRazaoSocial +'<i class="fa ml-1 fa-external-link"></i>'
                        + '</button>';
                }
            },
            {
                data: "TipoPessoa", visible: true, searchable: true, orderable: false,
                render: function (data, type, row, meta) {
                    return row.TipoPessoa == "F" ? "Física" : "Jurídica";
                }
            },
            {
                visible: true, searchable: false, orderable: false,
                render: function (data, type, row, meta) {
                    return '<button type="button" class="btn btn-link mb-1 font-weight-bold" data-toggle="modal" data-target="#ModalDados" onclick="populaDados('+meta.row+')">'
                        + 'Visualizar<i class="fa ml-1 fa-external-link"></i>'
                        + '</button>';
                }
            },
            {
                visible: true, searchable: false, orderable: false,
                render: function (data, type, row, meta) {
                    return '<button type="button" class="btn btn-link mb-1 font-weight-bold" data-toggle="modal" data-target="#ModalEndereco" onclick="populaEndereco(' + meta.row +')">'
                        + 'Visualizar<i class="fa ml-1 fa-external-link"></i>'
                        + '</button>';
                }
            },
            {
                visible: true, searchable: false, orderable: false,
                render: function (data, type, row, meta) {
                    return '<button type="button" class="btn btn-link mb-1 font-weight-bold" data-toggle="modal" data-target="#ModalVendas" onclick="buscaVendas(' + meta.row +')">'
                        + 'Buscar<i class="fa ml-1 fa-external-link"></i>'
                        + '</button>';
                }
            }
        ]
    }
);

var tabelaVendas = null;

function buscaVendas(index) {
    var dados = tabelaclientes.rows(index).data();

    if ($.fn.DataTable.isDataTable('#bootstrap-data-table-Vendas')) {
        tabelaVendas.ajax.url("/Venda/getVendasDoCliente/" + dados[0].Id).load();
    }
    else {
        tabelaVendas = $('#bootstrap-data-table-Vendas').DataTable(
            {
                dom: 't',
                "ajax": {
                    "url": "/Venda/getVendasDoCliente/" + dados[0].Id,
                    "type": "GET",
                    "datatype": "json"
                },
                "language":
                {
                    "zeroRecords": "Nenhum resultado encontrado.",
                    "infoEmpty": "Mostrando 0 vendas.",
                    "infoFiltered": "(Filtrado de _MAX_ itens.)",
                    "decimal": ",",
                    "thousands": ".",
                    "loadingRecords": "Carregando...",
                    "processing": "Processando...",
                    "emptyTable": "Este cliente não possui nenhuma compra."
                },
                columns: [
                    {
                        render: function (data, type, row, meta) {
                            return moment(row.Data).format('L');
                        }, orderable: false
                    },
                    { data: "Produtos", orderable: false },
                    {
                        render: function (data, type, row, meta) {
                            return "R$ " + Number.parseFloat(row.ValorTotal).toFixed(2).replace(".", ",");
                        }, orderable: false
                    }
                ]
            }
        );
    }

}