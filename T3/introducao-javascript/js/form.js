var botaoAdicionar = document.querySelector("#adicionar-paciente");

botaoAdicionar.addEventListener("click", function(event) {
    event.preventDefault();
    
    var form = document.querySelector("#form-adiciona");
    
    var paciente = pegaValuesInputPaciente(form);
    
    var erros = validaPaciente(paciente); 
    if (erros.length > 0) {
        exibeMensagensDeErro(erros);
        return;
    }
    
    adicionaPacienteNaTabela(paciente);
    
    form.reset();
    var mensagensErro = document.querySelector("#mensagens-erro");
    mensagensErro.innerHTML = "";
});

function adicionaPacienteNaTabela(paciente) {
    var pacienteTr = montaPacienteTr(paciente);
    var tabela = document.querySelector("#tabela-pacientes");
    tabela.appendChild(pacienteTr);
}

function pegaValuesInputPaciente(form) {
    var paciente = {
        nome: form.nome.value,
        peso: form.peso.value,
        altura: form.altura.value,
        gordura: form.gordura.value,
        imc: calculaImc(form.peso.value, form.altura.value)
    }
    
    return paciente;
}

function montaPacienteTr(paciente) {
    var pacienteTr = document.createElement("tr");
    pacienteTr.classList.add("paciente");
    
    pacienteTr.appendChild(montaTd(paciente.nome, "info-nome"));
    pacienteTr.appendChild(montaTd(paciente.peso, "info-peso"));
    pacienteTr.appendChild(montaTd(paciente.altura, "info-altura"));
    pacienteTr.appendChild(montaTd(paciente.gordura, "info-gordura"));
    pacienteTr.appendChild(montaTd(paciente.imc, "info-imc"));
    
    return pacienteTr;
}

function montaTd(valor, classe) {
    var td = document.createElement("td");
    td.classList.add(classe);
    td.textContent = valor;
    
    return td;
}

function validaPaciente(paciente){
    erros = [];
    
    if(paciente.peso.length == 0) erros.push("Informe um peso.");
    
    if(paciente.altura.length == 0) erros.push("Informe a altura.");
    
    if(paciente.nome.length == 0) erros.push("Informe o nome.");
    
    if(paciente.gordura.length == 0) erros.push("Informe um valor para a gordura corporal.");
    
    if(!validaPeso(paciente.peso)) erros.push("Peso inválido.");
    
    if(!validaAltura(paciente.altura)) erros.push("Altura inválida.");
    
    return erros;
}

function exibeMensagensDeErro(erros){
    var ul = document.querySelector("#mensagens-erro");
    ul.innerHTML = "";
    erros.forEach(function (erro){
        var li = document.createElement("li");
        li.textContent = erro;
        ul.appendChild(li);
    });
}