var botaoBuscar = document.querySelector("#buscar-pacientes");

botaoBuscar.addEventListener("click", function() {
    var xhr = new XMLHttpRequest(); //Objeto para requisições assíncronas em JS! - Antigamente só XML, hoje para vários formatos.
    
    xhr.open("GET", "http://api-pacientes.herokuapp.com/pacientes");
    //Abre a requisição com Método e URL. Não faz a requisição ainda!

    xhr.addEventListener("load", function() {
    //Evento LOAD - Quando a requisição tiver carregada
        var erroAjax = document.querySelector("#erro-ajax");
        if (xhr.status == 200) { //Código do retorno da requisição.
            erroAjax.classList.add("invisivel");
            var resposta = xhr.responseText; //String JSON
            var pacientes = JSON.parse(resposta); //Transforma a String em Objetos JS.
            pacientes.forEach(function(paciente) {
                adicionaPacienteNaTabela(paciente);
            });
        } else {
            erroAjax.classList.remove("invisivel");
        }
    });

    xhr.send();
    //De fato envia a requisição.
});