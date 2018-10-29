var tabelausuarios = $('#bootstrap-data-table-Usuarios').DataTable(
    {
        dom: 'iltp',
        "language":
        {
            "info": "Total: _TOTAL_ usuário(s) - Página _PAGE_ de _PAGES_.",
            "zeroRecords": "Nenhum usuário encontrado.",
            "infoEmpty": "Mostrando 0 usuários.",
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
            "lengthMenu": "usuários por página:  _MENU_",
        },
        "ajax": {
            "url": "/Usuario/getUsuarios",
            "type": "GET",
            "datatype": "json"
        },
        columns: [
            { data: "Id", visible: true, searchable: false, orderable: false },
            { data: "Login", visible: true, searchable: true, orderable: false },
            { data: "Pessoa.NomeRazaoSocial", visible: true, searchable: false, orderable: false },
            {
                visible: true, searchable: true, orderable: true,
                render: function (data, type, row, meta) {
                    return row.TipoUsuario == "A" ?
                        '<button type="button" class="btn btn-success rounded font-weight-bold" onclick="togglePrivilegio(' + meta.row + ')" >Administrador</button>'
                        :
                        '<button type="button" class="btn btn-warning mb-1 rounded font-weight-bold" onclick="togglePrivilegio(' + meta.row + ')">Funcionário</button>';
                }
            },
            {
                visible: true, searchable: true, orderable: false,
                render: function (data, type, row, meta) {
                    return row.Ativo ?
                        '<button type="button" class="btn btn-danger rounded" onclick="toggleAtivo(' + meta.row + ')"><i class="fa fa-ban"></i></button>'
                        :
                        '<button type="button" class="btn btn-success mb-1 rounded" onclick="toggleAtivo(' + meta.row + ')"><i class="fa fa-check"></i></button>';
                }
            }
        ]
    }
);

function toggleAtivo(index) {
    var usuarioId = tabelausuarios.rows(index).data()[0].Id;
    $.ajax({
        url: "/Usuario/toggleAtivo/" + usuarioId,
        dataType: "json",
        success: function (response) {
            if (response.trocou) {
                tabelausuarios.ajax.reload();
            } else {
                console.log(response.msg);
            }
        }
    });
}

function togglePrivilegio(index) {
    var usuarioId = tabelausuarios.rows(index).data()[0].Id;
    $.ajax({
        url: "/Usuario/togglePrivilegio/" + usuarioId,
        dataType: "json",
        success: function (response) {
            if (response.trocou) {
                tabelausuarios.ajax.reload();
            } else {
                console.log(response.msg);
            }
        }
    });
}