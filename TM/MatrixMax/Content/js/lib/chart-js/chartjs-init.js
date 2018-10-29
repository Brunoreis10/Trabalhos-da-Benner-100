(function ($) {
    "use strict";
    //bar chart

    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: '/Venda/getRelatorioVendasPorMesAnual',
        data: JSON.stringify({ anos: [2017, 2018] }),
        success: function (response) {
            new Chart("barChart", {
                type: 'bar',
                data: {
                    labels: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],

                    datasets: [
                        {
                            label: "2017",
                            data: response[0],
                            backgroundColor: geraCor()

                        },
                        {
                            label: "2018",
                            data: response[1],
                            backgroundColor: geraCor(),
                            fontColor: "#FFF"
                        }]
                },
                options: {
                    plugins: {
                        datalabels: {
                            display: false
                        }
                    },
                    legend: {
                        labels: {
                            fontColor: "white",
                            fontSize: 16
                        }
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,
                                fontColor: "white"
                            },
                            gridLines: {
                                color: "#555"
                            }
                        }],
                        xAxes: [{
                            ticks: {
                                beginAtZero: true,
                                fontColor: "white",
                                fontSize: 11
                            },
                            gridLines: {
                                display: false,
                                color: "#555"
                            }
                        }]
                    }
                }
            });
        }
    });

    $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: '/Venda/getRelatorioVendasPorCategoria',
        success: function (response) {
            var nomes = [];
            var dados = [];
            var cores = [];

            for (var i in response) {
                nomes.push(response[i].Nome);
                dados.push(response[i].Soma);
                cores.push(geraCor());
            }
            
            new Chart("pieChart", {
                type: 'pie',
                data: {
                    datasets: [{
                        data: dados,
                        borderWidth: "0",
                        backgroundColor: cores
                    }],
                    labels: nomes
                },
                options: {
                    plugins: {
                        datalabels: {
                            formatter: (value, ctx) => {
                                let sum = 0;
                                let dataArr = ctx.chart.data.datasets[0].data;
                                dataArr.map(data => {
                                    sum += data;
                                });
                                let percentage = (value * 100 / sum).toFixed(2) + "%";
                                return percentage;
                            },
                            backgroundColor: "#000",
                            borderRadius: "10",
                            color: "white",
                            anchor: "end"
                        }
                    },
                    legend: {
                        labels: {
                            fontColor: "white",
                            fontSize: 14
                        }
                    },
                    responsive: true
                }
            });
        }
    });
})(jQuery);

function geraCor() {
    var r = Math.floor(Math.random() * 255);
    var g = Math.floor(Math.random() * 255);
    var b = Math.floor(Math.random() * 255);
    return "rgb(" + r + "," + g + "," + b + ")";
}