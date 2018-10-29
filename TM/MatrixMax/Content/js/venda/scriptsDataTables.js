moment.locale("pt-br");
var tabelavendas = $('#bootstrap-data-table-Vendas').DataTable(
    {
        dom: 'iltp',
        "language":
        {
            "info": "Total: _TOTAL_ vendas(s) - Página _PAGE_ de _PAGES_.",
            "zeroRecords": "Nenhum resultado encontrado.",
            "infoEmpty": "Mostrando 0 vendas.",
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
            "lengthMenu": "vendas por página:  _MENU_",
        },
        "ajax": {
            "url": "/Venda/getVendas",
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { data: "Id", visible: false, searchable: false, orderable: false },
            {
                data: "Data", visible: true, searchable: true, orderable: true,
                render: function (data, type, row, meta) {
                    return moment(row.Data).format('L');
                }
            },
            { data: "Pessoa.NomeRazaoSocial", visible: true, searchable: true, orderable: false, className: "text-left" },
            { data: "Usuario.Pessoa.NomeRazaoSocial", visible: true, searchable: true, orderable: false, className: "text-left" },
            {
                data: "FormaDePagamentoId", visible: true, searchable: false, orderable: false,
                render: function (data, type, row, meta) {
                    if (row.FormaDePagamento.BandeiraCartao) {
                        if (row.Parcelas > 0) {
                            return "Crédito - " + row.Parcelas + "x - " + row.FormaDePagamento.Nome;
                        } else {
                            return "Débito - " + row.FormaDePagamento.Nome;
                        }
                    } else {
                        switch (row.FormaDePagamentoId) {
                            case 2:
                                return "Boleto";
                            case 5:
                                return "Cheque";
                            default:
                                return "Dinheiro";
                        }
                    }
                }
            },
            {
                data: "ValorTotal", visible: true, searchable: false, orderable: false,
                render: function (data, type, row, meta) {
                    desconto = 0;
                    if (row.DescontoPorcento > 0) {
                        desconto = (row.DescontoPorcento / 100) * row.ValorTotal;
                        return row.DescontoPorcento + "% - " + "R$" + Number.parseFloat(desconto).toFixed(2).replace(".", ",");
                    }
                    if (row.DescontoValorFixo > 0) {
                        desconto = row.DescontoValorFixo;
                        return "Valor fixo - " + "R$" + Number.parseFloat(desconto).toFixed(2).replace(".", ",");
                    } 
                    return "Não";
                }
            },
            {
                data: "ValorTotal", visible: true, searchable: false, orderable: false,
                render: function (data, type, row, meta) {
                    return "R$" + Number.parseFloat(row.ValorTotal-desconto).toFixed(2).replace(".", ",");
                }
            },
            {
                data: "Observacao", visible: true, searchable: false, orderable: false,
                render: function (data, type, row, meta) {
                    return '<button type="button" class="btn btn-link mb-1 font-weight-bold" data-toggle="modal" data-target="#ModalDetalhes" onclick="buscaDetalhes(' + meta.row + ')">'
                        + 'Visualizar<i class="fa ml-1 fa-external-link"></i>'
                        + '</button>';
                }
            },
            { data: "Observacao", visible: false, searchable: false, orderable: false }
        ]
    }
);

var desconto = 0;
var tabelaDetalhes = null;

function buscaDetalhes(index) {
    var dados = tabelavendas.rows(index).data();
    $("#observacaoVenda").text(
        dados[0].Observacao == null ? "N/A" : dados[0].Observacao
    );

    if ($.fn.DataTable.isDataTable('#bootstrap-data-table-Detalhes')) {
        tabelaDetalhes.ajax.url("/Venda/getProdutosDaVenda/" + dados[0].Id).load();
    }
    else {
        tabelaDetalhes = $('#bootstrap-data-table-Detalhes').DataTable(
            {
                dom: 't',
                "ajax": {
                    "url": "/Venda/getProdutosDaVenda/" + dados[0].Id,
                    "type": "GET",
                    "datatype": "json"
                },
                columns: [
                    { data: "Produto.Nome", orderable: false },
                    {
                        data: "PrecoSelecionado", orderable: false,
                        render: function (data, type, row, meta) {
                            return "R$ " + Number.parseFloat(row.PrecoSelecionado).toFixed(2).replace(".",",");
                        }
                    },
                    { data: "Quantidade", orderable: false },
                    {
                        data: "Subtotal", orderable: false,
                        render: function (data, type, row, meta) {
                            return "R$ " + Number.parseFloat(row.PrecoSelecionado * row.Quantidade).toFixed(2).replace(".", ",");
                        }
                    }
                ]
            }
        );
    }
    
}