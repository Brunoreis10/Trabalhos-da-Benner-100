$(() => criaController(criaJogo(createSprite(".sprite"))).inicia());

const criaController = jogo => {
    const $entrada = $(".entrada");
    const $lacunas = $(".lacunas");

    const exibeLacunas = () => {
        $lacunas.empty(); //<- Correção instrutor, esqueci deste comando.
        let listaLacunas = [];
        $.each(jogo.getLacunas(), function(i, lacuna){
            // listaLacunas.push($("<li>").addClass("lacuna")); <- Minha resposta. Esqueci de setar o texto:
            listaLacunas.push($("<li>").addClass("lacuna").text(lacuna));
        });
        $lacunas.append(listaLacunas);
    };
   
    const mudaPlaceHolder = texto => {
        // $entrada.attr("placeholder", "Chute"); <- Minha resposta. Esqueci do parâmetro. Correção:
        $entrada.attr("placeholder", texto);
        $entrada.val("");
    };

    const guardaPalavraSecreta = () => {
        // jogo.setPalavraSecreta($entrada.val()); <- Minha solução. Sugestão instrutor:
        try {
            jogo.setPalavraSecreta($entrada.val().trim());
            exibeLacunas();
            mudaPlaceHolder('Chute');
        } catch(error) {
            alert(error.message);
        }
    };

    const leChute = () => {
        // jogo.processaChute($entrada.val());
        // exibeLacunas(); <- Minha solução. Faltaram algumas coisas. Correção instrutor:
        try {
            jogo.processaChute($entrada.val().trim().substr(0,1));
            $entrada.val("");
            exibeLacunas();

            if (jogo.ganhouOuPerdeu()){
                // if (jogo.ganhou()) {
                //     alert("Você ganhou!");
                // } else {
                //     alert("Tente novamente!");
                // }
                // jogo.reinicia();
                // exibeLacunas(); <- Minha resposta, faltando algumas coisas - Correção:
                setTimeout(function (){
                    if (jogo.ganhou()) {
                        alert("Você ganhou!");
                    } else {
                        alert("Tente novamente!");
                    }
                    reinicia();
                }, 200);
            }
        } catch(error) {
            alert(error.message);
        }
    };

    const reinicia = () => {
        jogo.reinicia();
        $lacunas.empty();
        mudaPlaceHolder("Palavra secreta");    
    };

    const inicia = () => {
        $entrada.keypress(event => {
            if (event.which == 13) {
                switch (jogo.getEtapa()) {
                    case 1:
                        guardaPalavraSecreta();
                        break;
                    case 2:
                        leChute();
                        break;
                }
            }
        });
    }; 
    return { inicia };
};    