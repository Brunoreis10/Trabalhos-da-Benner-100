$(function () {
    $('#filtroFuncionario').on('keyup', function () {
        tabelavendas.columns(3).search(this.value).draw();
    });

    $('#filtroCliente').on('keyup', function () {
        tabelavendas.columns(2).search(this.value).draw();
    });

    $("#botaoFiltroData").click(function () {
        if (filtrouData) {
            tabelavendas.columns().search('').draw();
            $(this).removeClass("btn-warning").addClass("btn-success").text("Buscar");
        } else {
            tabelavendas.columns(1).search(moment($("#filtroData").val()).format('L')).draw();
            $(this).removeClass("btn-success").addClass("btn-warning").text("Desfazer");
        }
        filtrouData = !filtrouData;
    });
});

var filtrouData = false;