const criaJogo = sprite => {
    let etapa = 1;
    let lacunas = [];
    let palavraSeceta;
    
    const setPalavraSecreta = palavra => {
        if (!palavra.trim()) throw Error("Palavra secreta inválida!");
        palavraSeceta = palavra;
        
        geraLacunas(palavraSeceta);

        // etapa++; <- Minha solução. Solução do instrutor:
        proximaEtapa();
    };

    const ganhou = () => !lacunas.some(l => l === "") && lacunas.length > 0;

    const perdeu = () => sprite.isFinished();

    const ganhouOuPerdeu = () => ganhou() || perdeu();

    const reinicia = () => {
        sprite.reset();
        etapa--;
        lacunas = [];
        palavraSeceta = "";
    };
    
    const processaChute = chute => {
        if (!chute.trim()) throw Error("Chute inválido!");
        if(palavraSeceta.toLowerCase().includes(chute.toLowerCase())) {
            preencheLacunas(chute.toLowerCase());
        } else {
            sprite.nextFrame();
        }
    };

    const preencheLacunas = chute => {
        const regexChute = new RegExp(chute, 'gi');
        while(resultado = regexChute.exec(palavraSeceta)) {
            lacunas[resultado.index] = chute; 
        }
    };

    const proximaEtapa = () => etapa++;

    const geraLacunas = () => lacunas = Array(palavraSeceta.length).fill("");
        // for (letra in palavra){
        //     lacunas.push("");
        // } <- Minha solução. Sugestão do instrutor:

    const getLacunas = () => lacunas;

    const getEtapa = () => etapa;

    return {
        setPalavraSecreta,
        getLacunas,
        getEtapa,
        processaChute,
        ganhou,
        perdeu,
        ganhouOuPerdeu,
        reinicia
    }
}