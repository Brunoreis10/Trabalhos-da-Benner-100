var pacientes = document.querySelectorAll(".paciente");
for (var i = 0; i < pacientes.length; i++ ){
    var paciente = pacientes[i];
    
    var tdPeso = paciente.querySelector(".info-peso");
    var peso = tdPeso.textContent;

    var tdAltura = paciente.querySelector(".info-altura");
    var altura = tdAltura.textContent;

    var tdImc = paciente.querySelector(".info-imc");

    var pesoValido = validaPeso(peso);
    var alturaValida = validaAltura(altura);

    if(!pesoValido){
        //paciente.style.backgroundColor = "lightcoral";
        paciente.classList.add("paciente-invalido");
        tdPeso.textContent = "Peso inválido."; 
        pesoValido = false;
    }

    if(!alturaValida){
        //paciente.style.backgroundColor = "lightcoral";
        paciente.classList.add("paciente-invalido");
        tdAltura.textContent = "Altura inválida.";
        alturaValida = false;
    }

    if(pesoValido && alturaValida) {
        var imc = calculaImc(peso, altura); // 100/(2.00*2.00) // 100/4.00 = 25

        tdImc.textContent = imc;
    } else {
        tdImc.textContent = "Altura e/ou peso inválido(s)!"
    }
}

function calculaImc(peso, altura) {
    var imc = peso/(altura*altura);
    
    return imc.toFixed(2);
}

function validaPeso(peso) {
    if(peso >= 0 && peso < 500 ){
        return true;
    } else {
        return false;
    }
}

function validaAltura(altura) {
    if(altura >= 0 && altura < 3 ){
        return true;
    } else {
        return false;
    }
}